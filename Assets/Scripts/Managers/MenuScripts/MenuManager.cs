﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
namespace Player
{
    public class MenuManager : MonoBehaviour
    {

        public Slider[] volumeSliders;

        public TMP_Dropdown QualityDropdown;
        private int qualityIndex;

        private bool isFullScreen = true;
        public Toggle Fullscreen;

        Resolution[] resolutions;
        public TMP_Dropdown ResolutionDropdown;
        private int resolutionIndex;


        private void Start()
        {
            GetScreenResolution();

            qualityIndex = PlayerPrefs.GetInt("Quality");
            QualityDropdown.value = qualityIndex;

            resolutionIndex = PlayerPrefs.GetInt("Resolution");
            ResolutionDropdown.value = resolutionIndex;

            isFullScreen = (PlayerPrefs.GetInt("Fullscreen") == 1) ? true : false;
            Fullscreen.isOn = isFullScreen;

            volumeSliders[0].value = AudioManager.Instance.masterVolumePercent;
            volumeSliders[1].value = AudioManager.Instance.musicVolumePercent;
            volumeSliders[2].value = AudioManager.Instance.sfxVolumePercent;
        }

        #region Graphics Settings
        public void SetQuality(int i)  //QUALITY
        {
            QualitySettings.SetQualityLevel(i);
            qualityIndex = i;
            PlayerPrefs.SetInt("Quality", qualityIndex);
            PlayerPrefs.Save();
        }

        public void SetScreenResolution(int i) //Setting screen resolution
        {
            Resolution resolution = resolutions[i];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            resolutionIndex = i;
            PlayerPrefs.SetInt("Resolution", resolutionIndex);
            PlayerPrefs.Save();
        }

        public void GetScreenResolution() //Getting screen resolution
        {
            resolutions = Screen.resolutions.Where(resolutions => resolutions.refreshRate == 60).ToArray();
            ResolutionDropdown.ClearOptions();
            List<string> ResolutionOptions = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                ResolutionOptions.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            ResolutionDropdown.AddOptions(ResolutionOptions);
            ResolutionDropdown.RefreshShownValue();
        }


        public void SetFullscreen(bool isFullscreen) //Fullscreen
        {
            Screen.fullScreen = isFullscreen;
            PlayerPrefs.SetInt("Fullscreen", ((isFullscreen) ? 1 : 0));
            PlayerPrefs.Save();
        }
        #endregion

        #region Sound Settings

        public void SetMasterVolume(float volume)
        {
            AudioManager.Instance.SetVolume(volume, AudioManager.AudioChannle.Master);
        }

        public void SetMusicVolume(float volume)
        {
            AudioManager.Instance.SetVolume(volume, AudioManager.AudioChannle.Music);

        }

        public void SetSfxVolume(float volume)
        {
            AudioManager.Instance.SetVolume(volume, AudioManager.AudioChannle.Sfx);
        }

        #endregion



    }
}
