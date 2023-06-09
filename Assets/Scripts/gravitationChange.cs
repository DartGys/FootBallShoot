using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitationChange : MonoBehaviour
{
    [SerializeField] private Rigidbody _ball;

    void FixedUpdate()
    {
        Vector3 downforce = new Vector3(0, -40, 0);
        _ball.AddForce(downforce);
    }
}
