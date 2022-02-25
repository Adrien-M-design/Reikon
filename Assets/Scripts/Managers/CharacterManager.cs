using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private CharacterController _character = null;
    [SerializeField] private int _charHp = 100;

    private CharacterController _currentCharacter = null;
    private int _spawnCount = 0;

    public CharacterController Character => _currentCharacter;
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

    // Start is called before the first frame update
    public void Initialize()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void CreateCharacter (Transform spawnpos)
    {
        if(_currentCharacter == null)
        {
            _currentCharacter = Instantiate(_character, spawnpos.position, spawnpos.rotation);
        }
    }
        
}
