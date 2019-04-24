using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeed : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    void FixedUpdate()
    {
        transform.Translate(-0.04f, 0, 0);
    }
}
