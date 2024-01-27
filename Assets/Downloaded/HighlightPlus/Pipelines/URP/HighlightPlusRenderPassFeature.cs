﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace HighlightPlus {

    public class HighlightPlusRenderPassFeature : ScriptableRendererFeature {
        class HighlightPass : ScriptableRenderPass {

            // far objects render first
            class DistanceComparer: IComparer<HighlightEffect> {

                public Vector3 camPos;

                public int Compare(HighlightEffect e1, HighlightEffect e2) {
                    Vector3 e1Pos = e1 == null ? Vector3.zero : e1.transform.position;
                    float dx1 = e1Pos.x - camPos.x;
                    float dy1 = e1Pos.y - camPos.y;
                    float dz1 = e1Pos.z - camPos.z;
                    float distE1 = dx1 * dx1 + dy1 * dy1 + dz1 * dz1;
                    Vector3 e2Pos = e2 == null ? Vector3.zero : e2.transform.position;
                    float dx2 = e2Pos.x - camPos.x;
                    float dy2 = e2Pos.y - camPos.y;
                    float dz2 = e2Pos.z - camPos.z;
                    float distE2 = dx2 * dx2 + dy2 * dy2 + dz2 * dz2;
                    if (distE1 > distE2) return -1;
                    if (distE1 < distE2) return 1;
                    return 0;
                }
            }

            ScriptableRenderer renderer;
            RenderTextureDescriptor cameraTextureDescriptor;
            DistanceComparer effectDistanceComparer;

            public bool usesCameraOverlay = false;

            public void Setup(RenderPassEvent renderPassEvent, ScriptableRenderer renderer) {
                this.renderPassEvent = renderPassEvent;
                this.renderer = renderer;
                if (effectDistanceComparer == null) {
                    effectDistanceComparer = new DistanceComparer();
                }
            }
            // This method is called before executing the render pass.
            // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
            // When empty this render pass will render to the active camera render target.
            // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
            // The render pipeline will ensure target setup and clearing happens in an performance manner.
            public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) {
                this.cameraTextureDescriptor = cameraTextureDescriptor;
            }

            // Here you can implement the rendering logic.
            // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
            // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
            // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData) {

                Camera cam = renderingData.cameraData.camera;
                int camLayer = 1 << cam.gameObject.layer;

                RenderTargetIdentifier cameraColorTarget = renderer.cameraColorTarget;
                RenderTargetIdentifier cameraDepthTarget = renderer.cameraDepthTarget;
                if (!usesCameraOverlay && (cameraTextureDescriptor.msaaSamples > 1 || cam.cameraType == CameraType.SceneView)) {
                    cameraDepthTarget = cameraColorTarget;
                }
                if (Time.frameCount % 10 == 0 || !Application.isPlaying) {
                    effectDistanceComparer.camPos = cam.transform.position;
                    HighlightEffect.instances.Sort(effectDistanceComparer);
                }

                int count = HighlightEffect.instances.Count;
                for (int k = 0; k < count; k++) {
                    HighlightEffect effect = HighlightEffect.instances[k];
                    if (effect.isActiveAndEnabled) {
                        if ((effect.camerasLayerMask & camLayer) == 0) continue;
                        CommandBuffer cb = effect.GetCommandBuffer(cam, cameraColorTarget, cameraDepthTarget);
                        if (cb != null) {
                            context.ExecuteCommandBuffer(cb);
                        }
                    }
                }
            }

            /// Cleanup any allocated resources that were created during the execution of this render pass.
            public override void FrameCleanup(CommandBuffer cmd) {
            }
        }

        HighlightPass renderPass;
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        public static bool installed;


        void OnDisable() {
            installed = false;
        }

        public override void Create() {
            renderPass = new HighlightPass();
        }

        // This method is called when setting up the renderer once per-camera.
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) {
#if UNITY_2019_4_OR_NEWER
            if (renderingData.cameraData.renderType == CameraRenderType.Base) {
                Camera cam = renderingData.cameraData.camera;
                renderPass.usesCameraOverlay = cam.GetUniversalAdditionalCameraData().cameraStack.Count > 0;
            }
#endif
            renderPass.Setup(renderPassEvent, renderer);
            renderer.EnqueuePass(renderPass);
            installed = true;
        }
    }

}
