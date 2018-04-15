using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour {

    Text t;

    GameObject manager;

    void Awake()
    {
        t = this.GetComponent<Text>();

        manager = GameObject.FindGameObjectWithTag("Manager");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.parent.gameObject.GetComponent<Image>().color.a < 1.0f)
            t.text = "";
        else
        {
            t.text = "x" + (manager.GetComponent<MotionDetection>().clenchCount + 1);
        }
        

	}
}
