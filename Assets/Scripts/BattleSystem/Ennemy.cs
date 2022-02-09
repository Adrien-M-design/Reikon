using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Singleton<Ennemy>
{
    [SerializeField] private float _travelTime = 0f;
    [SerializeField] private int _hp = 10;
    [SerializeField] private int _damage = 0;

    public float TravelTime
    {
        get
        {
            return _travelTime;
        }
        set
        {
            _travelTime = value;
        }
    }

    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
