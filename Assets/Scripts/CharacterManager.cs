using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to set images for player and quiz opponents
public class CharacterManager : MonoBehaviour
{
    private string playerCharacter;
    private string quizCharacter;

    public void setPlayerC (string character)
    {
        playerCharacter = character;
    }
    public void setQuizC (string character)
    {
        quizCharacter = character;
    }
    public string getPlayerC()
    {
        return playerCharacter;
    }
    public string getQuizC()
    {
        return quizCharacter;
    }


}
