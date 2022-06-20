using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _creditsScreen = null;
    [SerializeField] private GameObject _peopleList = null;

    private bool _isCreditsPlaying = false;

    void Start()
    {
        _creditsScreen.SetActive(false);
        
    }

    void Update()
    {
        if (_isCreditsPlaying == true && Input.GetButtonDown("Escape"))
        {
            _creditsScreen.SetActive(false);
            _isCreditsPlaying = false;
        }
    }

    public void Play()
    {
        BFMODManager.Instance.PlayButtonSound();
        GameStateManager.Instance.LaunchTransition(EGameState.GAME);
    }

    public void Credits()
    {
        _creditsScreen.SetActive(true);
        _isCreditsPlaying = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
