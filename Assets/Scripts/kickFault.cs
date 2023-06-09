using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickFault : MonoBehaviour
{
    [SerializeField] private EndGame _endGame;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _missCheck;

    void OnTriggerExit(Collider gameObject)
    {
        if (gameObject.name == _ball.name)
        {
            _missCheck.SetActive(false);
            _endGame.GameOver();
        }
    }
}
