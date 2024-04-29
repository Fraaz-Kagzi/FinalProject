using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 



public class Menu : MonoBehaviour
{
    public GameObject[] menus; // Array to hold all screens
    private int currentMenuIndex = 0; // To keep track of the current screen

    void Start()
    {
        ShowMenu(currentMenuIndex); // Show the main menu on 
    }

    
    void ShowMenu(int index)
    {
        //hide all menus
        foreach (var menu in menus)
        {
            menu.SetActive(false);
        }

        //show the menu at index
        menus[index].SetActive(true);
    }

    
    public void GoToNextMenu()
    {
        currentMenuIndex++;

        
        if (currentMenuIndex >= menus.Length)
        {
            currentMenuIndex = 0;
        }

        ShowMenu(currentMenuIndex);
    }

    
    public void GoToCreditsMenu()
    {
      

        ShowMenu(4);
    }

    
    public void GoToPreviousMenu()
    {
        currentMenuIndex--;

       
        if (currentMenuIndex < 0)
        {
            currentMenuIndex = menus.Length - 1;
        }

        ShowMenu(currentMenuIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadQuizScene()
    {
        SceneManager.LoadScene("Quiz");
    }
    public void Quit()
    {
        Application.Quit();
    }
}