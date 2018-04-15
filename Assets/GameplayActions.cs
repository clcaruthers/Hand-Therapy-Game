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

    GameObject fireIcon, waterIcon, earthIcon, lightIcon;


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

    void Awake()
    {
        fireIcon = GameObject.Find("FireIcon");
        waterIcon = GameObject.Find("WaterIcon");
        earthIcon = GameObject.Find("EarthIcon");
        lightIcon = GameObject.Find("LightIcon");

        ResetIcons();

    }

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

        ResetIcons();

        if (element == 0) //fire
        {
            Color f = fireIcon.GetComponent<UnityEngine.UI.Image>().color;
            fireIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(f.r, f.g, f.b, 255.0f);
        }
        
        else if (element == 1) //water
        {
            Color f = waterIcon.GetComponent<UnityEngine.UI.Image>().color;
            waterIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(f.r, f.g, f.b, 255.0f);
        }

        else if (element == 2) //earth
        {
            Color f = earthIcon.GetComponent<UnityEngine.UI.Image>().color;
            earthIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(f.r, f.g, f.b, 255.0f);
        }

        else if (element == 3) //lightning
        {
            Color f = lightIcon.GetComponent<UnityEngine.UI.Image>().color;
            lightIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(f.r, f.g, f.b, 255.0f);
        }

        //maybe play a sound on selection

    }

    void ResetIcons()
    {
        Color f, w, e, l;
        f = fireIcon.GetComponent<UnityEngine.UI.Image>().color;
        w = waterIcon.GetComponent<UnityEngine.UI.Image>().color;
        e = earthIcon.GetComponent<UnityEngine.UI.Image>().color;
        l = lightIcon.GetComponent<UnityEngine.UI.Image>().color;

        fireIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(f.r, f.g, f.b,  0.0f);
        waterIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(w.r, w.g, w.b, 0.0f);
        earthIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(e.r, e.g, e.b, 0.0f);
        lightIcon.GetComponent<UnityEngine.UI.Image>().color = new Color(l.r, l.g, l.b, 0.0f);
    }

}
