using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : HealthController
{
    public int strength = 10;
    public int strBonus;


    override public void Start()
    {
        healthStart = 16;
        strBonus = 2 + ((strength - 10) / 2);

        ResetHealth();
    }
}
