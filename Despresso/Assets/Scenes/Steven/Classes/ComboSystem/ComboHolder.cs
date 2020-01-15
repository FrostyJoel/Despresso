using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHolder : MonoBehaviour
{
    public float time;

    public bool inCombo;
    public bool ableToAttack;

    public Slash curSlash;
    public Slash lightSlash;
    public Slash heavySlash;
    public string lightSlashInput;
    public string heavySlashInput;
    public AttackInput lightAttackInputPressed;
    public AttackInput heavyAttackInputPressed;

    public void Update()
    {
        InputCheck();

        if(curSlash != null && inCombo)
        {
            Timer(curSlash.animTimer, curSlash.maxTimer);
        }
    }

    public void InputCheck()
    {
        if (ableToAttack)
        {
            if (inCombo)
            {
                if (Input.GetButtonDown(lightSlashInput))
                {    
                    curSlash.ContinueAttack(lightAttackInputPressed, this, lightSlash);
                }
                else if (Input.GetButtonDown(heavySlashInput))
                {
                    curSlash.ContinueAttack(heavyAttackInputPressed, this, heavySlash);
                }
            }
            else
            {
                if (Input.GetButtonDown(lightSlashInput))
                {
                    NewAttack(lightSlash);
                }

                if (Input.GetButtonDown(heavySlashInput))
                {
                    NewAttack(heavySlash);
                }
            }
        }
    }

    public void NewAttack(Slash slash)
    {
        curSlash = slash;

        slash.NewAttack(this, slash);
    }

    public void Timer(float animTimer, float maxTimer)
    {
        if(time < maxTimer)
        {
            ableToAttack = false;

            time += Time.deltaTime;

            if (time > animTimer && time < maxTimer)
            {
                ableToAttack = true;
            }
            else ableToAttack = false;
        }
        else
        {
            time = 0;
            ableToAttack = true;
            inCombo = false;
        }
    }

}
    public enum AttackInput
    {
        lightAttack,
        heavyAttack
    }
