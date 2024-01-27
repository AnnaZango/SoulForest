using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ControlSwitcher : MonoBehaviour
{
    [SerializeField] CharacterController playerCharacterController;
    [SerializeField] GameObject player;
    PlayerController playerController;

    AnimalDetector animalDetector;
    InputManager inputManager;

    PlayerInput playerInput;
    [SerializeField] CinemachineVirtualCamera virtualCameraNormal;
    [SerializeField] CinemachineVirtualCamera virtualCameraAim;
    [SerializeField] CinemachineInputProvider inputProviderNormal;
    [SerializeField] CinemachineInputProvider inputProviderAim;
    [SerializeField] InputActionReference lookOnAnimal;
    [SerializeField] InputActionReference lookOnGround;

    AnimalController currentAnimal;

    bool isRidingAnimal = false;

    //Sounds
    [SerializeField] AudioSource soundRide;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputManager = GetComponent<InputManager>();

        animalDetector = FindObjectOfType<AnimalDetector>();
        playerController = FindObjectOfType<PlayerController>();
    }
    

    public void SwitchControls()
    {
        if (isRidingAnimal)
        {
            SwitchControlToPlayer(currentAnimal);
        }
        else
        {
            if (animalDetector.GetIfDomesticatedAnimalInRange())
            {
                SwitchControlToAnimal(animalDetector.GetDomesticatedAnimalToRide());
            }
        }
    }

    

    private void SwitchControlToPlayer(AnimalController animalToLeave)
    {
        if (!animalToLeave.IsGrounded()) { return; } //you can only leave an animal when it's grounded

        // Disable character controller in animal and riding in AnimalController
        animalToLeave.GetComponent<CharacterController>().enabled = false;
        animalToLeave.DisableAnimalDriving();

        // Enable character controller in player
        playerCharacterController.enabled = true;
        playerController.SetRidingAnimal(false);

        // Change action map
        playerInput.SwitchCurrentActionMap("OnGround");
       
        //Tell InputManager that controls have switched
        inputManager.SetIsDrivingAnimal(false);
        inputManager.SetAnimalController(null);

        //Move player and set cameras
        MovePlayerToSide(animalToLeave.GetPlayerTransformLeave());
        ChangeTargetAndInputCamera(player.gameObject.transform, lookOnGround);

        isRidingAnimal = false;

        soundRide.Play();
    }


    private void SwitchControlToAnimal(AnimalController animalToRide)
    {
        currentAnimal = animalToRide;

        // Disable character controller in kodama
        playerCharacterController.enabled = false;
        playerController.SetRidingAnimal(true);

        // Change action map
        playerInput.SwitchCurrentActionMap("OnAnimal");

        // Enable character controller in animal and riding in AnimalController        
        animalToRide.GetComponent<CharacterController>().enabled = true;
        animalToRide.EnableAnimalDriving();

        //Tell InputManager that controls have switched
        inputManager.SetIsDrivingAnimal(true);
        inputManager.SetAnimalController(animalToRide);

        //Move player and set cameras
        MovePlayerToAnimal(animalToRide.GetPlayerTransformRiding());
        ChangeTargetAndInputCamera(animalToRide.gameObject.transform, lookOnAnimal);

        isRidingAnimal = true;

        soundRide.Play();
    }

    private void ChangeTargetAndInputCamera(Transform transformToFollow, InputActionReference lookAction)
    {
        //only the third person camera follows the animal, as aiming is better from player's perspective
        virtualCameraNormal.Follow = transformToFollow;
        virtualCameraNormal.LookAt = transformToFollow;

        inputProviderNormal.XYAxis = lookAction;
        inputProviderAim.XYAxis = lookAction;
    }

    private void MovePlayerToAnimal(Transform playerInAnimalTransform)
    {
        player.transform.SetParent(playerInAnimalTransform);
        player.transform.position = playerInAnimalTransform.position;
        player.transform.rotation = playerInAnimalTransform.rotation;
    }

    private void MovePlayerToSide(Transform sidePosition)
    {
        player.transform.position = sidePosition.position;
        player.transform.SetParent(null);
    }
}
