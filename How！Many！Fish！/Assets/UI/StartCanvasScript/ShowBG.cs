using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBG : MonoBehaviour
{

    // 需要显示的部分
    public GameObject Title_SamllTitle;
    public GameObject Tip;
    //public GameObject Tips_BackButton;

    // 需要隐藏的部分
    public GameObject Title_MainTitle;
    public GameObject Button_StartTheGame;
    public GameObject Button_GoToShop;
    public GameObject Button_Exit;
    public GameObject Button_Tips;
    public GameObject Button_BG;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            ComFunc.HiddenObject
                (Title_MainTitle, Button_Exit, Button_BG, Button_StartTheGame, Button_Tips);
            ComFunc.RecoveryObject
                (Title_SamllTitle, Tip);
        });
    }
}

