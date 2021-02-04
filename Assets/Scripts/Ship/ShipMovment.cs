using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShipMovment : MonoBehaviour
{
    [Header("General")]

    #region Move Towards Stats 
    //Delete this if we go with AI
    public float speed = 1000f;
    public float rotationSpeed = 150;
    Vector3 position;
    Quaternion targetRotation = Quaternion.identity;
    #endregion

    public bool isAI;

    [Header("Ship AI")]
    public NavMeshAgent agent;
    public LayerMask layerMask;

    [Header("Particles")]
    public ParticleSystem WaterSplash;

    [Header("Disembark")]
    public GameObject Dock;

    [Header("Cheat")]
    public Transform Lighthouse;
    public Transform Island1;
    public Transform Skull;
    public Transform Home;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            if(Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
            {
                if (isAI)
                {
                    Vector3 spawnPos = new Vector3(hit.point.x, -3f, hit.point.z);
                    Instantiate(WaterSplash, spawnPos, Quaternion.identity);
                    agent.SetDestination(hit.point);
                }
                else
                {
                    Vector3 spawnPos = new Vector3(hit.point.x, -3f, hit.point.z);
                    position = new Vector3(hit.point.x, -2, hit.point.z);
                    targetRotation = Quaternion.Euler(position);
                    Instantiate(WaterSplash, spawnPos, Quaternion.identity);
                }
            }
        }

        if (!isAI && position != null && transform.position != position) 
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        if (transform.position == position)
        {
            transform.position = position;
        }

        Cheat();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Island"))
        {
            Dock = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Island"))
        {
            Dock = null;
        }
    }

    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            agent.SetDestination(Lighthouse.position);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            agent.SetDestination(Island1.position);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            agent.SetDestination(Skull.position);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            agent.SetDestination(Home.position);
        }
    }
}
