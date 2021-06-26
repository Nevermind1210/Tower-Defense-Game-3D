using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPaused : MonoBehaviour
{
    public GameObject gameStory;
    public GameObject shopView;

    private void Start()
    {
        shopView.SetActive(false);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        gameStory.SetActive(false);
        shopView.SetActive(true);
        Time.timeScale = 1;
    }
}
