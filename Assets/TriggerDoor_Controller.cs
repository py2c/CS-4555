using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator MyDoor = null;
    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {  
        if (other.CompareTag("Player"))
        {
           if (openTrigger)
            {
                MyDoor.Play("Door open", 0, 0.0f);
                gameObject.SetActive(false);

            }


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
