using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLaunchCombat : MonoBehaviour
{
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
        GameStateManager.Instance.LaunchTransition(EGameState.BATTLE);
    }
}
