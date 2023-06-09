using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
// соровей 1069
public class ballMove : MonoBehaviour
{
    public GameObject ball;
    private Vector3 traectory;
    public event Action<float> PowerShootChanged;
    public static Vector3 rayDraw { get; private set; }
    [SerializeField] private drawLine _vectorChange;
    [SerializeField] private AudioSource _kick;
    [SerializeField] private GameObject _drawLine;

    public Rigidbody rb;
    private float _forceShoot;
    private float _vectorMagnitude;
    private float _powerShootChange = 1;
    private float _yTraectoryChange = 1;

    void Awake()
    {
        _vectorChange.VectorChanged += OnVectorChanged;
    }

    void Update()
    {
        traectory.Normalize();
        powerShootCalculate(traectory);
        traectory.y = (_vectorMagnitude / 57) * _yTraectoryChange;
        rayDraw = new Vector3(traectory.x, traectory.y / 2f, traectory.z);

        if (Input.GetMouseButtonUp(0) && traectory.z != 0)
        {
            Debug.Log($"Traectory: {traectory}");
            Debug.Log($"forceShoot = {_forceShoot}");
            Debug.Log($"y traectory = {traectory.y}");
            //Debug.Log($"vectorMagnitude = {_vectorMagnitude}");
            kickBall();
            _kick.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            _kick.Play();
            this.enabled = false;
            _drawLine.SetActive(false);
        }
    }


    private void kickBall()
    {
        //Debug.Log($"traectory = {traectory * _forceShoot * Time.deltaTime}");
        Debug.Log("_PowerShootChange: " + _powerShootChange);
        Debug.Log("AddForce: " + traectory * _forceShoot * _powerShootChange * Time.deltaTime);
        rb.AddForce(traectory * _forceShoot * _powerShootChange * Time.deltaTime * 1.8f, ForceMode.Impulse);
        Debug.Log("Ball kicked");
        PowerShootChanged?.Invoke(0);
    }

    private void powerShootCalculate(Vector3 traectory)
    {
        double powerOfShoot = 3000 + (_vectorMagnitude * 70);
        _forceShoot = powerOfShoot > 4000 ? 4000 : (float)powerOfShoot;

        float _powerShootAsPercantage = (float)((_forceShoot - 3000) / 1000);
        PowerShootChanged?.Invoke(_powerShootAsPercantage);
        _kick.volume = _powerShootAsPercantage;
    }

    public void SetSettingsValue(float powerShoot, float yTraectory)
    {
        _powerShootChange = powerShoot;
        _yTraectoryChange = yTraectory;
    }

    private void OnVectorChanged(Vector3 vectorDirection)
    {
        traectory = -vectorDirection;
        _vectorMagnitude = traectory.magnitude > 15 ? 15 : traectory.magnitude;
    }

    private void OnDestroy()
    {
        _vectorChange.VectorChanged -= OnVectorChanged;
    }
}
