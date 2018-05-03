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

    [SerializeField]
    private GameObject InstructionsContentsCanvas;

    //Initialize Instructions section starting page
    private int CurrentInstructionPage = 0;

    //Menu button sounds
    private AudioClip sfx_MenuBtnHover;
    private AudioClip sfx_MenuBtnClick;

    private void Awake()
    {
        HideCredits();
        HideLicenses();
        HideInstructions();
        InstructionsContentsCanvas.transform.position = new Vector3(-3840, 0, 0); //start Instructions at page 1
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

    public void InstructionsNextPage()
    {
        switch(CurrentInstructionPage)
        {
            case 1:
                CurrentInstructionPage++;
                print("Instructions Page 2");
                InstructionsContentsCanvas.transform.position = new Vector3(-1920, 0, 0);
                break;

            case 2:
                CurrentInstructionPage++;
                print("Instructions Page 3");
                InstructionsContentsCanvas.transform.position = new Vector3(0, 0, 0);
                break;

            case 3:
                CurrentInstructionPage++;
                print("Instructions Page 4");
                InstructionsContentsCanvas.transform.position = new Vector3(1920, 0, 0);
                break;

            case 4:
                CurrentInstructionPage++;
                print("Instructions Page 5");
                InstructionsContentsCanvas.transform.position = new Vector3(3840, 0, 0);
                break;

            case 5:
                CurrentInstructionPage = 1;
                print("Instructions Page 1");
                InstructionsContentsCanvas.transform.position = new Vector3(-3840, 0, 0);
                break;
        }
    }

    public void InstructionsPrevPage()
    {

    }
}