
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationRate;

    private InputActionMap actionMapKnight;
    private Rigidbody rb;
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        var inputAsset = new MainInput();
        actionMapKnight = inputAsset.PlayerKnight;
        actionMapKnight.Enable();
    }

    private void FixedUpdate()
    {
        var movementAction = actionMapKnight.FindAction("Movement", true);
        ApplyInput(movementAction.ReadValue<Vector2>());
    }

    private void ApplyInput(Vector2 movementInput)
    {
        if (movementInput.y > 0.5)
        {
            anim.ResetTrigger("Idle");
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Run");
        }
        else if (movementInput.y > 0)
        {
            anim.ResetTrigger("Idle");
            anim.ResetTrigger("Run");
            anim.SetTrigger("Walk");
        }
        else
        {
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Run");
            anim.SetTrigger("Idle");
        }

        rb.AddRelativeForce(0, 0, movementInput.y * speed * Time.deltaTime, ForceMode.Impulse);

        Turn(movementInput.x);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

}