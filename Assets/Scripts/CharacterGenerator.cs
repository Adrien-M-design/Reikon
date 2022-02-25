using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] _spawns = null;
    [SerializeField] private Transform _firstPos = null;

    private int _counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.CreateCharacter(_spawns[CharacterManager.Instance.SpawnCount]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
