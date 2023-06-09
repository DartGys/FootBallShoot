using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private Text _powerShootValue;
    [SerializeField] private Text _yTraectoryValue;

    [SerializeField] private Slider _powerShootSlider;
    [SerializeField] private Slider _yTraectorySlider;

    [SerializeField] private ballMove _ballMove;


    void Update()
    {
        _powerShootValue.text = Convert.ToString(100 * _powerShootSlider.value);
        _yTraectoryValue.text = Convert.ToString(100 * _yTraectorySlider.value);
    }


    public void Save()
    {
        _ballMove.SetSettingsValue(_powerShootSlider.value, _yTraectorySlider.value);
    }

    public void Reset()
    {
        _powerShootSlider.value = 1;
        _yTraectorySlider.value = 1;
    }

}
