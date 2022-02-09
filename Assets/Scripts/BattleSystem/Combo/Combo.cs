using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Combo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("FIRE"))
        {
            RegisterInput(DatabaseManager.EAttackTypes.FIRE);
        }

        if (Input.GetButtonDown("WATER"))
        {
            RegisterInput(DatabaseManager.EAttackTypes.WATER);
        }

        if (Input.GetButtonDown("WOOD"))
        {
            RegisterInput(DatabaseManager.EAttackTypes.WOOD);
        }

        if (Input.GetButtonDown("VALIDATE"))
        {
            ValidateInputs();
        }

    }

    public static List<DatabaseManager.EAttackTypes> InputArray = new List<DatabaseManager.EAttackTypes>();

    public static void RegisterInput(DatabaseManager.EAttackTypes attackType)
    {
        if (InputArray.Count >= 3)
        {
            return; // ignore if filled
        }

        InputArray.Add(attackType);

        //cbecker dernier valid
        //if(!CheckLastInputPossible());
        // if unvalid:
            //InputArray.RemoveAt(InputArray.Count - 1);

        
    }

    private static bool CheckLastInputPossible()
    {
        // check array vs moves possibles
        // si inexistant retourne faux
        return false;
    }

    private static void ValidateInputs()
    {
        // check if a combo
        DatabaseManager.Instance.GetAttackByCombo(InputArray);

        // run combo

        InputArray.Clear();
    }
}
