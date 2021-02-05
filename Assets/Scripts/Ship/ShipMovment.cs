using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShipMovment : MonoBehaviour
{
    [Header("General")]

    #region Move Towards Stats 
    //Delete this if we go with AI
    float vertical, horizontal;
    public float speed = 1000f;
    private float activeForwardSpeed;
    [SerializeField] private float forwardAccelration = 2.5f;
    public float rotationSpeed = 150;
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
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

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
            }
        }

        if (!isAI)
        {
            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, vertical * speed, forwardAccelration * Time.deltaTime);

            transform.position += (transform.forward * activeForwardSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
        }

        //Cheat();
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
