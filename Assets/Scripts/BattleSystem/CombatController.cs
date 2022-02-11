using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    private CombatData _combatData = null;

    private int _charHp = 100;
    private int _mobHp = 100;

    public int CharHp => _charHp;
    public int MobHp => _mobHp;

    // Start is called before the first frame update
    void Start()
    {
        //_combatData = DatabaseManager.Instance.CurrentCombat;
        _combatData = DatabaseManager.Instance.Combats["Test"];
        _charHp = CharacterManager.Instance.CharHp;
        _mobHp = _combatData.MobHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharTakeDamage(int dmg)
    {
        _charHp -= dmg;
        //faut clamper la vie couillon
        //if _charHp >= 0 : c'est perdu
        Debug.Log(_charHp);
    }

    public void MobTakeDamage(int dmg)
    {
        _mobHp -= dmg;
        //faut clamper la vie couillon
        //if _mobHp >= 0 : c'est gagné 
        Debug.Log(_mobHp);
    }

    public void CharHeal(int heal)
    {
        _charHp += heal;
    }

    public void MobHeal(int heal)
    {
        _mobHp += heal;
    }

    public AttackData AttackSelct()
    {
        int rand = UnityEngine.Random.Range(0, _combatData.Attacks.Length);
        return _combatData.Attacks[rand];
    }
}
