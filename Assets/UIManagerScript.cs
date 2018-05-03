using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuCanvas;

    [SerializeField]
    private GameObject CreditsCanvas;

    [SerializeField]
    private GameObject LicensesCanvas;

    [SerializeField]
    private GameObject InstructionsCanvas;

    [SerializeField]
    private GameObject InstructionsContentsCanvas;

    //Array for Instructions pages
    [SerializeField]
    private GameObject[] InstructionPage;
    private int CurrentInstructionPage = 0;
    private int pageCount = 0;

    //Menu button sounds
    private AudioClip sfx_MenuBtnHover;
    private AudioClip sfx_MenuBtnClick;

    //Initialize subscreen states
    private void Awake()
    {
        MainMenuCanvas.SetActive(true);
        HideCredits();
        HideLicenses();
        HideInstructions();
        //Hide Instructions pages
        for(int i = 0; i < InstructionPage.Length; i++)
        {
            InstructionPage[i].SetActive(false);
        }
        //InstructionsContentsCanvas.transform.position = new Vector3(-3840, 0, 0); //start Instructions at page 1
    }

    //Go to gameplay scene
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
        
    //Explicitly reload Main Menu scene
    public void ViewMainMenu()
    {
        SceneManager.LoadScene("sceneMainMenu");
    }

    //Credits subscreen
        public void ViewCredits()
    {
        CreditsCanvas.SetActive(true);
    }

    public void HideCredits()
    {
        CreditsCanvas.SetActive(false);
    }

    //Licenses subscreen
    public void ViewLicenses()
    {
        LicensesCanvas.SetActive(true);
    }

    public void HideLicenses()
    {
        LicensesCanvas.SetActive(false);
    }

    //Instructions subscreen
    public void ViewInstructions()
    {
        InstructionsCanvas.SetActive(true);
        InstructionPage[0].SetActive(true);
        CurrentInstructionPage = 0;
    }

    public void HideInstructions()
    {
        InstructionsCanvas.SetActive(false);
        InstructionPage[0].SetActive(false);
        InstructionPage[1].SetActive(false);
        InstructionPage[2].SetActive(false);
        InstructionPage[3].SetActive(false);
        InstructionPage[4].SetActive(false);
        InstructionPage[5].SetActive(false);
    }

    //Scroll between instruction pages
    public void InstructionsNextPage()
    {
        CurrentInstructionPage++;
        if (CurrentInstructionPage == InstructionPage.Length)
        {
            CurrentInstructionPage = 0;
            print(CurrentInstructionPage);
        }

        //Dirty brute-force page switching
        switch (CurrentInstructionPage)
        {
            case 0:
                InstructionPage[0].SetActive(true);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 1:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(true);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 2:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(true);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 3:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(true);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 4:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(true);
                InstructionPage[5].SetActive(false);
                break;

            case 5:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(true);
                break;
        }
    }

    public void InstructionsPrevPage()
    {
        CurrentInstructionPage--;
        if (CurrentInstructionPage < 0)
        {
            CurrentInstructionPage = (InstructionPage.Length - 1);
            print(CurrentInstructionPage);
        }

        //Dirty brute-force page switching
        switch (CurrentInstructionPage)
        {
            case 0:
                InstructionPage[0].SetActive(true);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 1:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(true);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 2:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(true);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 3:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(true);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(false);
                break;

            case 4:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(true);
                InstructionPage[5].SetActive(false);
                break;

            case 5:
                InstructionPage[0].SetActive(false);
                InstructionPage[1].SetActive(false);
                InstructionPage[2].SetActive(false);
                InstructionPage[3].SetActive(false);
                InstructionPage[4].SetActive(false);
                InstructionPage[5].SetActive(true);
                break;
        }
    }
}