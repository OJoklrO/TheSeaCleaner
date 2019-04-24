using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCreate : MonoBehaviour
{
    public GameObject Background_1;
    public GameObject Background_2;
    public GameObject Background_3;
    public GameObject Background_4;
    public GameObject Background_5;

    public static bool IsFirst = false;
    public static bool IsSecond = false;
    public static bool IsThird = false;
    public static bool IsForth = false;
    public static bool IsFifth = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BGDestroy.IsFirst==true)
        {
            Instantiate(Background_1, transform.position, Quaternion.identity);
            BGDestroy.IsFirst = false;
        }
        if (BGDestroy.IsSecond == true)
        {
            Instantiate(Background_2, transform.position, Quaternion.identity);
            BGDestroy.IsSecond = false;
        }
        if (BGDestroy.IsThird == true)
        {
            Instantiate(Background_3, transform.position, Quaternion.identity);
            BGDestroy.IsThird = false;
        }
        if (BGDestroy.IsForth == true)
        {
            Instantiate(Background_4, transform.position, Quaternion.identity);
            BGDestroy.IsForth = false;
        }
        if (BGDestroy.IsFifth == true)
        {
            Instantiate(Background_5, transform.position, Quaternion.identity);
            BGDestroy.IsFifth = false;
        }
    }
}
