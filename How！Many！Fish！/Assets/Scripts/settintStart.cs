using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class settintStart : MonoBehaviour
{
    public Button SettingStart;
    public Button SettingBack;
    public Button Quit;
    public Canvas SettingCanvas;

    private bool Status = false;                // false 为游戏未暂停， true 为游戏暂停
    private bool DownStatus = true;
    private bool UpStatus = false;


    // Start is called before the first frame update
    void Start()
    {
        SettingCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SettingStart.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (!Status)
            {
                SettingCanvas.enabled = true;
                SettingStart.enabled = false;
                Status = true;
                Time.timeScale = 0;

            }
        });

        SettingBack.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if (Status)
            {
                SettingCanvas.enabled = false;
                SettingStart.enabled = true;
                Status = false;
                Time.timeScale = 1;

            }
        });

        if (Input.GetKeyDown(KeyCode.Escape) && !Status && DownStatus)
        {
            SettingCanvas.enabled = true;
            SettingStart.enabled = false;
            Status = true;
            UpStatus = false;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Status && UpStatus)
        {
            SettingCanvas.enabled = false;
            SettingStart.enabled = true;
            Status = false;
            DownStatus = false;
            Time.timeScale = 1;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && !DownStatus)
            DownStatus = true;
        if (Input.GetKeyUp(KeyCode.Escape) && !UpStatus)
            UpStatus = true;

    }
}
