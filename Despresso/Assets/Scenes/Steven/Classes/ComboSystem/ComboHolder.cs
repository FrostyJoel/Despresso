using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHolder : MonoBehaviour
{
    public string lightSlashInput;
    public string heavySlashInput;

    public Slash curSlash;

    public Slash lightSlash;
    public Slash heavySlash;

    public bool inCombo;

    public AttackInput lightAttackInputPressed;
    public AttackInput heavyAttackInputPressed;

    public void Update()
    {
        InputCheck();
    }

    public void InputCheck()
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
                curSlash = lightSlash;
                NewAttack(curSlash);
            }

            if (Input.GetButtonDown(heavySlashInput))
            {
                curSlash = heavySlash;
                NewAttack(curSlash);
            }
        }
    }

    public void NewAttack(Slash slash)
    {
        curSlash.NewAttack(this, lightSlash);
    }

}
    public enum AttackInput
    {
        lightAttack,
        heavyAttack
    }
