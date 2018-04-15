using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class RM_Pause : MonoBehaviour {

    //Puase Menu
    public GameObject pause;
    private bool paused = false;
    private GameObject pauseMenu;
    private GameObject optionsMenu;
    private GameObject controlsMenu;
    private GameObject Player;
    public bool LeavingScene = false;

  

    //Start
	void Start ()
    {
        pauseMenu = GameObject.Find("Pause Menu");
        optionsMenu = GameObject.Find("Settings Menu");
        controlsMenu = GameObject.Find("Controls Menu");
        //Player = FindObjectOfType<Control_Player>().gameObject;

        optionsMenu.SetActive(false);
        pause.SetActive(false);
        controlsMenu.SetActive(false);
	}
	
    //Update
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

       
	}

    //Pause Buttons
   public void Pause()
    {

        paused = !paused;
        if (paused)
        {          
            pause.SetActive(true);
            Time.timeScale = 0;
            //Player.GetComponent<Control_Player>().enabled = false;
            //Player.GetComponent<Control_Player>().InMenu = true;
        }

        if (!paused)
        {
            pause.SetActive(false);
            Time.timeScale = 1;
            //Player.GetComponent<Control_Player>().enabled = true;
            //Player.GetComponent<Control_Player>().InMenu = false;
        }
    } 

    public void MainMenu()
    {
        Time.timeScale = 1;
        LeavingScene = true;
        SceneManager.LoadScene("Scene_MainMenu");
        
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }


    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
    }

}
