using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class GameplayActions : MonoBehaviour {

    MotionDetection mDetection;

    int[] pinchCounts = new int[4];
    int[] frameCounts = new int[4];

    public int pinchLength = 10;
    public int necessaryPinches = 5;

	// Use this for initialization
	void Start () {
        mDetection = GetComponent<MotionDetection>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 4; ++i)
        {
            if (mDetection.fingersPinched[i])
                frameCounts[i]++;

            if (frameCounts[i] > pinchLength)
                pinchCounts[i]++;

            if(pinchCounts[i] > necessaryPinches)
            {
                if (mDetection.handRaised)
                {
                    switch (i)
                    {
                        case 0:
                            castWater(mDetection.clenchCount);
                            break;
                        case 1:
                            castFire(mDetection.clenchCount);
                            break;
                        case 2:
                            castEarth(mDetection.clenchCount);
                            break;
                        case 3:
                            castAir(mDetection.clenchCount);
                            break;
                        default:
                            break;
                    }
                    mDetection.clenchCount = 0;
                }
            }
        }
	}

    void castWater(int stength)
    {

    }

    void castFire(int strength)
    {

    }

    void castEarth(int strenght)
    {

    }

    void castAir(int strength)
    {

    }
}
