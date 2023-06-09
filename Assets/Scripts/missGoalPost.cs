using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missGoalPost : MonoBehaviour
{
    [SerializeField] private EndGame _endGame;
    [SerializeField] private GameObject _ball;
    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.name == _ball.name)
        {
            _endGame.GameOver();
        }
    }
}
