using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    private float startWallPos;
    private float endWallPos;
    private int wallRoute;

    [SerializeField] private GameObject _star;

    private GameObject starOnScene;

    public void SetWallPos(float startPos, float endPos, int route)
    {
        startWallPos = startPos;
        endWallPos = endPos;
        wallRoute = route;
        // 1 spawn to left, 2 spawn to right
    }
    // minX = 15, minY = -4; maxX = 84 ,maxY = -24;
    // може бути -5 над стінкою
    public void SpawnStar()
    {
        float Xposition = Random.Range(15, 84);
        Debug.Log($"star Xpos: {Xposition}");
        float Yposition = Random.Range(-24, -4);
        if (wallRoute == 1)
        {
            Debug.Log($"star route 1");
            if (Xposition < startWallPos && Xposition > endWallPos)
            {
                Yposition = Random.Range(-4, -5);
                Debug.Log($"star has wall Xpos, Ypos: {Yposition}");
            }
        }
        else
        {
            Debug.Log($"star route 2");
            if (Xposition > startWallPos && Xposition < endWallPos)
            {
                Yposition = Random.Range(-4, -5);
                Debug.Log($"star has wall Xpos, Ypos: {Yposition}");
            }
        }

        var curStar = Instantiate(_star, new Vector3(Xposition, Yposition, 354f), Quaternion.identity);
        starOnScene = curStar;
    }

    IEnumerator starSpawn()
    {
        Debug.Log("SpawnStar start");
        yield return new WaitForSeconds(1f);
        Destroy(starOnScene);
        SpawnStar();
    }
}
