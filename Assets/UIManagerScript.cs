using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject CreditsCanvas;

    [SerializeField]
    private GameObject LicensesCanvas;

    [SerializeField]
    private GameObject InstructionsCanvas;

    private void Awake()
    {
        HideCredits();
        HideLicenses();
        HideInstructions();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ViewCredits()
    {
        //SceneManager.LoadScene("sceneCredits");
        CreditsCanvas.SetActive(true);
    }

    public void ViewMainMenu()
    {
        SceneManager.LoadScene("sceneMainMenu");
    }

    public void ViewLicenses()
    {
        LicensesCanvas.SetActive(true);
    }

    public void HideCredits()
    {
        CreditsCanvas.SetActive(false);
    }

    public void HideLicenses()
    {
        LicensesCanvas.SetActive(false);
    }

    public void ViewInstructions()
    {
        InstructionsCanvas.SetActive(true);
    }

    public void HideInstructions()
    {
        InstructionsCanvas.SetActive(false);
    }
}