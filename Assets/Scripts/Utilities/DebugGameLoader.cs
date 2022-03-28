using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameLoader : MonoBehaviour
{
    [SerializeField] private DatabaseManager _databaseManager = null;
    [SerializeField] private InputManager _inputManager = null;
    [SerializeField] private GameStateManager _gameStateManager = null;
    [SerializeField] private CharacterManager _characterManager = null;

    [SerializeField] private EGameState _firstState = EGameState.GAME;
    // Start is called before the first frame update
    void Awake()
    {
        _databaseManager.Initialize();
        _inputManager.Initialize();
        _gameStateManager.Initialize();
        _characterManager.Initialize();
        GameStateManager.Instance.ChangeState(_firstState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
