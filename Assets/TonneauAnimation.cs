using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauAnimation : MonoBehaviour
{
    [SerializeField] private Material[] material = null;
    private Renderer rend = null;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColliderEnter (Collider collider)
    {
        Debug.Log("hi collision");
        Debug.Log(collider.gameObject);
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log(collider.gameObject);
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[2];
        }
    }
}
