using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GoalCount : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    [SerializeField] Text count;

    [SerializeField] private ballSpawn _randomBallSpawn;

    [SerializeField] private AudioSource _pointPick;

    [SerializeField] private GameObject _kickFault;

    [SerializeField] private SpawnWallinGoalPosts _spawnWall;

    [SerializeField] private StarSpawn _spawnStar;

    [HideInInspector] public static int goalCount = 0;

    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.name == ball.name)
        {
            Debug.Log("Goal");
            _pointPick.Play();
            count.text = $"{++goalCount}";
            _kickFault.SetActive(false);
            _spawnWall.StartCoroutine("SpawnWall");
            _randomBallSpawn.StartCoroutine("Spawn");
            _spawnStar.StartCoroutine("starSpawn");
        }
    }
}
