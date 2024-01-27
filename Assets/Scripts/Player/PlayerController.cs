using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] Vector3 playerVelocity;
    [SerializeField] GameObject animalDetector;

    [SerializeField] Vector3 movementDirection;
    [SerializeField] float speed = 7;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float dashTime = 0.3f;
    [SerializeField] float knockbackTime = 0.17f;
    [SerializeField] float dashSpeed = 20;

    [SerializeField] float coyoteTimeJump = 0.5f;
    [SerializeField] float coyoteTimeCounter;

    [SerializeField] bool isGrounded = true;

    private Transform transformMainCam;

    Animator animator;
    int moveXanimationParameter;
    int moveZanimationParameter;
    int jumpParameter;
    int dashParameter;

    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;
    [SerializeField] float animationSmoothTime = 0.05f;

    Queue<int> jumpInputQueue = new Queue<int>();
    [SerializeField] int itemsInQueue = 0;
    [SerializeField] float inputBufferTime = 0.5f;

    [SerializeField] bool isDashing = false;
    Coroutine dashCoroutine;

    [SerializeField] Vector3 dashDirection;


    [Header("Sounds")]
    [SerializeField] AudioSource walkSound;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource dashSound;

    [SerializeField] bool isRidingAnimal = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        transformMainCam = Camera.main.transform;
        moveXanimationParameter = Animator.StringToHash("MoveX");
        moveZanimationParameter = Animator.StringToHash("MoveZ");
        jumpParameter = Animator.StringToHash("Jump");
        dashParameter = Animator.StringToHash("Dash");
    }

    

    void Update()
    {
        if(isRidingAnimal) { return; }

        if (GameManager.IsPlayerDead) { return; }

        isGrounded = characterController.isGrounded;

        if(isGrounded)
        {
            coyoteTimeCounter = coyoteTimeJump;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(itemsInQueue > 0)
        {
            ProcessJumpInputQueue();
        }
    }

    private void ProcessJumpInputQueue()
    {
        if (jumpInputQueue.Peek() == 1)
        {
            if (coyoteTimeCounter > 0)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);                
                animator.CrossFade(jumpParameter, animationSmoothTime);
                jumpInputQueue.Dequeue();
                itemsInQueue = jumpInputQueue.Count;
            }
        }
        else if (jumpInputQueue.Peek() == 2)
        {
            playerVelocity.y -= Mathf.Sqrt(jumpHeight * -3 * gravity * 0.1f);
            coyoteTimeCounter = 0;
            jumpInputQueue.Dequeue();
            itemsInQueue = jumpInputQueue.Count;
        }
    }

    //Receives the input from the InputManager and proceeds to process the actual movement of the player 
    public void ProcessMovement(Vector2 input)
    {
        if (GameManager.IsPlayerDead) { return; }

        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);

        ApplyMovement(currentAnimationBlendVector);

        ApplyGravity();

        RotatePlayerTowardsCamera();

        ProcessWalkingAnimations(currentAnimationBlendVector);
    }

    public void AddJumpToQueue() //to allow input buffer
    {
        if(isRidingAnimal) { return; }

        jumpInputQueue.Enqueue(1);
        itemsInQueue = jumpInputQueue.Count;
        Invoke(nameof(DequeueJump), inputBufferTime);
        jumpSound.Play();
    }

    public void JumpFinished()
    {
        jumpInputQueue.Enqueue(2);
        itemsInQueue = jumpInputQueue.Count;
    }

    public void Dash()
    {
        if (GameManager.IsPlayerDead) { return; }

        if (isDashing) { return; }
        dashSound.Play();
        dashCoroutine = StartCoroutine(nameof(DashCoroutine));
        animator.CrossFade(dashParameter, 0);
    }

    public void SetRidingAnimal(bool isRiding)
    {
        isRidingAnimal = isRiding;
        if(isRiding)
        {
            animator.SetBool("Drive", true);
            animalDetector.SetActive(false);
        }
        else
        {
            animator.SetBool("Drive", false);
            animalDetector.SetActive(true);
        }
    }

    private void DequeueJump()
    {
        if(jumpInputQueue.Count > 0)
        {
            jumpInputQueue.Dequeue();
            itemsInQueue = jumpInputQueue.Count;
        }        
    }

    IEnumerator DashCoroutine()
    {   
        float startTime = Time.time; // to set time to dash
        while (Time.time < startTime + dashTime)
        {
            isDashing = true;
            if(Vector3.Distance(movementDirection, Vector3.zero) < 0.15f)
            {
                characterController.Move(transform.forward * dashSpeed * Time.deltaTime);
                dashDirection = transform.forward;
            }
            else
            {
                characterController.Move(movementDirection * dashSpeed * Time.deltaTime);
                dashDirection = movementDirection;
            }

            CheckIfCollidedWithSomething(dashDirection);

            yield return null; 
        }
        isDashing = false;
    }
        
    

    private void ProcessWalkingAnimations(Vector2 inputReceived)
    {
        animator.SetFloat(moveXanimationParameter, inputReceived.x);
        animator.SetFloat(moveZanimationParameter, inputReceived.y);
    }

    private void ApplyMovement(Vector2 input)
    {
        if(isDashing) { return; } //when dashing, fixed direction

        movementDirection = Vector3.zero;

        movementDirection = new Vector3(input.x, 0, input.y);

        //take into accound camera direction to decide player direction. When we move left or right (x axis) it takes into account what the
        //right axis of the camera is; and the same for the forward
        movementDirection = movementDirection.x * transformMainCam.right.normalized + movementDirection.z * transformMainCam.forward.normalized;
        movementDirection.y = 0;

        characterController.Move(movementDirection * speed * Time.deltaTime);

        if (Vector3.Distance(movementDirection, Vector3.zero) > 0.15f)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            if (walkSound.isPlaying)
            {
                walkSound.Stop();
            }
        }

        SetPlayerAimRig();
    }

    private void SetPlayerAimRig()
    {
        //aimTarget.position = transformMainCam.position + transformMainCam.forward * aimDistanceRigging;
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

    public bool IsPlayerDashing()
    {
        return isDashing;
    }

    
    private void CheckIfCollidedWithSomething(Vector3 direction)
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            ProcessDashHit(direction);
            if (hit.transform.gameObject.GetComponent<EnemyHealth>())
            {
                hit.transform.gameObject.GetComponent<EnemyHealth>().ReceiveDamage(1);
            }
        }
    }

    private void ProcessDashHit(Vector3 direction)
    {
        if(dashCoroutine == null) { return; }
        StopCoroutine(dashCoroutine);
        characterController.Move(Vector3.zero);
        isDashing = false;
        
        StartCoroutine(KnockbackCoroutine(direction));
    }

    IEnumerator KnockbackCoroutine(Vector3 direction)
    {
        float startTime = Time.time;
        while (Time.time < startTime + knockbackTime)
        {
            characterController.Move(-direction * dashSpeed/1.5f * Time.deltaTime);
            yield return null;
        }
    }


}
