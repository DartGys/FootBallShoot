using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _ball;

    [SerializeField] private AttachCameraToBall _attach;

    [SerializeField] private GameObject _kickFault;

    [SerializeField] private ballMove _ballMove;

    [SerializeField] private GameObject _drawLine;

    public static Vector3 ballStartPos { get; private set; }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        ballStartPos = new Vector3(Random.Range(-140f, 240f), -25f, Random.Range(0f, 230f));
        _ball.transform.position = ballStartPos;
        _attach.SetCamera(_ball.transform);
        _ball.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.2f);
        _kickFault.SetActive(true);
        _ballMove.enabled = true;
        _drawLine.SetActive(true);
        _ball.GetComponent<Rigidbody>().isKinematic = false;

    }
}
