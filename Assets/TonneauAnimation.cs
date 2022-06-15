using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauAnimation : MonoBehaviour
{
    [SerializeField] private Material[] _material = null;
    private Renderer _rend = null;
    private bool _interaction = false;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
        _rend.sharedMaterial = _material[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (_interaction == false)
        {
            Debug.Log("ça touche la");
            if (collider.gameObject.tag == "Player")
            {
                Debug.Log("col col col babe");
                _rend.sharedMaterial = _material[0];
                _interaction = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("In my mind yeah yeah");
            _rend.sharedMaterial = _material[1];
        }
    }
}
