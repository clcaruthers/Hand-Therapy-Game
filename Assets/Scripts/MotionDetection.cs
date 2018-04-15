using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class MotionDetection : MonoBehaviour {

    #region Privates
    enum FingerIndex { index = 1, middle, ring, pinky};
    public GameObject clenchParticle;

    Controller controller;
    private Hand handReference;

    private int pinchCount = 0;
    private int[] fingerPinchCount;
    private bool pinched = false;
    private bool testBool = false;
    private bool clenched;
    private bool shooting = false;

    
    #endregion

    #region Publics 
    public float minDisPinch = 19.0f;


    public bool[] fingersPinched = new bool[4];
    public bool handRaised = false;
    public int clenchCount = 0;

    AudioSource AS;

    [RequireComponent(typeof(Rigidbody))]
    [System.Serializable]
    public class Projectile
    {
        public GameObject body;
    }

    public Projectile[] projectiles;
    public GameObject palm;

    #endregion

    // Use this for initialization
    void Start () {
        fingerPinchCount = new int[4];

        for (int i = 0; i < fingerPinchCount.Length; i++)
        {
            fingerPinchCount[i] = 0;
        }

        controller = new Controller();

        if (controller.IsConnected)
            Debug.Log("Connected");

        AS = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (controller.IsConnected)
            Debug.Log("Connected");

        Frame frame = controller.Frame();

        if (frame.Hands.Count != 0)
        {
            #region Debug Code/Testing

            Debug.Log("We have dis hands");

            for (int i = 0; i < frame.Hands.Count; i++)
            {
                Hand hand = frame.Hands[i];
                handReference = hand;
                Behavior(hand);

                testBool = true;
                for (int fin = 1; fin < 5; fin++)
                {

                    if (isFingerPinching(hand, fin))
                        fingerPinchCount[fin - 1]++;

                    if (fingerPinchCount[fin - 1] == 0)
                        testBool = false;

                    
                }//For each finger skipping thumb

                if (testBool)
                    Debug.Log("Successfuly pinched with all fingers");
            }//for each hand 
            #endregion
        }
    }

    void Behavior(Hand hand)
    {
        if (isIronManHands(hand))
        {
            if (!handRaised)
            {
                Shoot(hand, 0);
                handRaised = true;
            }

        }
        else
            handRaised = false;

        if (pinchCount >= 5)
        {
            CastFireball();
            pinchCount = 0;
        }
    }

    public bool isIronManHands(Hand hand)
    {

        if (hand == null)
        {
            Debug.Log("Look mom, no hands");
            return false;
        }
        bool result = false;

        bool extended = true;

        for (int i = 0; i < hand.Fingers.Count; i++)
        {
            if (!hand.Fingers[i].IsExtended)
            {
                extended = false;
                return result;
            }
        }

        if (extended)
        {
            float angle = Vector3.Dot(Vector3.forward, hand.PalmNormal.ToVector3());
            //Debug.Log("Ryan has had sex: " + angle + " times in his life");

            if (angle < -0.8f)
            {
                result = true;

                Debug.Log("hand is up");
            }
        }

        return result;
    }

    public bool isFingerPinching(Hand hand, int index)
    {
        bool result = false;
        Vector3 posFing1 = hand.Fingers[index].TipPosition.ToVector3();
        Vector3 posThumb = hand.Fingers[0].TipPosition.ToVector3();

        float distance = Vector3.Distance(posFing1, posThumb);

        if (distance <= minDisPinch)
        {
            Debug.Log(index + " finger");
            result = true;
        }

        fingersPinched[index - 1] = result;
        return result;
    }

    public void ClenchFist()
    {
        if (!clenched)
        {
            clenchParticle.transform.position = GameObject.FindGameObjectWithTag("Hand").transform.position;

            clenchParticle.GetComponent<ParticleSystem>().Play();

            AS.Play();
        }
        clenched = true;

    }

    public void UnClenchFist()
    {
        if (clenched)
        {
            clenched = false;
            clenchCount++;
        }
    }

    public void CastFireball()
    {
        Debug.Log("Fireball");
    }

    public void Shoot(Hand hand, int type)
    {
        if (!shooting)
        {
            if (type == 0)
            {
                GameObject proj = GameObject.Instantiate(projectiles[0].body);

                proj.transform.position = hand.PalmPosition.ToVector3() / 1000.0f;
                proj.transform.position = new Vector3(proj.transform.position.x, proj.transform.position.y - 0.3f, proj.transform.position.z + 0.5f);

                proj.GetComponent<Rigidbody>().velocity = Vector3.forward;

            }

        }

    }

    public Hand getHand()
    {
        return handReference;
    }
}
