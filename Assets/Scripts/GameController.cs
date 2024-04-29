using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { FreeRoam, Quiz, Talk}
public class GameController : MonoBehaviour
{
    GameState state;
    [SerializeField] PlayerMovement  playerController;
    [SerializeField] QuizController quizController;
    [SerializeField] Camera mainCamera;
    private string questionsURL;
    private NPC selectedNPC;
    public GameObject winImage;
    public GameObject loseImage;
    public SkinManager sm;
    public QuestManager qm;
    [SerializeField] bool isMenu;

    private void Start()
    {
        TextManager.Instance.onShowText += () =>
        {
            state = GameState.Talk;
        };
        TextManager.Instance.onCloseText += () =>
        {
            if(state == GameState.Talk)
            {
                state = GameState.FreeRoam;
            }
        };
    }
    private void Update()
    {
        if (!isMenu)
        {
            if (state == GameState.FreeRoam)
            {
                playerController.HandleUpdate();
            }
            else if (state == GameState.Quiz)
            {
                quizController.HandleUpdate();
            }
            else if (state == GameState.Talk)
            {
                TextManager.Instance.HandleUpdate();
            }
        }
        else
        {
            playerController = null;
        }
    }

    public void startQuiz() 
    {
        state = GameState.Quiz;
        quizController.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
    }

    public void endQuiz()
    {
        state = GameState.FreeRoam;
        quizController.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
    public void winQuiz()
    {
        StartCoroutine(HandleQuizOutcome(winImage));
        if(selectedNPC.npcName == "Roaring2") { sm.IncrementFlapperQCount(); }
        if (selectedNPC.npcName == "FactoryWorker1") { sm.IncrementFactoryQCount(); }
        if (selectedNPC.npcName == "Crime") { sm.IncrementCrimeQCount(); }
        if (selectedNPC.npcName == "Suffragette") { sm.IncrementSuffQCount(); }
        if (selectedNPC.npcName == "RoaringFinace") { sm.IncrementFinanceQCount(); }
        if (selectedNPC.npcName == "Chaplin") { sm.IncrementEntertainmentQCount(); }
        if (selectedNPC.npcName == "ClaraBell") { sm.IncrementEntertainmentQCount(); }
        if (selectedNPC.npcName == "Valetino") { sm.IncrementEntertainmentQCount(); }
        if (selectedNPC.npcName == "Jazz") { sm.IncrementEntertainmentQCount(); }
        if (selectedNPC.npcName == "Communist") { sm.IncrementCommunistQCount(); }
        if (selectedNPC.npcName == "Suburb") { sm.IncrementKKKQCount(); }
        if (selectedNPC.npcName == "Rich") { sm.IncrementRichQCount(); }
        if (selectedNPC.npcName == "Poor") { sm.IncrementRichQCount(); }
        if (selectedNPC.npcName == "AA") { sm.IncrementAAQCount(); }
        if (selectedNPC.npcName == "ImmiM") { sm.IncrementImmiQCount(); }
        if (selectedNPC.npcName == "ImmiF") { sm.IncrementImmiQCount(); }
    }
    public void loseQuiz()
    {
        StartCoroutine(HandleQuizOutcome(loseImage));
    }

    public void SetQuestionsURL(string url)
    {
        questionsURL = url;
        
    }
    public string GetQuestionsURL()
    {
        return questionsURL;

    }

    public void SetNPC(NPC npc)
    {
        selectedNPC = npc;
       

    }
    public NPC GetNPC()
    {
        return selectedNPC;

    }
    private IEnumerator HandleQuizOutcome(GameObject outcomeImage)
    {
        outcomeImage.SetActive(true); // Show the outcome image
        yield return new WaitForSeconds(3); // Wait for three seconds
        outcomeImage.SetActive(false); // Hide the outcome image

        
        state = GameState.FreeRoam;
        quizController.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }

}
