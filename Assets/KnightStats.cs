using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour
{
    [SerializeField]
    private static int current_hp = 500;
    [SerializeField]
    private static int max_hp = 500;
    
    void Start()
    {
        HealthBarHandler.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        //dealDamage(1);
    }
    
    public static void dealDamage(int x)
    {
        current_hp -= x;
        HealthBarHandler.SetHealthBarValue(((float)current_hp)/max_hp);
        if (current_hp < 0) {
            //Game over
        }
    }
    
}
