using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{

    [SerializeField] public float timeRemaining;
    [SerializeField] private Text timerText;
    public int sceneID;
    private bool timerIsRunning;
    private IEnumerator coroutine;
    private float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) 
        {
            if (timeRemaining > 1)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else 
            {
                timeRemaining = 0;
                timerIsRunning = false;
                coroutine = GameOver(waitTime, sceneID);
                StartCoroutine(coroutine);
            }
        }
    }

    void DisplayTime(float timeToDisplay) 
    {
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = "Time Remaining: " + $"{min:00}:{sec:00}";
    }

    private IEnumerator GameOver(float waitTime, int sceneID)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneID);
    }

}
