using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            if (Input.anyKeyDown)
            {
                GameStateManager.Instance.LaunchTransition(EGameState.MAINMENU);
            }
        }
    }
}
