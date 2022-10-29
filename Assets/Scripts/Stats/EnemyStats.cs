using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : HealthController
{
    override public void Start()
    {
        healthStart = 10;

        ResetHealth();
    }
}
