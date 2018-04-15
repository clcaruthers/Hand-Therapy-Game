using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class RM_MenuManager : MonoBehaviour {

    //Menu
    private GameObject optionsMenu;
    private GameObject mainMenu;
    private GameObject controlsMenu;
    private GameObject StartGameMenu;

  
    //Start
    void Start()
    {
        
        mainMenu = GameObject.Find("MenuPanel");
        optionsMenu = GameObject.Find("Settings Menu");
        controlsMenu = GameObject.Find("Controls Menu");
        StartGameMenu = GameObject.Find("GamePanel");
      
        optionsMenu.SetActive(false);
        StartGameMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void SceneSelection(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Menu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        StartGameMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        StartGameMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void ControlMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        StartGameMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    //Quits the application or quits play if in editor
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
