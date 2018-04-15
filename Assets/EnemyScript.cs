﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public enum Element { fire, water, earth, air };

    public int health = 50;
    public Element element = Element.water;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        switch (element)
        {
            case Element.fire:
                MR.material.color = Color.red;
                break;
            case Element.water:
                MR.material.color = Color.blue;
                break;
            case Element.earth:
                MR.material.color = Color.black;
                break;
            case Element.air:
                MR.material.color = Color.yellow;
                break;
            default:
                break;
        }
	}

    void TakeDamage(int _element, int _damage)
    {
        switch ((Element)_element)
        {
            case Element.fire:
                if (element == Element.air)
                    health -= _damage * 10;
                else
                    health -= _damage;
                break;
            case Element.water:
                if (element == Element.fire)
                    health -= _damage * 10;
                else
                    health -= _damage;
                break;
            case Element.earth:
                if (element == Element.water)
                    health -= _damage * 10;
                else
                    health -= _damage;
                break;
            case Element.air:
                if (element == Element.earth)
                    health -= _damage * 10;
                else
                    health -= _damage;
                break;
            default:
                break;
        }

        if (health < 0)
        {
            int h = ((int)(Random.value * 100) % 5 + 5) * 10;
            int t = (int)(Random.value * 100) % 4;
            reset(t, h);
        }

    }

    public void reset(int newType, int _health)
    {
        health = _health;
        element = (Element)newType;
    }
}
