using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFlash : MonoBehaviour
{

    // Use this for initialization
    public float Interval = 0.5f;
    public GameObject Title;

    void Start()
    {
        InvokeRepeating("Flash", 0, Interval);
    }

    void Flash()
    {
        if (Title.activeSelf)
            Title.gameObject.SetActive(false);
        else
            Title.gameObject.SetActive(true);
    }
}
