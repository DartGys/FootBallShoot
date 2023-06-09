using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ballSpawn _ballSpawn;
    [SerializeField] private GameObject _buttonCanvas;
    [SerializeField] private Rigidbody _ballRB;
    [SerializeField] private GameObject _powerBar;
    [SerializeField] private ballMove _ballMove;
    [SerializeField] private GameObject _goalCount;
    [SerializeField] private GameObject _textGoalCount;
    [SerializeField] private GameObject _missCheck;
    [SerializeField] private GameObject _kickFault;
    [SerializeField] private SpawnWallinGoalPosts _spawnWall;
    [SerializeField] private StarSpawn _spawnStar;

    public void StartGame()
    {
        StartCoroutine("CoroutineStartGame");
    }

    IEnumerator CoroutineStartGame()
    {
        _buttonCanvas.SetActive(false);
        _ballRB.AddForce(new Vector3(Random.Range(-3f, 3f), Random.Range(1, 4f), Random.Range(10, 30)) * 10f, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        yield return _ballSpawn.StartCoroutine("Spawn");
        yield return _spawnWall.StartCoroutine("SpawnWall");
        yield return _spawnStar.StartCoroutine("starSpawn");
        _powerBar.SetActive(true);
        _goalCount.SetActive(true);
        _textGoalCount.SetActive(true);
        _missCheck.SetActive(true);
        _kickFault.SetActive(true);
        _ballMove.enabled = true;
    }
}
