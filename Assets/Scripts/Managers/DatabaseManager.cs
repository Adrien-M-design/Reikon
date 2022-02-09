
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    #region Attacks
    public enum EAttackTypes
    {
        FIRE,
        WOOD,
        WATER
    };

    /**
     * ADD NEW EFFECTS HERE
    **/
    public enum ECombatEffects
    {
        UPSPEED,
        DOWNSPEED,
        DOT,
        SHIELDED,
        NONE
    };
    #endregion Attacks

    #region Fields
    [SerializeField] private AttackData[] _mobAttData = null;
    [SerializeField] private AttackData[] _charAttData = null;

    private Dictionary<string, AttackData> _charAttacks = null;
    private Dictionary<string, AttackData> _mobAttacks = null;
    #endregion Fields

    #region Properties
    public Dictionary<string, AttackData> MobAttacks => _mobAttacks;
    public Dictionary<string, AttackData> CharAttacks => _charAttacks;
    #endregion Properties

    #region Methods
    /**
     * MUST BE CALLED ON START SCENE
    **/
    public void Initialize()
    {
        for (int i = 0; i < _mobAttData.Length; i++)
        {
            _mobAttacks.Add(_mobAttData[i].AttackID, _mobAttData[i]);
        }

        for (int i = 0; i < _charAttData.Length; i++)
        {
            _mobAttacks.Add(_charAttData[i].AttackID, _charAttData[i]);
        }
    }

    #region Getters
    /**
     * SHORTCUTS TO SPECIFIC DATA
    **/


    public EAttackTypes GetCharAttackType(string attackID)
    {
        return _charAttacks[attackID].AttackType;
    }

    public ECombatEffects GetCharAttackCombatEffect(string attackID)
    {
        return _charAttacks[attackID].CombatEffect;
    }

    public float GetCharAttackDamage(string attackID)
    {
        return _charAttacks[attackID].Damage;
    }

    public EAttackTypes GetMobAttackType(string attackID)
    {
        return _mobAttacks[attackID].AttackType;
    }

    public ECombatEffects GetMobAttackCombatEffect(string attackID)
    {
        return _mobAttacks[attackID].CombatEffect;
    }

    public float GetMobAttackDamage(string attackID)
    {
        return _mobAttacks[attackID].Damage;
    }

    public AttackData GetAttackByCombo(List<EAttackTypes> combo)
    {
        foreach (KeyValuePair<string, AttackData> comboPair in _charAttacks)
        {
            if (comboPair.Value.Combo == combo.ToArray())
            {
                return comboPair.Value;
            }
        }
        return null;
    }
    #endregion Getters
    #endregion Methods
}
