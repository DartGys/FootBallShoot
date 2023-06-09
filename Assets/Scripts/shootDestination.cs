using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDestination : MonoBehaviour
{
    [SerializeField] private GameObject pointer;

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = new Ray(ballSpawn.ballStartPos, ballMove.rayDraw);

        //Debug.DrawRay(ballSpawn.ballStartPos, (ballMove.rayDraw) * 1000f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.isTrigger)
            {
                pointer.SetActive(true);
                pointer.transform.position = hit.point;
            }
            else
                pointer.SetActive(false);
        }

    }
}
