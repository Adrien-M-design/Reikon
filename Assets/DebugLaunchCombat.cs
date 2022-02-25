using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLaunchCombat : MonoBehaviour
{

    [SerializeField] private GameObject _battleButton = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LaunchBattle();
        }
    }

    public void LaunchBattle()
    {
        _battleButton.SetActive(false);
        GameStateManager.Instance.LaunchTransition(EGameState.BATTLE);
    }
}
