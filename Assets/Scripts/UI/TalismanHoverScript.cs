using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TalismanHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    [SerializeField] private TextMeshProUGUI _effectDesc = null;
    [SerializeField] private Image _weightImage = null;
    [SerializeField] private Sprite _weightSprite = null;
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
        Debug.Log("You see this shit?");
        _effectDesc.enabled = true;
        _weightImage.enabled = true;
        _effectDesc.text = _talismanDesc;
        _weightImage.sprite = _weightSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _effectDesc.enabled = false;
        _weightImage.enabled = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("You see this shit?");
        _effectDesc.enabled = true;
        _weightImage.enabled = true;
        _effectDesc.text = _talismanDesc;
        _weightImage.sprite = _weightSprite;
    }    
}