using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPostHit : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private AudioSource _goalPostHit;

    void OnTriggerEnter(Collider gameObject)
    {
        Debug.Log("Colide with Post");
        if (gameObject.name == _ball.name)
        {
            Debug.Log("Hit sound");
            _goalPostHit.pitch = Random.Range(0.9f, 1.1f);
            _goalPostHit.Play();
        }
    }
}
