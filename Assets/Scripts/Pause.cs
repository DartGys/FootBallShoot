using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public void PressPause()
    {
        Time.timeScale = 0;
    }

    public void unPressPause()
    {
        Time.timeScale = 1;
    }
}
