using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RM_AutoTransition : MonoBehaviour {

    [SerializeField] private float Timer = 20.0f;
    public string NextScene;
	
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            SceneManager.LoadScene(NextScene);
        }
	}
}
