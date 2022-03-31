using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryController : MonoBehaviour
{
    [SerializeField] private Image _leftPageImage = null;
    [SerializeField] private Image _rightPageImage = null;

    //this will be changed to an array of sprites 
    //containing the different pages
    [SerializeField] private Sprite _spToChangeTo = null;


    void Start()
    {
       
    }


    void Update()
    {
        //this condition will be changed to an incrementation or
        //decrementation through the array, with the possibility to play an
        //animation to "turn" the pages.
        if(Input.GetKeyDown("d") || Input.GetKeyDown("q"))
        {
            _leftPageImage.sprite = _spToChangeTo;
            _rightPageImage.sprite = _spToChangeTo;
        }
    }
}
