using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class drawLine : MonoBehaviour
{
    public LineRenderer line;
    public LayerMask layerMask;
    public event Action<Vector3> VectorChanged;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        line.startWidth = 0f;
        line.endWidth = 0f;
        line.positionCount = 0;
    }

    private Vector3 startPoint;
    private Vector3 endPoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, raycastHit.point);
                VectorCalculate();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log($"StartPos = {startPoint}, endPos = {endPoint}");
            line.positionCount = 0;
        }
    }

    void VectorCalculate()
    {
        startPoint = ballSpawn.ballStartPos;
        endPoint = line.GetPosition(line.positionCount - 1);
        if (endPoint.z < startPoint.z)
        {
            Vector3 dirVector = endPoint - startPoint;
            VectorChanged?.Invoke(dirVector);
        }
        else
        {
            VectorChanged?.Invoke(new Vector3(0, 0, 0));
        }
    }

}
