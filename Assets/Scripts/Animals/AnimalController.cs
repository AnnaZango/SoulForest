using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CharacterController))]
public class AnimalController : MonoBehaviour
{
    [SerializeField] Vector3 movementDirection; 
    private CharacterController characterController;
    [SerializeField] Vector3 playerVelocity;

    [SerializeField] Transform playerTransformOnRide;
    [SerializeField] Transform playerTransformOffRide;

    Transform transformMainCam;
    [SerializeField] float speed = 3;
    [SerializeField] float gravity = -30f;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float jumpHeight = 5;

    [SerializeField] bool isGrounded = true;
    [SerializeField] bool isRidingEnabled = false;
    [SerializeField] float thresholdTrust = 0.7f;

    AnimalBehavior animalBehavior;
    BehaviorTree behaviorTree;
    RotateObject rotationAnimal;
    DamageFront damageFront;
    NavMeshAgent agent;
    Animator animator;

    [SerializeField] AudioSource runSound;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animalBehavior = GetComponent<AnimalBehavior>();
        rotationAnimal = GetComponent<RotateObject>();
        behaviorTree = GetComponent<BehaviorTree>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();   
        damageFront = GetComponentInChildren<DamageFront>();
        transformMainCam = Camera.main.transform;
    }

    void Start()
    {
        isRidingEnabled = false;
    }

    
    void Update()
    {
        isGrounded = characterController.isGrounded;        
    }

    public void EnableAnimalDriving()
    {
        if (animalBehavior.TrustLevel >= thresholdTrust)
        {
            isRidingEnabled = true;
            animator.SetInteger("state", 4);
            //The opposite for components related to autonomous movement:
            behaviorTree.enabled = false;
            rotationAnimal.DisableRotation();
            rotationAnimal.enabled = false;
            agent.enabled = false;
            animalBehavior.enabled = false;
        }
    }

    public void DisableAnimalDriving()
    {
        isRidingEnabled = false;

        //The opposite for components related to autonomous movement:
        animalBehavior.enabled = true;
        behaviorTree.enabled = true;
        rotationAnimal.enabled = true;
        agent.enabled = true;
    }



    public void ProcessMovement(Vector2 input)
    {
        if(!isRidingEnabled) { return; }
        if (GameManager.IsPlayerDead) { return; }

        ApplyMovement(input);

        ApplyGravity();

        RotatePlayerTowardsCamera();

        //ProcessWalkingAnimations(currentAnimationBlendVector);
    }

    private void ApplyMovement(Vector2 input)
    {
        movementDirection = Vector3.zero;

        movementDirection = new Vector3(input.x, 0, input.y);

        //take into accound camera direction to decide player direction. When we move left or right (x axis) it takes into account what the
        //right axis of the camera is; and the same for the forward
        movementDirection = movementDirection.x * transformMainCam.right.normalized + movementDirection.z * transformMainCam.forward.normalized;
        movementDirection.y = 0;

        characterController.Move(movementDirection * speed * Time.deltaTime);
        if (Vector3.Distance(movementDirection, Vector3.zero) > 0.15f)
        {
            animator.SetInteger("state", 4);
            if (!damageFront.GetIfColliderEnabled()) { damageFront.EnableCollider(); }

            if (!runSound.isPlaying)
            {
                runSound.Play();
            }
        }
        else
        {
            animator.SetInteger("state", 4);
            if (damageFront.GetIfColliderEnabled()) { damageFront.DisableCollider(); }
            
            if (runSound.isPlaying)
            {
                runSound.Stop();
            }
        }

        
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
            animator.SetTrigger("jump");
        }
    }

    public bool GetIfDomesticated()
    {
        return animalBehavior.TrustLevel >= thresholdTrust;
    }

   
    public Transform GetPlayerTransformRiding()
    {
        return playerTransformOnRide;
    }

    public Transform GetPlayerTransformLeave()
    {
        return playerTransformOffRide;
    }

    private void ApplyGravity()
    {
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; //small downward force if grounded
        }
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void RotatePlayerTowardsCamera()
    {
        Quaternion targetRotation = Quaternion.Euler(0, transformMainCam.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

}
