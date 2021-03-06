﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightStats : MonoBehaviour
{
    [SerializeField]
    private static int current_hp = 100;
    [SerializeField]
    private static int max_hp = 100;
    private static int persuasion = 30;
    private static int bargaining = 10;
    private static int luck = 10;

    private static int coin = 0;
    private GameObject deathPanel;

    public static void setPersuasion(int value){
        persuasion = value;
    }

    public static int GetPersuasion(){
        return persuasion;
    }

    public static void setBargaining(int barg){
        bargaining = barg;
    }
    public static int GetBargaining(){
        return bargaining;
    }
    
    public static void setLuck(int luk){
        luck = luk;
    }
    public static int GetLuck(){
        return luck;
    }
    

    public static int GetCurrentHP(){
        return current_hp;
    }

    public static int getCoin(){
        return coin;
    }

    public static void setCoin(int newCoin){
        coin = newCoin;
    }

    void Start()
    {
        HealthBarHandler.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public static void dealDamage(int x)
    {
        current_hp -= x;
        HealthBarHandler.SetHealthBarValue(((float)current_hp)/max_hp);
        if (current_hp < 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }
    }
}

