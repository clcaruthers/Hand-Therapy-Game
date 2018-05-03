using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    GameplayActions script = null;

    public GameplayActions.ProjectileType myType;

    private GameObject AudioPlayer;
    private AudioSource AudioPlayer_AS;
    private AudioManager audiomanager;

    AudioSource AS;

    private int element;

	// Use this for initialization
	void Start ()
    {

        AS = this.GetComponent<AudioSource>();
        AudioPlayer = GameObject.FindGameObjectWithTag("AudioPlayer");
        Debug.Assert(AudioPlayer != null);

        AudioPlayer_AS = AudioPlayer.GetComponent<AudioSource>();
        audiomanager = AudioPlayer.GetComponent<AudioManager>();
        
        script = GameObject.Find("GameObject").GetComponent<GameplayActions>();
        if (script != null)
            Setup();

        Destroy(this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.K))
            AudioPlayer_AS.PlayOneShot(AudioPlayer_AS.clip);

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
            AS.PlayOneShot(audiomanager.ImpactClips[this.element]);
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
