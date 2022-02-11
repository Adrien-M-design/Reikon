using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameLoader : MonoBehaviour
{
    [SerializeField] private DatabaseManager _databaseManager = null;
    // Start is called before the first frame update
    void Awake()
    {
        _databaseManager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
