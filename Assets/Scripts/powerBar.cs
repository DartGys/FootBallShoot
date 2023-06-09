using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerBar : MonoBehaviour
{
    [SerializeField] private Image _powerBarFilling;

    [SerializeField] private ballMove _powerShoot;

    [SerializeField] private Gradient _gradient;

    private Camera _camera;
    // Start is called before the first frame update
    void Awake()
    {
        _powerShoot.PowerShootChanged += OnPowerShootChanged;
        _camera = Camera.main;
        _powerBarFilling.color = _gradient.Evaluate(1);
    }

    private void OnDestroy()
    {
        _powerShoot.PowerShootChanged -= OnPowerShootChanged;
    }

    private void OnPowerShootChanged(float valueAsPercantage)
    {
        _powerBarFilling.fillAmount = valueAsPercantage;
        _powerBarFilling.color = _gradient.Evaluate(valueAsPercantage);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 0, 270);
    }
}
