
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationRate;
    public TextMeshProUGUI countText;

    private InputActionMap actionMapKnight;
    private Rigidbody rb;
    private Animator anim;
    private int count;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        var inputAsset = new MainInput();
        actionMapKnight = inputAsset.PlayerKnight;
        actionMapKnight.Enable();
        count = 0;

        SetCountText();

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            // Add one to the score variable 'count'
            count = count + 5;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Coins: " + count.ToString();

    }
    }