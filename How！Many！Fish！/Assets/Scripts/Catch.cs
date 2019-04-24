using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Catch : MonoBehaviour
{
    //bool IsTop=false, IsBotton = false;//判断是否到达上下限
    bool CatchTrash = true;//切换模式
    public static bool IsAlive = true;
    public static int count = 0;//计分
    public Canvas End;
    public AudioClip MusicTrash_1, MusicTrash_2, MusicFish, MusicHFish;
    public Sprite SP1, SP2;
    AudioSource AS;
    public static int  Score=0;
    Animator AN;

    public Canvas Canvas_end;
    public Text t;

    public AsyncOperation LoadingScene;                   // 加载123使直接预加载跳转界面
    public Button BackToStart;


    private void Awake()
    {
        Time.timeScale = 1;
        Score = 0;
    }

    void Start()
    {
        Canvas_end.enabled = false;
        //End.gameObject.SetActive(false);
        AS = gameObject.GetComponent<AudioSource>();
        AS.playOnAwake = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = SP1;
        //AN = gameObject.GetComponent<Animation>();
        AN = GetComponent<Animator>();
        AN.SetBool("IsCatch", true);
        count = 0;

        StartCoroutine(LoadMedum());
    }
    void Update()
    {
        
        if (transform.position.y>=-4)
        {
            Change.IsTop = true;
        }        
        else if(transform.position.y<=-6)
        {
            Change.IsBotton = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && CatchTrash == true) 
        {
            CatchTrash = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = SP2;
            AN.SetBool("IsCatch", false);
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && CatchTrash == false)
        {
            CatchTrash = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = SP1;
            //AN.clip = ActionCatch;
            AN.SetBool("IsCatch", true);
        }
        //AN.Play();

        if (Input.GetKeyDown(KeyCode.DownArrow)&&Change.IsBotton==false)
        {
            this.transform.Translate(0, -2, 0);
            Change.IsTop = false;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)&&Change.IsTop==false)
        {
            this.transform.Translate(0, 2, 0);
            Change.IsBotton = false;
        }

        if(Score<0)
        {
            Score += (int)(0.5 * Time.time);
            __End();
                //Application.Quit();
        }

        // 按下返回按钮出现中间加载界面
        //if (Input.GetButton("BackToStart"))
        //{
        //    LoadingScene.allowSceneActivation = true;
        //}

        BackToStart.GetComponent<Button>().onClick.AddListener(delegate
        {
            LoadingScene.allowSceneActivation = true;
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trash")&&CatchTrash==true)
        {
            Destroy(collision.gameObject);
            count++;
            Score+=2;
            int temp = (int)Random.Range(1, 3);
            if (temp == 1)
            {
                AS.clip = MusicTrash_1;
            }
            else
            {
                AS.clip = MusicTrash_2;
            }
            AS.Play();
        }
        else if(collision.gameObject.CompareTag("HFish")&&CatchTrash==false)
        {
            AS.clip = MusicHFish;
            Destroy(collision.gameObject);
            count++;
            Score += 20;
            AS.Play();
        }
        else if(collision.gameObject.CompareTag("Fish")&&CatchTrash==true)
        {
            AS.clip = MusicFish;
            Destroy(collision.gameObject);
            AS.Play();
            //End.gameObject.SetActive(true);
            Score += (int)(0.5 * Time.time);
            __End();
            //Application.Quit();
        }
        else if (collision.gameObject.CompareTag("HFish") && CatchTrash == true)
        {
            AS.clip = MusicFish;
            Destroy(collision.gameObject);
            AS.Play();
            //End.gameObject.SetActive(true);
            Score += (int)(0.5 * Time.time);
            __End();
            //Application.Quit();
        }
        else if (collision.gameObject.CompareTag("Trash") && CatchTrash == false)
        {
            Score -= 30;
            AS.clip = MusicFish;
            Destroy(collision.gameObject);
            AS.Play();
            //End.gameObject.SetActive(true);
            //Application.Quit();
        }
    }    

    public void __End()
    {
        IsAlive = false;
        Archive.AddBestTen(Score);
        Archive.AddMoney(Score);
        string str = "要返航了\n 你的得分是 : " + Score + "\n您的最高十次得分为\n";
        int[] a = Archive.BestTen;

        foreach (var x in a)
        {
            str += "\n";
            str += x.ToString();
        }



        Canvas_end.enabled = true;
        t.text = str;
        Time.timeScale = 0;
        Canvas_end.enabled = true;
        

    }


    private IEnumerator LoadMedum()
    {
        LoadingScene = SceneManager.LoadSceneAsync("126");
        LoadingScene.allowSceneActivation = false;
        yield return LoadingScene;
    }
}
