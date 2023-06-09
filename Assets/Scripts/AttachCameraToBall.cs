using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachCameraToBall : MonoBehaviour
{
    [SerializeField] private Transform _goalPostPosition;
    [SerializeField] private Text _distance;
    [SerializeField] private Camera _camera;

    public void SetCamera(Transform ballPosition)
    {
        Vector3 vectorDirection = _goalPostPosition.position - ballPosition.position;
        float vectorMagnitude = vectorDirection.magnitude;
        Vector3 cameraPosition = (ballPosition.position - (vectorDirection / (vectorMagnitude / 40)));
        _distance.text = $"{(int)vectorMagnitude / 7}м";
        _camera.transform.position = new Vector3(cameraPosition.x, -16f, cameraPosition.z);
        _camera.transform.LookAt(new Vector3(_goalPostPosition.position.x, transform.position.y, _goalPostPosition.transform.position.z));
    }
}
