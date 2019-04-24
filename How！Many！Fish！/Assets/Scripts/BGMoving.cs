using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoving : MonoBehaviour
{
    Vector3 Pos,Pos2;
    public static float Speed;
    int Hard = 1;
    public GameObject BG_1;
    public GameObject BG_2;
    public GameObject BG_3;
    public GameObject BG_4;
    public GameObject BG_5;
    GameObject gb;

    void Start()
    {
        Pos.x = -0.02f;
        Pos.y = 0;
        Pos.z = 0;
    }

    void FixedUpdate()
    {
        if(gameObject.transform.position.x<=-19.5)
        {
            if(gameObject.CompareTag("BackGround1"))
            {
                Create(3);
            }
            if (gameObject.CompareTag("BackGround2"))
            {
                Create(4);
            }
            if (gameObject.CompareTag("BackGround3"))
            {
                Create(5);
            }
            if (gameObject.CompareTag("BackGround4"))
            {
                Create(1);
            }
            if (gameObject.CompareTag("BackGround5"))
            {
                Create(2);
            }
            Destroy(gameObject);
            BGList.Background.RemoveFirst();
            
        }
        if (Catch.count > 3 && Hard == 1)
        {
            Hard = 2;
        }
        if (Catch.count > 10 && Hard == 2)
        {
            Hard = 3;
        }
        //Pos.x = Hard * (-0.05f) - 0.05f;
        transform.Translate(Pos);
    }

    void Create(int x)
    {
        switch(x)
        {
            case 1: BGCreate.IsFirst = true; gb = BG_1; break;
            case 2: BGCreate.IsSecond = true; gb = BG_2; break;
            case 3: BGCreate.IsThird = true; gb = BG_3; break;
            case 4: BGCreate.IsForth = true; gb = BG_4; break;
            case 5: BGCreate.IsFifth = true; gb = BG_5; break;
        }
        Pos2.x = gameObject.transform.position.x + 40;
        Pos2.y = -2.1f;
        Pos2.z = 4;
        Instantiate(gb, Pos2, Quaternion.identity);
        BGList.Background.AddLast(gb);       
    }
}
