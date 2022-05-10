using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TalismanHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _effectDesc = null;
    [SerializeField] private string _talismanDesc = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _effectDesc.enabled = true;
        _effectDesc.text = _talismanDesc;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _effectDesc.enabled = false;
    }
}