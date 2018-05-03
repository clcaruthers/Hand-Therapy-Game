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
        AS = this.GetComponent<AudioSource>();
        script = GameObject.Find("GameObject").GetComponent<GameplayActions>();
        if (script != null)
            Setup();

        Destroy(this.gameObject, 5.0f);
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

        if (collision.gameObject.tag == "Enemy")
        {
            AS.PlayOneShot(AS.clip);
            this.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, AS.clip.length);
        }

    }

    public void Setup()
    {
        myType = script.assignBall();

        this.transform.localScale *= myType.power * 0.25f + 1.0f;
        element = myType.element;
        if (myType.element == -1)
        {
            Destroy(this.gameObject);
            //this.transform.localScale = this.transform.localScale * 0.1f;
            //myType.element = 1;

        }
        if (myType.element == 1)
            this.GetComponent<MeshRenderer>().material.SetColor("_TintColor", Color.red);// color = Color.red;
        if (myType.element == 0)
            this.GetComponent<MeshRenderer>().material.SetColor("_TintColor", Color.blue);
        if (myType.element == 2)
            this.GetComponent<MeshRenderer>().material.SetColor("_TintColor", Color.green);
        if (myType.element == 3)
            this.GetComponent<MeshRenderer>().material.SetColor("_TintColor", Color.yellow);

    }
}
