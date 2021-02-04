using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class MusicManager : MonoBehaviour
    {
        public AudioClip mainTheme;
        public AudioClip menuTheme;
        public AudioClip ending;

        string sceneName;


        void Start()
        {
            OnLevelWasLoaded(0);
        }


        void OnLevelWasLoaded(int sceneIndex)
        {
            AudioListener.pause = false;
            string newSceneName = SceneManager.GetActiveScene().name;
            if (newSceneName != sceneName)
            {
                sceneName = newSceneName;
                Invoke("PlayMusic", .2f);
            }
        }

        void PlayMusic()
        {
            AudioClip clipToPlay = null;

            if (sceneName == "Menu")
            {
                clipToPlay = menuTheme;
            }
            else if (sceneName == "LeaveHerJohny")
            {
                clipToPlay = mainTheme;
            }
            else if (sceneName == "Ending")
            {
                clipToPlay = mainTheme;
            }
            if (clipToPlay != null)
            {
                AudioManager.Instance.PlayMusic(clipToPlay, 2);
                Invoke("PlayMusic", clipToPlay.length);
            }

        }
    }
}
