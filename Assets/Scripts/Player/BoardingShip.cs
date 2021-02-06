using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Player {
    public class BoardingShip : MonoBehaviour
    {
        [Header("General")]
        public Vector3 OnShipPosition = new Vector3(0, -0.25f, -0.015f);
        public Vector3 FlyingJohnyPosition = new Vector3(59.5f, 17f, -31);
        public KeyCode mountKey = KeyCode.F;
        public bool isOnShip;
        private bool canMount = false;

        [Header("Johnny")]
        public GameObject Johnny;
        public GameObject JohnnyGFX;
        public FirstPersonController johnnyController;
        public CharacterFootsteps johnnyFootsteps;
        public AudioSource johnnyFootstepsAudio;
        public GameObject firstPersonCamera;
        private bool johnyFlying;

        [Header("Ship")]
        public GameObject Ship;
        public GameObject plank;
        public NavMeshAgent shipAgent;
        public ShipMovment shipController;
        public GameObject shipCamera;
        public GameObject Helm;
        public float moveSpeed = 10f;
        public float rotationSpeed = 10f;

        public bool isDocking;

        // Update is called once per frame
        void Update()
        {
            MountShip();
            DismountShip();
            HelmCheck();

            if (shipController.Dock != null && Ship.transform.position == shipController.Dock.transform.position)
            {
                isDocking = false;
            }
        }

        private void MountShip()
        {
            if (canMount)
            {
                if (Input.GetKeyDown(mountKey) && !isOnShip)
                {
                    isOnShip = true;
                    johnnyController.enabled = false;
                    johnnyFootsteps.enabled = false;
                    johnnyFootstepsAudio.enabled = false;
                    firstPersonCamera.SetActive(false);
                    JohnnyGFX.SetActive(true);

                    shipAgent.enabled = true;
                    shipController.enabled = true;
                    shipCamera.SetActive(true);
                    plank.SetActive(false);
                }
            }

        }

        private void DismountShip()
        {
            if (isOnShip)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isOnShip = false;
                    johnyFlying = false;

                    JohnnyGFX.SetActive(false);

                    shipCamera.SetActive(false);
                    firstPersonCamera.SetActive(true);
                    plank.SetActive(true);

                    if (shipController.enabled && shipController.Dock != null)
                    {
                        isDocking = true;
                    }
                }
            }

            if (isDocking) //FIX THIS MOTHERFUCKER
            {
                Ship.transform.position = Vector3.MoveTowards(Ship.transform.position, shipController.Dock.transform.position, moveSpeed * Time.deltaTime);
                Ship.transform.rotation = Quaternion.Slerp(Ship.transform.rotation, shipController.Dock.transform.rotation, rotationSpeed * Time.deltaTime);

            }
            if (!isOnShip && !isDocking)
            {
                johnnyController.enabled = true;
                johnnyFootsteps.enabled = true;
                johnnyFootstepsAudio.enabled = true;

                shipAgent.enabled = false;
                shipController.enabled = false;
            }
        }

        private void HelmCheck()
        {
            if (isOnShip || isDocking)
            {
                transform.SetParent(Helm.transform);
                transform.localPosition = OnShipPosition;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Helm"))
            {
                Debug.Log("We're at the helm captain!");


                canMount = true;
            }   
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Helm"))
            {
                Debug.Log("We're at the helm captain!");
                transform.SetParent(other.gameObject.transform);

                if (isOnShip)
                {
                    transform.localPosition = OnShipPosition;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Helm"))
            {
                Debug.Log("We've left helm captain!");

                transform.SetParent(null);
                canMount = false;
                
            }
        }

    }
}
