using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public GameObject me;

    public int health;

    public void AdjustHealth(int i)
    {
        health -= i;

        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
