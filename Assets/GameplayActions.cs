using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;


public class GameplayActions : MonoBehaviour {

    public class ProjectileType
    {
        public int element;
        public int power;
    }

    MotionDetection mDetection;

    public GameObject enemy;

    EnemyScript eScript;

    int[] pinchCounts = new int[4];
    int[] frameCounts = new int[4];
    bool[] pinchable = new bool[4];

    public int pinchLength = 10;
    public int necessaryPinches = 5;

	// Use this for initialization
	void Start () {
        mDetection = GetComponent<MotionDetection>();
        for(int i = 0; i < 4; ++i)
        {
            pinchable[i] = true;
        }

        eScript = enemy.GetComponent<EnemyScript>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 4; ++i)
        {
            if (mDetection.fingersPinched[i])
                frameCounts[i]++;
            else
                pinchable[i] = true;

            if (frameCounts[i] > pinchLength && pinchable[i])
            {
                pinchable[i] = false;
                pinchCounts[i]++;
                frameCounts[i] = 0;
            }
        }
	}

    public void reset()
    {
        for(int i = 0; i < 4; ++i)
        {
            pinchCounts[i] = 0;
            frameCounts[i] = 0;
            mDetection.clenchCount = 0;
            pinchable[i] = true;
        }
    }

    public ProjectileType assignBall()
    {
        ProjectileType type = new ProjectileType();
        type.element = -1;
        for(int i = 0; i < 4; i++)
        {
            if (pinchCounts[i] > necessaryPinches)
                type.element = i;
        }

        type.power = mDetection.clenchCount;
        reset();
        return type;
    }
}
