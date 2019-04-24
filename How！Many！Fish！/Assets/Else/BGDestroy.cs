using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDestroy : MonoBehaviour
{
    public static bool IsFirst = false;
    public static bool IsSecond = false;
    public static bool IsThird = false;
    public static bool IsForth = false;
    public static bool IsFifth = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround1")) 
        {
            Destroy(collision.gameObject);
            IsThird = true;
        }
        if (collision.gameObject.CompareTag("BackGround2"))
        {
            Destroy(collision.gameObject);
            IsForth = true;
        }
        if (collision.gameObject.CompareTag("BackGround3"))
        {
            Destroy(collision.gameObject);
            IsFifth = true;
        }
        if (collision.gameObject.CompareTag("BackGround4"))
        {
            Destroy(collision.gameObject);
            IsFirst = true;
        }
        if (collision.gameObject.CompareTag("BackGround5"))
        {
            Destroy(collision.gameObject);
            IsSecond = true;
        }
    }
}
