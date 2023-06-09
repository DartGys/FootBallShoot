using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private Text _fpsCount;

    private float fps;
    // Update is called once per frame
    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        _fpsCount.text = "fps: " + (int)fps;
    }
}
