using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //SceneManager.UnloadScene("123"); // 通过场景名或场景路径卸载

            //Destroy(this);
            //SceneManager.LoadScene("124");
            //SceneManager.LoadScene("124", this.LoadSceneMode.Additive);

            
        }
        );
    }
}
