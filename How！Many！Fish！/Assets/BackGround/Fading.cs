using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    public GameObject t;
    public GameObject Button;

    private float a = 0f;
    private bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (a <= 1)
        {
            t.gameObject.GetComponent<Text>().color = new Color(1, 1, 1, a);
            a += 0.01f;

            if ((int)a == 1)
                b = true;
        }

        if (b)
            Button.SetActive(true);
    }
}
