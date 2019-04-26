using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving3 : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 Pos;
    //public static float Speed;
    //int Hard = 1;

    void Start()
    {
        Pos.x = -0.35f;
        Pos.y = 0;
        Pos.z = 0;
    }

    void FixedUpdate()
    {
        transform.Translate(Pos);
    }
}
