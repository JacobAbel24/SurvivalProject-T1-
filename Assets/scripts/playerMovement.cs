using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Animator anim;
    CharacterController characterController;
    player player;
    int isRunningHash;
    [SerializeField]
    int runSpeed = 3;

    PlayerControls input;
    Vector2 currentMovement;
    Vector3 movement;
    bool runPressed = false;
    public float rotateValue;

    private void Awake()
    {
        input = new PlayerControls();
        input.playerMovementMap.Movement.performed += MovementFunction;
        input.playerMovementMap.Movement.canceled += MovementFunction;
    }

    private void MovementFunction(InputAction.CallbackContext ctx)
    {
        currentMovement = ctx.ReadValue<Vector2>();
        runPressed = currentMovement.x != 0 || currentMovement.y != 0;
        movement = new Vector3(currentMovement.x, 0, currentMovement.y);
    }


    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
            MoveCharacter();
            HandleRotation();
    }


    void MoveCharacter()
    {
       characterController.Move(movement * runSpeed * Time.deltaTime);
       anim.SetBool(isRunningHash, runPressed);

    }

    void HandleRotation()
    {
        Vector3 posToLook = new Vector3(movement.x, 0, movement.z);
        Quaternion rotation = transform.rotation;
        if (runPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(posToLook);
            transform.rotation = Quaternion.Slerp(rotation,targetRotation,rotateValue * Time.deltaTime);
        }

    }


    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}