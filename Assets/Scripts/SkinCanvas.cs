using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// class to controll game canvas'
public class SkinCanvas : MonoBehaviour
{
    public GameObject canvas;
    public GameObject QuestCanvas;
    public GameObject duringQuestCanvas;
    public GameObject MenuCanvas;

    private void Start()
    {
        Deactivate();
        DeactivateQ();
        DeactivateDQ();
        DeactivateM();
    }
    //Skin canvas
    public void activate()
    {
        canvas.SetActive(true);
    }
    public void Deactivate()
    {
        canvas.SetActive(false);
    }
    //Quest Camvas
    public void activateQ()
    {
        QuestCanvas.SetActive(true);
    }
    public void DeactivateQ()
    {
        QuestCanvas.SetActive(false);
    }
    //during Quest Canvas - shows who to talk to
    public void activateDQ()
    {
        duringQuestCanvas.SetActive(true);
    }
    public void DeactivateDQ()
    {
        duringQuestCanvas.SetActive(false);
    }
    //Pause menu
    public void activateM()
    {
        MenuCanvas.SetActive(true);
    }
    public void DeactivateM()
    {
        MenuCanvas.SetActive(false);
    }

    void Update()
    {
        // if Esc key pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          
            activateM();//show pause menu
        }
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

