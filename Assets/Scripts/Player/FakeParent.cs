using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeParent : MonoBehaviour
{
    public Transform fakeParent;
    public Collider[] fakeParentColliders;

    private void Start()
    {
        fakeParentColliders = GetComponents<Collider>();
    }

    private void OnEnable()
    {
        foreach (Collider col in fakeParentColliders)
        {
            col.enabled = true;
        }
        transform.position = fakeParent.position;
    }

    private void OnDisable()
    {
        foreach (Collider col in fakeParentColliders)
        {
            col.enabled = false;
        }
    }
}
