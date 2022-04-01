using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    #region Fields
    [SerializeField] private CharacterController _character = null;
    [SerializeField] private int _charHp = 100;

    private CharacterController _currentCharacter = null;
    private int _spawnCount = 0;
    private bool _canMove = false;

    #endregion Fields

    #region Properties
   
    public CharacterController Character
    {
        get => _currentCharacter;
        set => _currentCharacter = value;
    }

    public int SpawnCount
    {
        get => _spawnCount;
        set => _spawnCount = value;
    }

    public int CharHp
    {
        get => _charHp;
        set => _charHp = value;
    }

    public bool CanMove
    {
        get => _canMove;
        set
        {
            _canMove = value;
            if (_onMoveToggle != null)
                _onMoveToggle(_canMove);
        }
            
    }
    #endregion Properties

    #region Events
    private event Action<bool> _onMoveToggle;
    public event Action<bool> OnMoveToggle
    {
        add
        {
            _onMoveToggle -= value;
            _onMoveToggle += value;
        }

        remove
        {
            _onMoveToggle -= value;
        }
    }
    #endregion Events

    public void Initialize()
    {
        CanMove = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void CreateCharacter(Transform spawnpos, Transform parent)
    {
        if(_currentCharacter == null)
        {
            Debug.Log(spawnpos.position);
            _currentCharacter = Instantiate(_character, spawnpos.position, spawnpos.rotation, parent);
        }
    }

}
