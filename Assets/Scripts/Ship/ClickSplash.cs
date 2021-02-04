using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSplash : MonoBehaviour
{
    public float lifeSpan;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
