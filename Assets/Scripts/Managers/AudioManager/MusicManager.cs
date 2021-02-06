using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class MusicManager : MonoBehaviour
    {
        public AudioClip LeaveHerJohnny;
        public AudioClip IslandMusic;
        public AudioClip Symphony;

        public string newMusicName;
        string musicName;

        void OnLevelWasLoaded(int sceneIndex)
        {
            newMusicName = SceneManager.GetActiveScene().name;
            if (newMusicName != musicName)
            {
                musicName = newMusicName;
                Invoke("PlayMusic", .2f);
            }
        }



        private void Update()
        {
            if (newMusicName != musicName)
            {
                musicName = newMusicName;
                Invoke("PlayMusic", .2f);
            }
        }

        void PlayMusic()
        {
            AudioClip clipToPlay = null;

            if (musicName == "Island")
            {
                clipToPlay = IslandMusic;
            }
            else if (musicName == "LeaveHerJohnny")
            {
                clipToPlay = LeaveHerJohnny;
            }
            else if (musicName == "Ending")
            {
                clipToPlay = Symphony;
            }
            if (clipToPlay != null)
            {
                AudioManager.Instance.PlayMusic(clipToPlay, 2);
                Invoke("PlayMusic", clipToPlay.length);
            }

        }
    }
}
