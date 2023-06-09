using UnityEngine.SceneManagement;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MainGamplay");
    }
}
