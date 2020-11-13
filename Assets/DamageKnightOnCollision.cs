using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageKnightOnCollision : MonoBehaviour
{
    [SerializeField]
    private int damageValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            KnightStats.dealDamage(damageValue);
        }
    }
}
