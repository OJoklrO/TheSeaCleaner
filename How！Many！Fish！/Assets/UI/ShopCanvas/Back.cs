using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour {

    public Canvas Canvas_Start;
    public Canvas Canvas_Shop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Canvas_Shop.enabled = false;
            Canvas_Start.enabled = true;
        });
	}
}
