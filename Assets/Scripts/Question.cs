using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public int QuestionID;
    public string QuestionText;
    public string[] WrongChoices;
    public string CorrectAnswer;
}
