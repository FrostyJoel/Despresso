using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHolder : MonoBehaviour
{
    public float time;

    public bool inCombo;
    public bool ableToAttack;

    public DoesAttack doesAttack;

    public Slash curSlash;
    public Slash lightSlash;
    public Slash heavySlash;
    public string lightSlashInput;
    public string heavySlashInput;
    public DirectionalInput directionalInput;

    public void Update()
    {
        InputCheck();

        DirectionalInputCheck();

        if (curSlash != null && inCombo)
        {
            Timer(curSlash.animTimer, curSlash.maxTimer);
        }
    }

    public void NewAttack(Slash slash)
    {
        curSlash = slash;

        slash.NewAttack(this, slash);
    }

    public void InputCheck()
    {
        if (ableToAttack)
        {
            if (inCombo)
            {
                if (Input.GetButtonDown(lightSlashInput))
                {
                    curSlash.ContinueAttack(this, lightSlash, AttackInput.lightAttack, directionalInput);
                }
                else if (Input.GetButtonDown(heavySlashInput))
                {
                    curSlash.ContinueAttack(this, heavySlash, AttackInput.heavyAttack, directionalInput);
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

    public void DirectionalInputCheck()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            directionalInput = DirectionalInput.forward;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            directionalInput = DirectionalInput.back;
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            directionalInput = DirectionalInput.right;
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            directionalInput = DirectionalInput.left;
        }

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            directionalInput = DirectionalInput.neutral;
        }
    }


    public void Timer(float animTimer, float maxTimer)
    {
        if(time < maxTimer)
        {
            ableToAttack = false;

            time += Time.deltaTime;

            if (time > animTimer)
            {
                if(doesAttack.didAttack == false)
                {
                    doesAttack.DoDamage(curSlash);
                }
                ableToAttack = true;
            }
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

    public enum DirectionalInput
    {
        none,
        neutral,
        forward,
        back,
        left,
        right
    }
