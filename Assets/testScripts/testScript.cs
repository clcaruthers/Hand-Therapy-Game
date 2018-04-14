using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class testScript : MonoBehaviour {

    ExtendedFingerDetector eDectector = null;

    private int count;

	// Use this for initialization
	void Start () {
		eDectector = GetComponent<ExtendedFingerDetector>();
        //eDectector.Activate();
        //eDectector.enabled = true;
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
            
	}

    public void debugTest()
    {
        if (eDectector.Thumb == PointingState.Extended)
            Debug.Log("Extended");
        else if (eDectector.Thumb == PointingState.NotExtended)
             Debug.Log("NotExtended");

    }
}
