using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform = null;
    [SerializeField] private Transform _ennemyTransform = null;
    [SerializeField] private PlayerTimelineController _playerTimeline = null;
    [SerializeField] private EnnemyTimelineController _ennemyTimeline = null;
    [SerializeField] private GameObject _floattingTextPrefab = null;
    [SerializeField] private Slider _playerSlider = null;
    [SerializeField] private Slider _ennemySlider = null;
    [SerializeField] private GameObject _victoryScreen = null;
    [SerializeField] private GameObject _defeatScreen = null;
    [SerializeField] private Animator _animatorKappa = null;
    [SerializeField] private Animator _animatorAyumu = null;
    private CombatData _combatData = null;

    private int _charHp = 100;
    private int _mobHp = 100;
    private int _mobLower40 = 0;

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

    public Dictionary<DatabaseManager.ECombatEffects, int> CharacterEffects => _characterEffects;
    public Dictionary<DatabaseManager.ECombatEffects, int> EnnemyEffects => _ennemyEffects;

    // Start is called before the first frame update
    void Start()
    {
        //_combatData = DatabaseManager.Instance.CurrentCombat;
        _combatData = DatabaseManager.Instance.Combats["Test"];
        _charHp = CharacterManager.Instance.CharHp;
        _mobHp = _combatData.MobHp;
        _mobLower40 = _mobHp * (int) 0.4;

        _playerSlider.maxValue = CharHp;
        _playerSlider.value = CharHp;
        _ennemySlider.maxValue = MobHp;
        _ennemySlider.value = MobHp;

        _characterEffects = new Dictionary<DatabaseManager.ECombatEffects, int>();
        _ennemyEffects = new Dictionary<DatabaseManager.ECombatEffects, int>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_victoryScreen.activeInHierarchy == true || _defeatScreen.activeInHierarchy == true)
        {
            if (Input.anyKeyDown)
            {
                _victoryScreen.SetActive(false);
                _defeatScreen.SetActive(false);
                //Ajouter transition Combat -> Monde
                GameStateManager.Instance.LaunchTransition(EGameState.GAME);
            }
        }

    }

    public void CharTakeDamage(AttackData attData, DatabaseManager.ECombatEffects effect)
    {
        if(effect != DatabaseManager.ECombatEffects.NONE && !_characterEffects.ContainsKey(effect))
        {
            AddEffect(effect, attData.EffectCooldown,  true);
        }
        _animatorAyumu.SetTrigger("Damage");
        _animatorAyumu.SetBool("Idle", false);
        _animatorAyumu.SetBool("Attack", false);
        _animatorAyumu.SetBool("DAttack", false);
        ShowDamage(attData.Damage.ToString(), _playerTransform);
        CharHp -= attData.Damage;
        _playerSlider.value = CharHp;
        if (CharHp <= 0)
        {
            _playerTimeline.InBattle = false;
            _ennemyTimeline.InBattle = false;
            _animatorAyumu.SetTrigger("Defeat");
            _animatorAyumu.SetBool("Idle", false);
            _animatorAyumu.SetBool("Attack", false);
            _animatorAyumu.SetBool("DAttack", false);
            _defeatScreen.SetActive(true);
            BFMODManager.Instance.PlayEndBattleSound("Defaite");
        }
        Debug.Log(CharHp);
    }

    public void MobTakeDamage(AttackData attData, DatabaseManager.ECombatEffects effect)
    {
        if (effect != DatabaseManager.ECombatEffects.NONE && !_characterEffects.ContainsKey(effect))
        {
            AddEffect(effect, attData.EffectCooldown, false);
        }
        _animatorKappa.SetTrigger("Damage");
        _animatorKappa.SetBool("Stand", false);
        _animatorKappa.SetBool("Attack", false);
        ShowDamage(attData.Damage.ToString(), _ennemyTransform);
        MobHp -= attData.Damage;
        _ennemySlider.value = MobHp;
        Debug.Log(MobHp);
        if(MobHp <= 20)
        {
            _animatorKappa.SetLayerWeight(1, 1);
        }
        if (MobHp <= 0)
        {
            _playerTimeline.InBattle = false;
            _ennemyTimeline.InBattle = false;
            _animatorAyumu.SetTrigger("Victory");
            _animatorAyumu.SetBool("Idle", false);
            _animatorAyumu.SetBool("Attack", false);
            _animatorAyumu.SetBool("DAttack", false);
            _victoryScreen.SetActive(true);
            BFMODManager.Instance.PlayEndBattleSound("Victoire");
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
        List<DatabaseManager.ECombatEffects> _toRemoveList = new List<DatabaseManager.ECombatEffects>();

        Dictionary<DatabaseManager.ECombatEffects, int> tmpEffects = new Dictionary<DatabaseManager.ECombatEffects, int>();
        foreach (KeyValuePair<DatabaseManager.ECombatEffects, int> pair in effects)
        {
            tmpEffects.Add(pair.Key, pair.Value);
        }

        foreach (KeyValuePair< DatabaseManager.ECombatEffects, int> pair in effects)
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
                tmpEffects[pair.Key] = pair.Value - 1;
                if(tmpEffects[pair.Key] < 0)
                {
                    _toRemoveList.Add(pair.Key);
                }
            }
            else
            {
                tmpEffects[pair.Key] = pair.Value - 1;
                if (tmpEffects[pair.Key] <= 0)
                {
                    _toRemoveList.Add(pair.Key);
                }
            }
        }

        for (int i = 0; i < _toRemoveList.Count; i++)
        {
            tmpEffects.Remove(_toRemoveList[i]);
        }

        _toRemoveList.Clear();
        effects = tmpEffects;
    }

    public void AddEffect(DatabaseManager.ECombatEffects effect, int cooldown, bool onSelf)
    {
        if (onSelf)
        {
            if (!_characterEffects.ContainsKey(effect))
                _characterEffects.Add(effect, cooldown);
            else
                _characterEffects[effect] += cooldown;
        }
        else
        {
            if (!_ennemyEffects.ContainsKey(effect))
                _ennemyEffects.Add(effect, cooldown);
            else
                _ennemyEffects[effect] += cooldown;
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
            _ennemySlider.value = MobHp;
            ShowDamage("2", _ennemyTransform);
        }
    }



}
