using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving2 : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 Pos;
    public static float Speed;
    //int Hard = 1;

    void Start()
    {
        Pos.x = -0.12f;
        Pos.y = 0;
        Pos.z = 0;
    }

    void FixedUpdate()
    {
        /*
        Hard = Catch.count / 5;
        if (Hard < 3)
        {
            Pos.x = Hard * (-0.02f) - 0.08f;
        }
        else
        {
            Pos.x = Hard * (-0.01f) - 0.1f;
        }
        transform.Translate(Pos);
        */
        /*
        if(Input.GetKeyDown(KeyCode.LeftArrow)&&Pos.x==-0.08f)
        {
            Pos.x = -0.04f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&&Pos.x==-0.04f )
        {
            Pos.x = -0.08f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Pos.x == -0.08f)
        {
            Pos.x = -0.12f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Pos.x == -0.12f)
        {
            Pos.x = -0.08f;
        }*/
        if(Catch.SpeedRate>=0)
        {
            Pos.x = -0.12f + (Catch.SpeedRate) * (-0.1f);
        }
        else 
        {
            Pos.x = -0.12f + (Catch.SpeedRate) * (0.2f);
        }
        
        transform.Translate(Pos);
    }
}
