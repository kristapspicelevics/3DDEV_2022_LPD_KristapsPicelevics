using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    public static bool IsPaused;
    GameObject camera;
    AudioListener comp;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
        comp = camera.GetComponent<AudioListener>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }


    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        comp.enabled = false;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        comp.enabled = true;
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        comp.enabled = true;
        SceneManager.LoadScene(sceneID);
    }
}