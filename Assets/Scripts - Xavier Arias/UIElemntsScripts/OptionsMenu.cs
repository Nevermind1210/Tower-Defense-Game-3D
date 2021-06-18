using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UIStuff
{
    public class OptionsMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public TMP_Dropdown resolutionDropdown;
        public TMP_Dropdown qualityDropdown;
        public Slider volumeSlider;
        float currentVolume;
        Resolution[] resolutions;

        public void Start()
        {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            int currentResolutionIndex = 0;
            
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + 
                                resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("Volume", volume);
            currentVolume = volume;
        }

        public void SetFullScreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
        
        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        
        public void SaveSettings()
        {
            PlayerPrefs.SetInt("QualitySettingPreference", 
                qualityDropdown.value);
            PlayerPrefs.SetInt("ResolutionPreference", 
                resolutionDropdown.value);
            PlayerPrefs.SetInt("FullscreenPreference", 
                Convert.ToInt32(Screen.fullScreen));
            PlayerPrefs.SetFloat("VolumePreference", 
                currentVolume); 
        }
        
        public void LoadSettings(int currentResolutionIndex)
        {
            if (PlayerPrefs.HasKey("QualitySettingPreference"))
                qualityDropdown.value = 
                    PlayerPrefs.GetInt("QualitySettingPreference");
            else
                qualityDropdown.value = 3;
            if (PlayerPrefs.HasKey("ResolutionPreference"))
                resolutionDropdown.value = 
                    PlayerPrefs.GetInt("ResolutionPreference");
            else
                resolutionDropdown.value = currentResolutionIndex;
            if (PlayerPrefs.HasKey("FullscreenPreference"))
                Screen.fullScreen = 
                    Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            else
                Screen.fullScreen = true;
            if (PlayerPrefs.HasKey("VolumePreference"))
                volumeSlider.value = 
                    PlayerPrefs.GetFloat("VolumePreference");
            else
                volumeSlider.value = 
                    PlayerPrefs.GetFloat("VolumePreference");
        }
    }
}