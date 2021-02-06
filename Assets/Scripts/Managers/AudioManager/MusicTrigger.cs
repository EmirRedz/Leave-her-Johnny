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
                Debug.Log("Island Music");
                musicManager.newMusicName = "Island";
            }
            if (other.gameObject.CompareTag("Symphony"))
            {
                Debug.Log("Symphony");
                musicManager.newMusicName = "Ending";
            }
            if (other.gameObject.CompareTag("LeaveHerJohnny"))
            {
                Debug.Log("AC Leave");

                musicManager.newMusicName = "LeaveHerJohnny";
            }
        }
    }
}
