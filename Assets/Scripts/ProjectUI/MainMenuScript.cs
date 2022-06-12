using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
