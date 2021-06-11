using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIStuff
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool isPaused = false;

        [SerializeField] private GameObject pausemenuUI;
        [SerializeField] private GameObject shopButtonUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                shopButtonUI.SetActive(false);
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pausemenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        void Pause()
        {
            pausemenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        public void LoadMenu() // though this is gonna cause a bug...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}