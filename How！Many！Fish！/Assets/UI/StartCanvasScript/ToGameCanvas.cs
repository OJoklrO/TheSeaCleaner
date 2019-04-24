using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ToGameCanvas : MonoBehaviour {

    private AsyncOperation async;

	// Use this for initialization
	void Start () {
        async = SceneManager.LoadSceneAsync("125");
        async.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //SceneManager.LoadScene("125");

            async.allowSceneActivation = true;
        }
        );
	}
}
