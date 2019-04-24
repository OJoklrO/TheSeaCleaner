using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 Pos;
    public static float Speed;
    int Hard = 1;

    void Start()
    {
        Pos.x = -0.08f;
        Pos.y = 0;
        Pos.z = 0;
        //transform.Rotate(180, 0, 180);
    }

    void FixedUpdate()
    {
        Hard = Catch.count/5;
        if(Hard<3)
        {
            Pos.x = Hard * (-0.02f)-0.08f;
        }
        else
        {
            Pos.x = Hard * (-0.01f) - 0.1f;
        }
        transform.Translate(Pos);
    }
    
}
