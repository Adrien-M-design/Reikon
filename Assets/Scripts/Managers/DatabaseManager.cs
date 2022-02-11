
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
    [SerializeField] private CombatData[] _combatData = null;

    private Dictionary<string, AttackData> _charAttacks = null;
    private Dictionary<string, AttackData> _mobAttacks = null;
    private Dictionary<string, CombatData> _combats = null;
    private string _currentCombat = string.Empty;
    #endregion Fields

    #region Properties
    public Dictionary<string, AttackData> MobAttacks => _mobAttacks;
    public Dictionary<string, AttackData> CharAttacks => _charAttacks;
    public Dictionary<string, CombatData> Combats => _combats;
    public CombatData CurrentCombat => _combats[_currentCombat];
    #endregion Properties

    #region Methods
    /**
     * MUST BE CALLED ON START SCENE
    **/
    public void Initialize()
    {
        _charAttacks = new Dictionary<string, AttackData>();
        _mobAttacks = new Dictionary<string, AttackData>();
        _combats = new Dictionary<string, CombatData>();

        for (int i = 0; i < _mobAttData.Length; i++)
        {
            _mobAttacks.Add(_mobAttData[i].AttackID, _mobAttData[i]);
        }

        for (int i = 0; i < _charAttData.Length; i++)
        {
            _charAttacks.Add(_charAttData[i].AttackID, _charAttData[i]);
        }

        for (int i = 0; i < _combatData.Length; i++)
        {
            _combats.Add(_combatData[i].MobName, _combatData[i]);
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

    public int GetCharAttackDamage(string attackID)
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

    public int GetMobAttackDamage(string attackID)
    {
        return _mobAttacks[attackID].Damage;
    }

    public AttackData GetAttackByCombo(List<EAttackTypes> combo)
    {
        int counter = 0;
        foreach (KeyValuePair<string, AttackData> comboPair in _charAttacks)
        {
            for(int i = 0; comboPair.Value.Combo.Length > i; i++)
            {
                if(i < combo.Count)
                {
                    if (comboPair.Value.Combo[i] == combo[i])
                    {
                        counter++;
                    }

                    if (counter == combo.Count)
                    {
                        return comboPair.Value;
                    }
                }
            }

        }
        Debug.LogError("Combo Not Found : " + combo);
        return null;
    }
    #endregion Getters

    #region Setters
    public void SetCurrentCombat(string mobName)
    {
        _currentCombat = mobName;
    }
    #endregion Setters
    #endregion Methods
}
