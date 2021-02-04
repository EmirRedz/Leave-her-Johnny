using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameManager gm;
    public Transform johnnyShip;
    public Transform johnnyFPS;
    private Transform target;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {

        if (gm.firstPersonCamera.activeInHierarchy)
        {
            //follow camera rot
            target = johnnyFPS;
        }
        else
        {
            target = johnnyShip;
        }
            

        direction.z = target.eulerAngles.y;
        transform.localEulerAngles = direction;
    }
}
