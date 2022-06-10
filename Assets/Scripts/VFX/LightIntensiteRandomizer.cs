using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensiteRandomizer : MonoBehaviour
{
    [SerializeField] private Light _myLight = null;
    [SerializeField] private float _constant = 0;
    [SerializeField] private float _minRange = 0;
    [SerializeField] private float _maxRange = 0;
    [SerializeField] private float _speedOfvariation = 0;

    private float _variableSpeed = 1;
    private float _rangeOfVariation = 0;
    private float _intensity = 0;
    private float velocityRef = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rangeOfVariation = Random.Range(_minRange, _maxRange);
    }

    // Update is called once per frame
    void Update()
    {
        _rangeOfVariation = Random.Range(_minRange, _maxRange);

        _variableSpeed = _rangeOfVariation * _speedOfvariation;
        _intensity = Mathf.PingPong(Time.time * _variableSpeed, 8) + _constant;

        _myLight.intensity = Mathf.SmoothDamp(_myLight.intensity, _intensity, ref velocityRef, _speedOfvariation);
    }
}
