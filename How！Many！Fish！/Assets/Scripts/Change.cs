using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{

    public GameObject Rope;//绳子生成
    GameObject FirstRope, SecondRope, ThirdRope;

    public static bool IsTop = false;
    public static bool IsBotton = false;//判断是否到达上下限

    Vector3 Pos;//切换位置
    int NowHigh = 2;//初始位置


    void Start()
    {
        Pos.x = -6.63f;
        Pos.y = -1;
        Pos.z = 3;
        FirstRope = Instantiate(Rope, Pos, Quaternion.identity);
        Pos.y = Pos.y - 2;
        SecondRope = Instantiate(Rope, Pos, Quaternion.identity);
        Pos.y = Pos.y - 2;
        ThirdRope = Instantiate(Rope, Pos, Quaternion.identity);
        ThirdRope.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if (NowHigh==1)
        {
            IsTop = true;
        }
        else if (NowHigh==3)
        {
            IsBotton = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && IsBotton == false)
        {
            IsTop = false;
            NowHigh++;
            if (NowHigh == 2)
            {
                SecondRope.SetActive(true);
            }
            if (NowHigh == 3)
            {
                ThirdRope.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsTop == false)
        {
            IsBotton = false;
            NowHigh--;
            if (NowHigh == 1)
            {
                SecondRope.SetActive(false);
            }
            if (NowHigh == 2)
            {
                ThirdRope.SetActive(false);
            }
        }

        
    }
}
