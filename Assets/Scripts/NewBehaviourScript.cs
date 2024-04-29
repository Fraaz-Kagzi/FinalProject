using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using System.Linq;


// updated question loader . deals with filters now for NPCEra
public class QuestionLoader2 : MonoBehaviour
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
    public HeartManager heartManager;
    private int correctCount;
    private int wrongCount;
    
    private void Update()
    {
        //print(questionsURL);
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
        if (startIndex < index.Length) return ""; // Index not found

        string value = data.Substring(startIndex);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    int GetIntDataValue(string data, string index)
    {
        int startIndex = data.IndexOf(index) + index.Length;
        if (startIndex < index.Length) return -1; 

        string value = data.Substring(startIndex);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return int.Parse(value);
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
                heartManager.RemoveNPCHeart();  // NPC loses a heart
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
                heartManager.RemovePlayerHeart();  // Player loses a heart
                if (wrongCount >= 5) { gameController.loseQuiz(); }
            }
        }
    }

    private void ResetQuestions()
    {
       
        randomIndex = UnityEngine.Random.Range(0, questions.Length);
        QuestionB.text = GetDataValue(questions[randomIndex], "Question: ");
        string[] choices = new string[4];
        choices[0] = GetDataValue(questions[randomIndex], "Choice1: ");
        choices[1] = GetDataValue(questions[randomIndex], "Choice2: ");
        choices[2] = GetDataValue(questions[randomIndex], "Choice3: ");
        choices[3] = GetDataValue(questions[randomIndex], "Choice4: ");

        // Shuffle the choices array
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

   
    IEnumerator LoadQuestions()
    {
        questionData = new WWW(questionsURL);
        yield return questionData;
        string questionDataString = questionData.text;
        print(questionDataString);
        string[] allQuestions = questionDataString.Split(';');
        List<string> filteredQuestions = new List<string>();

        //Add all Questions
        if (gameController.GetNPC().NPCEra == "*")
        {
            foreach (string q in allQuestions)
            {
                filteredQuestions.Add(q);
            }
        }
        // Add multiple topics with same genre  
        else if (gameController.GetNPC().NPCEra.Contains("-"))
        {
            string eraSuffix = (gameController.GetNPC().NPCEra.Contains("-")) ? gameController.GetNPC().NPCEra.Split('-')[1] : string.Empty;
            Debug.Log(eraSuffix);
            foreach (string q in allQuestions)
            {
                string era = GetDataValue(q, "Era: ");
                int questionLevel = (GetIntDataValue(q, "Level: "));

                if (era.Contains(eraSuffix) && questionLevel <= gameController.GetNPC().NPCQuestionLevel)
                {
                    filteredQuestions.Add(q);
                }

            }
        }
        // Add multiple topics from same table  
        else if (gameController.GetNPC().NPCEra.Contains("&"))
        {
            HashSet<string> uniqueQuestions = new HashSet<string>();
            string[] eras = gameController.GetNPC().NPCEra.Split('&');
            foreach (string era in eras)
            {
                foreach (string q in allQuestions)
                {
                    string questionEra = GetDataValue(q, "Era: ").Trim();
                    if (questionEra.Equals(era.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        //  HashSet to avoid duplicates
                        uniqueQuestions.Add(q);
                    }
                }
            }
            filteredQuestions = uniqueQuestions.ToList();
        }
        // Filter questions based on NPC's era and question level
        else
        {
            foreach (string q in allQuestions)
            {
                string era = GetDataValue(q, "Era: ");
                int questionLevel = (GetIntDataValue(q, "Level: ")); 

                if (era == gameController.GetNPC().NPCEra && (questionLevel) <= gameController.GetNPC().NPCQuestionLevel)
                {
                    filteredQuestions.Add(q);
                }
            }
        }

        // to avoid index out of range errors
        if (filteredQuestions.Count > 0)
        {
            questions = filteredQuestions.ToArray();
            foreach (string q in questions)
            {
                print(GetDataValue(q, "Question: "));
            }

            SetRandomQuestion();
        }
        else
        {
            Debug.LogError("No questions match the NPC criteria.");
            
        }
    }

    private void SetRandomQuestion()
    {
      
        randomIndex =  UnityEngine.Random.Range(0, questions.Length);
        QuestionB.text = GetDataValue(questions[randomIndex], "Question: ");
        string[] choices = new string[4];
        choices[0] = GetDataValue(questions[randomIndex], "Choice1: ");
        choices[1] = GetDataValue(questions[randomIndex], "Choice2: ");
        choices[2] = GetDataValue(questions[randomIndex], "Choice3: ");
        choices[3] = GetDataValue(questions[randomIndex], "Choice4: ");

        // Shuffle the choices array
        ShuffleArray(choices);

        // Assign shuffled choices to buttons
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

