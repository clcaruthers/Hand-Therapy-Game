using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class MotionDetection : MonoBehaviour {

    #region Privates
    enum FingerIndex { index = 1, middle, ring, pinky};

    Controller controller;

    private int pinchCount = 0;
    private int[] fingerPinchCount;
    private bool pinched = false;
    private bool testBool = false;
    private bool clenched;
    #endregion

    #region Publics 
    public float minDisPinch = 19.0f;

    public bool[] fingersPinched = new bool[4];
    public bool handRaised;
    public int clenchCount = 0;

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
        isIronManHands(hand);

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

        handRaised = result;
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
}
