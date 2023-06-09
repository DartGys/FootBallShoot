using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWallinGoalPosts : MonoBehaviour
{
    [SerializeField] private GameObject _wall;
    [SerializeField] private StarSpawn _starSpawn;
    private List<GameObject> wallList = new List<GameObject>();

    private void wallSpawner()
    {
        float Xposition = Random.Range(18, 85);
        float startXpos = Xposition;
        int spawnCount = Random.Range(1, 10);
        Debug.Log($"spawnCount: {spawnCount}");
        int route = Random.Range(1, 3); // 1 spawn to left, 2 spawn to right
        Debug.Log($"Wall route: {route}");
        for (int i = 0; i < spawnCount; i++)
        {
            var newWall = Instantiate(_wall, new Vector3(Xposition, -26f, 355f), Quaternion.identity);
            wallList.Add(newWall);
            if (route == 1)
            {
                if (Xposition - 7f < 18) break;
                else Xposition -= 7;
            }
            else
            {
                if (Xposition + 7f > 85) break;
                else Xposition += 7;
            }
        }
        _starSpawn.SetWallPos(startXpos, Xposition, route);
    }

    IEnumerator SpawnWall()
    {
        Debug.Log("SpawnWall start");
        yield return new WaitForSeconds(1f);
        foreach (var g in wallList)
            Destroy(g);
        wallSpawner();
    }
}
