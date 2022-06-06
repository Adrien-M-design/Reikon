using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _creditsScreen = null;
    [SerializeField] private GameObject _peopleList = null;

    void Start()
    {
        _creditsScreen.SetActive(false);
        
    }

    public void Play()
    {
        GameStateManager.Instance.LaunchTransition(EGameState.GAME);
    }

    public void Credits()
    {
        _creditsScreen.SetActive(true);
        Debug.Log("This works");
        _peopleList.GetComponent<Animator>().Play(0);
        Debug.Log("This also works");

        /*if (Input.GetButtonDown("Escape"))
        {
            _creditsScreen.SetActive(false);
        }*/
    }

    public void Quit()
    {
        Application.Quit();
    }

}
