using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    [SerializeField] private GameObject _star;

    [SerializeField] private AudioSource _point;

    [SerializeField] private Text count;

    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.name == _star.name)
        {
            Debug.Log("Star hit");
            count.text = $"{++GoalCount.goalCount}";
            Destroy(GameObject.FindGameObjectWithTag("Star"));
            _point.Play();

        }
    }
}
