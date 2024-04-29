using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class QuestionLoader : MonoBehaviour
{
    public string[] questions;
    public TMP_Text QuestionB;
    public TMP_Text Option1;
    public TMP_Text Option2;
    public TMP_Text Option3;
    public TMP_Text Option4;
    private int randomIndex;
    private string questionsURL;
    public GameController gameController;
    private WWW questionData;
    private int correctCount;
    private int wrongCount;
  
    private void Update()
    {
        print(questionsURL);
    }
    private void OnEnable()
    {
        correctCount = 0;
        wrongCount = 0;
        //StartCoroutine(LoadQuestions());
        questionsURL = gameController.GetQuestionsURL();
        StartCoroutine(LoadQuestions());


       
    }



    string GetDataValue(string data, string index)
    {
        int startIndex = data.IndexOf(index) + index.Length;
        // Check if the index was found 
        if (startIndex < index.Length) return ""; // Index not found or other error

        string value = data.Substring(startIndex);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    
    public void CheckAnswer()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton != null)
        {
           
            Text buttonText = clickedButton.GetComponentInChildren<Text>();
            TextMeshProUGUI clickedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
            if (clickedText != null && clickedText.text == GetDataValue(questions[randomIndex], "CorrectAnswer: "))
            {
                Debug.Log("Correct Answer!");
                correctCount++;
                if (correctCount >= gameController.GetNPC().NPCHealth) { gameController.winQuiz(); }
                else
                {
                    ResetQuestions();
                }
            }
            else
            {
                Debug.Log("Wrong Answer!");
                wrongCount++;
                if (wrongCount >= 5) { gameController.loseQuiz(); }
            }
        }

      
    }
    private void ResetQuestions()
    {
        /// Generate a random num from 0-num of questions 
        randomIndex = Random.Range(0, questions.Length);
        QuestionB.text = GetDataValue(questions[randomIndex], "Question: ");
        string[] choices = new string[4];
        choices[0] = GetDataValue(questions[randomIndex], "Choice1: ");
        choices[1] = GetDataValue(questions[randomIndex], "Choice2: ");
        choices[2] = GetDataValue(questions[randomIndex], "Choice3: ");
        choices[3] = GetDataValue(questions[randomIndex], "Choice4: ");

        // Shuffle to randomise choices
        ShuffleArray(choices);

        // Assign shuffled choices to buttons
        Option1.text = choices[0];
        Option2.text = choices[1];
        Option3.text = choices[2];
        Option4.text = choices[3];

    }
    void ShuffleArray<T>(T[] array)
    {
        System.Random rand = new System.Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    public void SetQuestionsURL(string url)
    {
        questionsURL = url;
        //StartCoroutine(LoadQuestions());
    }

    //  loads questions from the set URL
    IEnumerator LoadQuestions()
    {
        questionData = new WWW(questionsURL);
        yield return questionData;
        string questionDataString = questionData.text;
        print(questionDataString);
        questions = questionDataString.Split(';');
        foreach (string q in questions)
        {
            print(GetDataValue(q, "Question: "));
        }
        // 
        randomIndex = Random.Range(0, questions.Length);
        QuestionB.text = GetDataValue(questions[randomIndex], "Question: ");
        string[] choices = new string[4];
        choices[0] = GetDataValue(questions[randomIndex], "Choice1: ");
        choices[1] = GetDataValue(questions[randomIndex], "Choice2: ");
        choices[2] = GetDataValue(questions[randomIndex], "Choice3: ");
        choices[3] = GetDataValue(questions[randomIndex], "Choice4: ");

        
        ShuffleArray(choices);

        
        Option1.text = choices[0];
        Option2.text = choices[1];
        Option3.text = choices[2];
        Option4.text = choices[3];
    }

    public void QuickFireQuiz(string url)
    {
        questionsURL = url;
        StartCoroutine(LoadQuestions());
    }


}

