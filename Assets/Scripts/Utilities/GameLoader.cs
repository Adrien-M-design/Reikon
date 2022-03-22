using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameStateManager _gameStateManager = null;
    [SerializeField] private GameLoopManager _gameLoopManager = null;
    [SerializeField] private InputManager _inputManager = null;
    [SerializeField] private DatabaseManager _databaseManager = null;
    [SerializeField] private CharacterManager _characterManager = null;

    private void Start()
    {
        _gameStateManager.Initialize();
        _gameLoopManager.Initialize();
        _inputManager.Initialize();
        _databaseManager.Initialize();
        _characterManager.Initialize();
        GameStateManager.Instance.LaunchTransition(EGameState.MAINMENU);
    }
}
