using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public enum Element { water, fire, earth, air };

    public int health = 50;
    public int maxHealth = 50;
    public Element element = Element.water;

    public GameObject animator;
    Animator anim;

    public GameObject HealthBar;

    public GameObject[] effects = new GameObject[4];

    GameplayActions.ProjectileType type;

    float resetTimer = 0;

    private GameObject AudioPlayer;
    private AudioSource AudioPlayer_AS;
    private AudioManager audiomanager;

    private EnemySwap eSwap;
    // Use this for initialization
    void Start () {
        eSwap = GetComponentInChildren<EnemySwap>();
        Debug.Assert(eSwap != null);
        HealthBar = this.transform.Find("Canvas").gameObject;
        anim = animator.GetComponent<Animator>();

        AudioPlayer = GameObject.FindGameObjectWithTag("AudioPlayer");
        Debug.Assert(AudioPlayer != null);

        AudioPlayer_AS = AudioPlayer.GetComponent<AudioSource>();
        audiomanager = AudioPlayer.GetComponent<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {

        MeshRenderer m = GetComponent<MeshRenderer>();
        //Material MR = GetComponent<MeshRenderer>().materials[1];

        switch (element)
        {
            case Element.fire:
                m.material = eSwap.TypeSwap[1] ;
                break;
            case Element.water:
                m.material = eSwap.TypeSwap[0];
                break;
            case Element.earth:
                m.material = eSwap.TypeSwap[2];
                break;
            case Element.air:
                m.material = eSwap.TypeSwap[3];
                break;
            default:
                break;
        }

        if (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                int h = ((int)(Random.value * 100) % 4 + 2) * 10;
                int t = (int)(Random.value * 100) % 4;
                reset(t, h);
            }
        }
        if (health < 0)
            health = 0;
        HealthBar.transform.Find("HP").gameObject.GetComponent<Text>().text = "HP: " + health + " / " + maxHealth;

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

        switch ((Element)_element)
        {
            case Element.fire:
                Instantiate(effects[0], this.gameObject.transform);
                break;
            case Element.water:
                Instantiate(effects[1], this.gameObject.transform);
                break;
            case Element.earth:
                Instantiate(effects[2], this.gameObject.transform);
                break;
            case Element.air:
                Instantiate(effects[3], this.gameObject.transform);
                break;
            default:
                break;
        }

        if (health <= 0)
        {
            anim.SetTrigger("Dead");
            int rand = Random.Range(0, 1);
            AudioPlayer_AS.PlayOneShot(audiomanager.DeathClips[rand]);
            resetTimer = 2;
        }

    }

    public void reset(int newType, int _health)
    {
        health = _health;
        maxHealth = _health;
        element = (Element)newType;
    }
}
