using System.Collections;
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
		
	}

    public void TakeDamage(int _element, int _damage)
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
            health = 0;

    }

    public void reset(int newType, int _health)
    {
        health = _health;
        element = (Element)newType;
    }
}
