using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform = null;
    [SerializeField] private Transform _ennemyTransform = null;
    [SerializeField] private GameObject _floattingTextPrefab = null;
    [SerializeField] private Slider _playerSlider = null;
    private CombatData _combatData = null;

    private int _charHp = 100;
    private int _mobHp = 100;

    private Dictionary<DatabaseManager.ECombatEffects, int> _characterEffects;
    private Dictionary<DatabaseManager.ECombatEffects, int> _ennemyEffects;

    public int CharHp
    {
        get
        {
            return _charHp;
        }
        set
        {
            _charHp = value;
            _charHp = Mathf.Clamp(_charHp, 0, CharacterManager.Instance.CharHp);
        }
    }

    public int MobHp
    {
        get
        {
            return _mobHp;
        }
        set
        {
            _mobHp = value;
            _mobHp = Mathf.Clamp(_mobHp, 0, _combatData.MobHp);
        }
    }

    public Dictionary<DatabaseManager.ECombatEffects, int> CharacterEffects;
    public Dictionary<DatabaseManager.ECombatEffects, int> EnnemyEffects;

    // Start is called before the first frame update
    void Start()
    {
        //_combatData = DatabaseManager.Instance.CurrentCombat;
        _combatData = DatabaseManager.Instance.Combats["Test"];
        _charHp = CharacterManager.Instance.CharHp;
        _mobHp = _combatData.MobHp;

        _playerSlider.maxValue = CharHp;
        _playerSlider.value = CharHp;

        _characterEffects = new Dictionary<DatabaseManager.ECombatEffects, int>();
        _ennemyEffects = new Dictionary<DatabaseManager.ECombatEffects, int>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CharTakeDamage(AttackData attData, DatabaseManager.ECombatEffects effect)
    {
        if(effect != DatabaseManager.ECombatEffects.NONE && !_characterEffects.ContainsKey(effect))
        {
            AddEffect(effect, attData.EffectCooldown,  true);
        }
        ShowDamage(attData.Damage.ToString(), _playerTransform);
        CharHp -= attData.Damage;
        _playerSlider.value = CharHp;
        //if _charHp >= 0 : c'est perdu
        Debug.Log(CharHp);
    }

    public void MobTakeDamage(AttackData attData, DatabaseManager.ECombatEffects effect)
    {
        if (effect != DatabaseManager.ECombatEffects.NONE && !_characterEffects.ContainsKey(effect))
        {
            AddEffect(effect, attData.EffectCooldown, false);
        }
        ShowDamage(attData.Damage.ToString(), _ennemyTransform);
        MobHp -= attData.Damage;
        Debug.Log(MobHp);
        if (MobHp <= 0)
        {
            //Ajouter transition Combat -> Monde
            GameStateManager.Instance.LaunchTransition(EGameState.GAME);
        }
    }

    public void CharHeal(int heal)
    {
        CharHp += heal;
    }

    public void MobHeal(int heal)
    {
        MobHp += heal;
    }

    public void ShowDamage(string text, Transform target)
    {
        GameObject prefab = Instantiate(_floattingTextPrefab, target.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMeshPro>().text = text;
    }

    public AttackData AttackSelct()
    {
        int rand = UnityEngine.Random.Range(0, _combatData.Attacks.Length);
        return _combatData.Attacks[rand];
    }

    public void ApplyEffect(Dictionary<DatabaseManager.ECombatEffects, int> effects, bool onSelf)
    {
        foreach(KeyValuePair< DatabaseManager.ECombatEffects, int> pair in effects)
        {
            switch (pair.Key)
            {
                case DatabaseManager.ECombatEffects.SHIELDED:
                    break;
                case DatabaseManager.ECombatEffects.DOT:
                    DamageOverTime(onSelf);
                    break;
                case DatabaseManager.ECombatEffects.DOWNSPEED:
                    break;
                case DatabaseManager.ECombatEffects.UPSPEED:
                    break;
            }

            if (onSelf)
            {
                _characterEffects[pair.Key] = pair.Value - 1;
                if(_characterEffects[pair.Key] <= 0)
                {
                    _characterEffects.Remove(pair.Key);
                }
            }
            else
            {
                _ennemyEffects[pair.Key] = pair.Value - 1;
                if (_ennemyEffects[pair.Key] <= 0)
                {
                    _ennemyEffects.Remove(pair.Key);
                }
            }
        }
    }

    public void AddEffect(DatabaseManager.ECombatEffects effect, int cooldown, bool onSelf)
    {
        if (onSelf)
        {
            _characterEffects.Add(effect, cooldown);
        }
        else
        {
            _ennemyEffects.Add(effect, cooldown);
        }
    }

    public void DamageOverTime(bool onSelf)
    {
        if (onSelf)
        {
            CharHp -= 2;
            ShowDamage("2", _playerTransform);
        }
        else
        {
            MobHp -= 2;
            ShowDamage("2", _ennemyTransform);
        }
    }



}
