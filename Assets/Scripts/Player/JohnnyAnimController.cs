using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyAnimController : MonoBehaviour
{
    public Animator johnnyAnim;
    public GameManager gm;
    public Transform mainCam;
    public float sensetivity = 300;
    private float moveX, moveY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            johnnyAnim.SetBool("isWalking", true);
        }
        else
        {
            johnnyAnim.SetBool("isWalking", false);
        }


        if (gm.firstPersonCamera.activeInHierarchy)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        johnnyAnim.SetFloat("X", moveX);
        johnnyAnim.SetFloat("Z", moveY);
    }
}
