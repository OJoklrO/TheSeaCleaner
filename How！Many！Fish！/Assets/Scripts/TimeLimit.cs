using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    float LimitedTime = 60;
    bool IsInLimit = true;
    private void Update()
    {
        if(IsInLimit==true)
        {
            LimitedTime -= Time.deltaTime;
        }

        if(LimitedTime<0)
        {
            IsInLimit = false;
            Application.Quit();
        }
    }
}
