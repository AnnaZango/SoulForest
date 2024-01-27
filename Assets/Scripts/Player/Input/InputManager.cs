using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //We channel all our inputs through here

    private PlayerControls inputActions;
    private PlayerControls.OnGroundActions groundActions;
    private PlayerController playerController;
    private PlayerShooting playerShooting;
    private SweetsStorer sweetsStorer;
    [SerializeField] SwitchVCams camsSwitch;
    WeaponsController weaponsController;

    private PlayerControls.OnAnimalActions animalActions;
    AnimalController animalController;
    AnimalController[] animalControllers;
    ControlSwitcher controlSwitcher;
    Pause pause;


    [SerializeField] Vector2 inputLook;
    [SerializeField] bool isRiding = false;

    void Awake()
    {
        CastReferences();

        SetOnGroundActions();
        SetOnAnimalActions();
    }

    private void CastReferences()
    {
        // REFERENCES 
        inputActions = new PlayerControls();
        groundActions = inputActions.OnGround;
        playerController = FindObjectOfType<PlayerController>();
        sweetsStorer = FindObjectOfType<SweetsStorer>();
        playerShooting = FindObjectOfType<PlayerShooting>();
        weaponsController = FindObjectOfType<WeaponsController>();
        pause = FindObjectOfType<Pause>();
        controlSwitcher = FindObjectOfType<ControlSwitcher>();
        animalControllers = FindObjectsOfType<AnimalController>();
    }

    private void SetOnAnimalActions()
    {
        //ANIMAL ACTIONS
        animalActions = inputActions.OnAnimal;
        foreach (AnimalController animal in animalControllers)
        {
            animalActions.Jump.performed += ctx => animal.Jump();
        }
        animalActions.LeaveAnimal.performed += ctx => controlSwitcher.SwitchControls();

        animalActions.Shoot.performed += ctx => playerShooting.ProcessShooting();
        animalActions.Aim.started += _ => camsSwitch.StartAiming();
        animalActions.Aim.canceled += _ => camsSwitch.StopAiming();
        animalActions.SwitchWeapon.performed += ctx => weaponsController.SwitchWeapons();
        animalActions.Pause.performed += ctx => pause.PauseMode();
    }

    private void SetOnGroundActions()
    {
        // GROUND ACTIONS (KODAMA CHARACTER)
        groundActions.Jump.started += ctx => playerController.AddJumpToQueue();
        groundActions.Jump.canceled += ctx => playerController.JumpFinished();
        groundActions.Dash.performed += ctx => playerController.Dash();
        groundActions.Shoot.performed += ctx => playerShooting.ProcessShooting();
        groundActions.Aim.started += _ => camsSwitch.StartAiming();
        groundActions.Aim.canceled += _ => camsSwitch.StopAiming();
        groundActions.SwitchWeapon.performed += ctx => weaponsController.SwitchWeapons();
        groundActions.Pause.performed += ctx => pause.PauseMode();
        groundActions.RideAnimal.performed += ctx => controlSwitcher.SwitchControls();
        groundActions.DropFood.performed += ctx => sweetsStorer.DropSweets();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        groundActions.Enable();
    }

    private void OnDisable()
    {
        groundActions.Disable();
    }

    public void SetIsDrivingAnimal(bool isOnAnimal)
    {
        isRiding = isOnAnimal;
        if(isOnAnimal) // we enable and disable action maps, or both active!
        {
            animalActions.Enable();
            groundActions.Disable();
        }
        else
        {
            groundActions.Enable();
            animalActions.Disable();
        }
    }

    public void SetAnimalController(AnimalController animalToRide)
    {
        animalController = animalToRide;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked) 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }            
        }

        if(isRiding) 
        {
            if(animalController != null)
            {
                playerController.GetComponent<CharacterController>().enabled = false;
                animalController.ProcessMovement(animalActions.Movement.ReadValue<Vector2>());
                inputLook = animalActions.Look.ReadValue<Vector2>();
            }
        }
        else
        {
            playerController.ProcessMovement(groundActions.Movement.ReadValue<Vector2>());
            inputLook = groundActions.Look.ReadValue<Vector2>();
        }
    }

    
}
