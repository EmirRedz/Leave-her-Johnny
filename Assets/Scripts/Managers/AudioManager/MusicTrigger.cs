using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MusicTrigger : MonoBehaviour
    {
        public MusicManager musicManager;

        private bool isIslandTriggered, isSymphoneTriggered, isJohnnyTriggered;

        private void Start()
        {
            musicManager = FindObjectOfType<MusicManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("IslandMusic"))
            {
                if (!isIslandTriggered)
                {
                    musicManager.newMusicName = "Island";
                    isIslandTriggered = true;
                }
            }
            if (other.gameObject.CompareTag("Symphony"))
            {
                if (!isSymphoneTriggered)
                {
                    musicManager.newMusicName = "Ending";
                    isSymphoneTriggered = true;
                }
            }
            if (other.gameObject.CompareTag("LeaveHerJohnny"))
            {
                if (!isJohnnyTriggered)
                {
                    musicManager.newMusicName = "LeaveHerJohnny";
                    isJohnnyTriggered = true;
                }
            }
        }
    }
}
