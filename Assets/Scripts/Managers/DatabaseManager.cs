
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
    [SerializeField] private DialData[] _dialData = null;
    [SerializeField] private SpriteData[] _spriteData = null;
    [SerializeField] private TalismanData[] _talismanData = null;
   

    private Dictionary<string, AttackData> _charAttacks = null;
    private Dictionary<string, AttackData> _mobAttacks = null;
    private Dictionary<string, CombatData> _combats = null;
    private Dictionary<string, DialData> _dialogues = null;
    private Dictionary<EAttackTypes, Sprite> _sprites = null;
    private Dictionary<string, TalismanData> _talismans = null;
    private string _currentCombat = string.Empty;
    #endregion Fields

    #region Properties
    public Dictionary<string, AttackData> MobAttacks => _mobAttacks;
    public Dictionary<string, AttackData> CharAttacks => _charAttacks;
    public Dictionary<string, CombatData> Combats => _combats;
    public Dictionary<string, DialData> Dialogues => _dialogues;
    public Dictionary<EAttackTypes, Sprite> Sprites => _sprites;
    public Dictionary<string, TalismanData> Talismans => _talismans;
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
        _dialogues = new Dictionary<string, DialData>();
        _sprites = new Dictionary<EAttackTypes, Sprite>();
        _talismans = new Dictionary<string, TalismanData>();

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

        for (int i = 0; i < _dialData.Length; i++)
        {
            _dialogues.Add(_dialData[i].ID, _dialData[i]);
        }

        for (int i = 0; i < _spriteData.Length; i++)
        {
            _sprites.Add(_spriteData[i].AttackType, _spriteData[i].Sprite);
        }

        for (int i = 0; i < _talismanData.Length; i++)
        {
            _talismans.Add(_talismanData[i].TalismanID, _talismanData[i]);
        }
    }

    #region Getters
    /**
     * SHORTCUTS TO SPECIFIC DATA
    **/



    public ECombatEffects GetCharAttackCombatEffect(string attackID)
    {
        return _charAttacks[attackID].CombatEffect;
    }

    public int GetCharAttackDamage(string attackID)
    {
        return _charAttacks[attackID].Damage;
    }

    public ECombatEffects GetMobAttackCombatEffect(string attackID)
    {
        return _mobAttacks[attackID].CombatEffect;
    }

    public int GetMobAttackDamage(string attackID)
    {
        return _mobAttacks[attackID].Damage;
    }

    public Sprite GetSpriteByType(EAttackTypes type)
    {
        return _sprites[type];
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
            counter = 0;
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
