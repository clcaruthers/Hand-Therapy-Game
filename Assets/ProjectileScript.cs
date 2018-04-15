using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    GameplayActions script = null;

    public GameplayActions.ProjectileType myType;

    AudioSource AS;

    private int element;

	// Use this for initialization
	void Start () {
        script = GameObject.Find("GameObject").GetComponent<GameplayActions>();
        if (script != null)
            Setup();
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(this.gameObject, 5.0f);
	}

    void OnCollisionEnter(Collision collision)
    {
        EnemyScript eScript = collision.gameObject.GetComponent<EnemyScript>();
        if (eScript != null)
        {
            eScript.TakeDamage(element, myType.power);
        }
        Destroy(this.gameObject);

    }

    public void Setup()
    {
        myType = script.assignBall();
        element = myType.element;
        if (myType.element == -1)
        {
            Destroy(this.gameObject);
            //this.transform.localScale = this.transform.localScale * 0.1f;
            //myType.element = 1;

        }
        if (myType.element == 0)
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        if (myType.element == 1)
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        if (myType.element == 2)
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        if (myType.element == 3)
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;

    }
}
