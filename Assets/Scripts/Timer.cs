using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    [Tooltip("Time in seconds for the game to end at, Default is 5 minutes")]
    [SerializeField] float startingTime = 5f*60f;
    [Tooltip("Text Object to change during countdown")]
    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = "Time Left: " + currentTime.ToString();
        if (currentTime <= 0f)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
