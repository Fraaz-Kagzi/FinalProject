using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NPCLevel
{
    Low,
    Mid,
    High
}




public class NPC : MonoBehaviour
{
    public string npcName;
    public NPCLevel level;//determines NPCHealth (5,8,12)
    public int NPCQuestNum;
    public int NPCQuestionLevel;//determines difficulty of question pool
    public string NPCEra;//determines question topic
    public int NPCHealth;

    
    void Start()
    {
        if (level.Equals(NPCLevel.Low)) { NPCHealth = 5; }
        else if (level.Equals((NPCLevel.Mid))) { NPCHealth = 8; }
        else if (level.Equals((NPCLevel.High))) { NPCHealth = 12; }
    }

    public static NPC CreateNPC(string name,string era)
    {
       
        GameObject npcGameObject = new GameObject(name);

        
        NPC npcComponent = npcGameObject.AddComponent<NPC>();

       
        npcComponent.npcName = name;
        npcComponent.level = NPCLevel.Mid;
        npcComponent.NPCEra = era;
        npcComponent.NPCQuestionLevel = 3;
        npcComponent.NPCHealth = 8;
        

        return npcComponent; 
    }



}
