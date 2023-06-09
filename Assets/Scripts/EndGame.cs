using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private Text _endText;
    [SerializeField] private AudioSource _fail;
    [SerializeField] private GameObject _powerBar;
    [SerializeField] private ballMove _ballMove;
    [SerializeField] private GameObject _goalCount;
    [SerializeField] private GameObject _textGoalCount;
    [SerializeField] private SpawnWallinGoalPosts _spawnWall;

    public void GameOver()
    {
        Debug.Log("GameEnd");
        _endGameScreen.SetActive(true);
        _endText.text = $"Кількість набраних очків: {GoalCount.goalCount}";
        GoalCount.goalCount = 0;
        _fail.Play();
        _powerBar.SetActive(false);
        _goalCount.SetActive(false);
        _textGoalCount.SetActive(false);
        _ballMove.enabled = false;

    }
}
