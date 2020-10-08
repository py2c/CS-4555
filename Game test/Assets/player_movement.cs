using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_movement : MonoBehaviour
{
    Animator anim;
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 180;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Idle");
        }

        float turnAxis = Input.GetAxis(turnInputAxis);
        ApplyInput(turnAxis);
    }

    private void ApplyInput(float turnInput)
    {

        Turn(turnInput);
    }

    private void Turn (float input)
    {

        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);

    }
}
