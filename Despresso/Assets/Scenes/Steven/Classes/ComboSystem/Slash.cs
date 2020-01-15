using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Slash"), menuName = "Slash/New Slash")]
public class Slash : ScriptableObject
{
    public List<Slash> combos;

    public int damage;

    public AttackInput attackInput;

    public virtual void NewAttack(ComboHolder comboHolder, Slash slash)
    {
        comboHolder.curSlash = slash;

        comboHolder.inCombo = true;

        Debug.Log(comboHolder.curSlash.damage);
    }

    public virtual void ContinueAttack(AttackInput attack, ComboHolder combo, Slash slash)
    {
        for(int i = 0; i < combos.Count; i++)
        {
            if(attack == combos[i].attackInput)
            {
                NewAttack(combo, combos[i]);
                return;
            }
        }

        NewAttack(combo, slash);
    }
}
