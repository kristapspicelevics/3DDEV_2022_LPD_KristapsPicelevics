using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public void RestartGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Home(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
