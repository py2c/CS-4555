using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    Animator anim;
    private const string turnInputAxis = "Horizontal";
    [SerializeField]
    private float rotationRate = 180.0f;
    
    private InputActionMap actionMapKnight;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        var inputAsset = InputActionAsset.FromJson(System.IO.File.ReadAllText(@"Assets\MainInput.inputactions"));
        actionMapKnight = inputAsset.FindActionMap("PlayerKnight", true);
        actionMapKnight.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var movementAction = actionMapKnight.FindAction("Movement",true);
        
        ApplyInput(movementAction.ReadValue<Vector2>());
    }
    
    private void ApplyInput(Vector2 movementInput)
    {
        if (movementInput.y != 0) {
            anim.ResetTrigger("Idle");
            anim.SetTrigger("Walk");
        } else {
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
        }
        Turn(movementInput.x);
    }

    private void Turn (float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
