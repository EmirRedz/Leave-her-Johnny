using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MusicTrigger : MonoBehaviour
    {
        public MusicManager musicManager;

        private void Start()
        {
            musicManager = FindObjectOfType<MusicManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("IslandMusic"))
            {
                musicManager.newMusicName = "Island";
            }
            else if (other.gameObject.CompareTag("Symphony"))
            {
                musicManager.newMusicName = "Ending";
            }
            else if (other.gameObject.CompareTag("LeaveHerJohnny"))
            {
                musicManager.newMusicName = "LeaveHerJohnny";
            }
        }
    }
}
