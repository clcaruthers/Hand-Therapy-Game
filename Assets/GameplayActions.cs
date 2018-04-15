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

    public ParticleSystem[] fingerParticles;
    private ParticleSystem selectedPS = null;
    private ParticleSystem restorePS = null;

    EnemyScript eScript;

    int[] pinchCounts = new int[4];
    int[] frameCounts = new int[4];
    bool[] pinchable = new bool[4];
    bool shot = false;

    public bool selected = false;

    public float timePinching = 0.2f;

    private float[] timeCount = { 0.2f, 0.2f, 0.2f, 0.2f };

    public int pinchLength = 10;
    public int necessaryPinches = 5;

    ProjectileType type;


    // Use this for initialization
    void Start () {
        type = new ProjectileType();
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
            {
                timeCount[i] -= Time.deltaTime;
            }
            else
                pinchable[i] = true;

            if (timeCount[i] <= 0 && pinchable[i])
            {
                timeCount[i] = timePinching;
                pinchable[i] = false;
                pinchCounts[i]++;
            }

            if (pinchCounts[i] > necessaryPinches)
                ChangeElement(i);

            if (shot)
                reset();

        }
	}

    public void reset()
    {
        for(int i = 0; i < 4; ++i)
        {
            pinchCounts[i] = 0;
            timeCount[i] = timePinching;
            mDetection.clenchCount = 0;
            pinchable[i] = true;
        }

        for (int i = 0; i < fingerParticles.Length; i++)
        {
            fingerParticles[i].Play();
        }
        shot = false;
        type.element = -1;

    }

    public ProjectileType assignBall()
    {
        type.power = mDetection.clenchCount + 1;
        selected = false;
        shot = true;
        return type;
    }

    void ChangeElement(int element)
    {

        for (int i = 0; i < 4; i++)
        {
            pinchCounts[i] = 0;
        }

        type.element = element;
        selected = true;

        //maybe play a sound on selection


        //maybe increase the particle system rate on selection
        //if (selectedPS != null)
        //{
        //    selectedPS = restorePS;
        //}
        //
        //restorePS = fingerParticles[element];
        //selectedPS = fingerParticles[element];
        //
        //for (int i = 0; i < fingerParticles.Length; i++)
        //{
        //    if (!mDetection.getHand().IsLeft)
        //        i += 4;
        //    if (i != element)
        //        fingerParticles[i].Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        //    else
        //        fingerParticles[i].Play();
        //}

        





    }


}
