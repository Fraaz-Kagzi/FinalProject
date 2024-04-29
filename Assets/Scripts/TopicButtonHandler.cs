using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For Quick-Fire Quiz
public class TopicButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject quizCanvas;
    [SerializeField] private Camera quizCamera;    
    [SerializeField] private QuestionLoader2 questionLoader; 
    [SerializeField] private GameController gm; 


   
    public string quizUrl;
    public string npcEra;
    

    public void OnTopicButtonClick()
    {
        // Activate the quiz canvas and camera.
        quizCanvas.SetActive(true);
        if (quizCamera != null)
        {
            quizCamera.gameObject.SetActive(true);
            
        }
        setQ();

        //load the quiz for topic.
        gm.startQuiz();
        questionLoader.QuickFireQuiz(quizUrl);

    }

    //set npc to premade npc
    public void setQ()
    {
        
        gm.SetNPC(NPC.CreateNPC("QUIZ MASTER", npcEra));
    }
}

