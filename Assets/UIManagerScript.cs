using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ViewCredits()
    {
        SceneManager.LoadScene("sceneCredits");
    }

    public void ViewMainMenu()
    {
        SceneManager.LoadScene("sceneMainMenu");
    }

    public void ViewLicenses()
    {
        SceneManager.LoadScene("sceneLicenses");
    }
}