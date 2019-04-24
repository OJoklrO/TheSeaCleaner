using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGList : MonoBehaviour
{
    public static LinkedList<GameObject> Background = new LinkedList<GameObject>();

    public GameObject BG_1;
    public GameObject BG_2;
    public GameObject BG_3;
    public GameObject BG_4;
    public GameObject BG_5;
    // Start is called before the first frame update
    void Start()
    {
        Background.AddLast(BG_1);
        Background.AddLast(BG_2);
        Background.AddLast(BG_3);
        Background.AddLast(BG_4);
        Background.AddLast(BG_5);
    }
    
}
