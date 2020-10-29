using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    Animator anim;
    //public float speed = 0;
    [SerializeField]
    private float rotationRate = 180.0f;
    private float movementX;
    private float movementY;
    
    private InputActionMap actionMapKnight;
    private Rigidbody rb;

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
        var movementAction = actionMapKnight.FindAction("Movement",true);
        ApplyInput(movementAction.ReadValue<Vector2>());
    }
    
    private void ApplyInput(Vector2 movementInput)
    {
        if (movementInput.y > 0) {
            anim.ResetTrigger("Idle");
            anim.SetTrigger("Walk");
        } else {
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
        }

        Turn(movementInput.x);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }


    // This is for the Blue cubes that act as pick up items .. coins,swords etc...
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            UnityEngine.Debug.Log("item picked up");
            other.gameObject.SetActive(false);
        }
       
    }

}
