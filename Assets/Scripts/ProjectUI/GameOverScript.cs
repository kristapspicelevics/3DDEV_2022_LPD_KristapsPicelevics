using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
