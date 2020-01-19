using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesAttack : MonoBehaviour
{
    public List<GameObject> enemys;

    public bool didAttack;

    public void DoDamage(Slash slash)
    {
        if(enemys != null)
        {
            for (int i = 0; i < enemys.Count; i++)
            {   
                enemys[i].GetComponent<EnemyInfo>().AdjustHealth(slash.damage);
            }

            didAttack = true;
        }     
    }

    public void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            enemys.Add(c.gameObject);
        }
    }

    public void OnTriggerExit(Collider c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            enemys.Remove(c.gameObject);
        }
    }
}
