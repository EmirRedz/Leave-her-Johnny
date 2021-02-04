using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbShip : MonoBehaviour
{
    public CharacterController Johnny;
    public float speed = 3f;
    public bool canClimb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Johnny.Move(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Johnny.Move(Vector3.down * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CharacterController>() == Johnny)
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() == Johnny)
        {
            canClimb = false;
        }
    }
}
