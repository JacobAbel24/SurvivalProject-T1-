using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Animator anim;
    int isRunningHash;

    PlayerInputs input;
    Vector2 currentMovement;
    bool runPressed = false;

    private void Awake()
    {
        input = new PlayerInputs();
        input.characterMovement.Movement.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            runPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
        moveCharacter();
        handleRotation();
    }

    void handleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLook = currentPosition + newPosition;
    }

    void moveCharacter()
    {
        bool isRunning = anim.GetBool(isRunningHash);
        if(runPressed && !isRunning)
        {
            anim.SetBool(isRunningHash, true);
        }
        if(!runPressed && isRunning)

        {
            anim.SetBool(isRunningHash, false);
        }
    }
    private void OnEnable()
    {
        input.characterMovement.Enable();
    }

    private void OnDisable()
    {
        input.characterMovement.Disable();
    }
}
