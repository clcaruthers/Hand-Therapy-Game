﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectScript : MonoBehaviour {

    public float duration = 5;

    float time;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > duration)
            Destroy(this.gameObject);
	}
}
