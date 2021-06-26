using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace UIStuff
{
    public class PauseMenu : MonoBehaviour
    {
        public AudioMixer masterMixer;
        public AudioSource pauseMusic;
        private static bool isPaused = false;

        [SerializeField] private GameObject pausemenuUI;
        //[SerializeField] private GameObject shopButtonUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
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
            pauseMusic.Stop();
            masterMixer.SetFloat("BattleMusic", 0f);
        }

        void Pause()
        {
            pauseMusic.Play();
            masterMixer.SetFloat("PauseMusic", -8f);
            masterMixer.SetFloat("BattleMusic", -60f);
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