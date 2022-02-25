using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] _spawns = null;
    [SerializeField] private Transform _firstPos = null;

    private int _counter = 0;

    // Start is called before the first frame update
    void Awake()
    {
        CharacterManager.Instance.CreateCharacter(_spawns[CharacterManager.Instance.SpawnCount]);
        //Debug.Log("Nique la police");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
