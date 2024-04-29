using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct NPCInteractions
{
    public string NPCName;
    public int RequiredInteractions;
    public int CurrentInteractions;
    public Text interactionText; 
}

public class QuestManager : MonoBehaviour
{


    public GameObject player; 
    public List<GameObject> allBoxes;
    public List<GameObject> allQuests;
    public SkinCanvas sc;
    private int totalNpcsToTalkTo;
    private int currentNpcsTalkedTo;
    private Dictionary<string, List<NPCInteractions>> questNpcs = new Dictionary<string, List<NPCInteractions>>();
    private string currentQuest;
    public Text FlapperT;
    public Text SuffT;
    public Text ChapT;
    public Text ValT;
    public Text BellT;
    public Text JazzT;
    public Text CrimeT;
    public Text CaponeT;
    public Text RichT;
    public Text PoorT;
    public Text CommunistT;
    public Text AAT;
    public Text ImmiMT;
    public Text ImmiFT;
    public Text FactoryT;
    public Text FordT;
    public Text FinanceT;
    public Text KKKT;



    private void Start()
    {
        InitializeQuests();
    }

    private void InitializeQuests()
    {
        // Women quest NPCs
        questNpcs["Women"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "Roaring2", RequiredInteractions = 4,interactionText=FlapperT },
            new NPCInteractions { NPCName = "Suffragette", RequiredInteractions = 4,interactionText=SuffT  }
        };

        //Entertainment quest NPCs
        questNpcs["Entertainment"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "Chaplin", RequiredInteractions = 1,interactionText=ChapT  },
            new NPCInteractions { NPCName = "Valentino", RequiredInteractions = 1 ,interactionText=ValT},
            new NPCInteractions { NPCName = "ClaraBell", RequiredInteractions = 1 ,interactionText=BellT},
            new NPCInteractions { NPCName = "Jazz", RequiredInteractions = 4 ,interactionText=JazzT}
        };
        //Crimw quest NPCs
        questNpcs["Crime"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "Crime", RequiredInteractions = 6,interactionText=CrimeT },
            new NPCInteractions { NPCName = "AlCapone", RequiredInteractions = 1 ,interactionText=CaponeT}
          
        };
        //Wealth quest NPCs
        questNpcs["IoW"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "Rich", RequiredInteractions = 3 ,interactionText=RichT},
            new NPCInteractions { NPCName = "Poor", RequiredInteractions = 3,interactionText=PoorT }

        };
        //Red scare quest NPCs
        questNpcs["RedScare"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "Communist", RequiredInteractions = 4 ,interactionText=CommunistT}
        
        };
        //African American Experience quest NPCs
        questNpcs["AA"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "AA", RequiredInteractions = 4 ,interactionText=AAT}
          
        };
        //immigrant experience quest NPCs
        questNpcs["Immi"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "ImmiM", RequiredInteractions = 3,interactionText=ImmiMT},
            new NPCInteractions { NPCName = "ImmiF", RequiredInteractions = 3,interactionText=ImmiFT }

        };
        //stock market boom quest NPCs
        questNpcs["Finance"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "RoaringFinace", RequiredInteractions = 2 ,interactionText=FinanceT}
            
        };
        //motor industry quest NPCs
        questNpcs["Factory"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "FactoryWorker1", RequiredInteractions = 4 ,interactionText=FactoryT},
            new NPCInteractions { NPCName = "HenryFord", RequiredInteractions = 1,interactionText=FordT }

        };
        //kkk quest NPCs
        questNpcs["KKK"] = new List<NPCInteractions>
        {
            new NPCInteractions { NPCName = "Suburb", RequiredInteractions = 3 ,interactionText=KKKT}
            

        };
    }


    public void StartWomenQuest()
    {
        if (currentQuest != null) { EndQuest(); }// end quest before starting new one
        sc.activateDQ();
        currentQuest = "Women";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "Women");// quest box
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "Women");// green zone
        TeleportPlayerToQuestLocation(new Vector3(-79, -27, 0)); //TP to location
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;
       
        
        
    }
    public void StartFinanceQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "Finance";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "Finance");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "Finance");
        TeleportPlayerToQuestLocation(new Vector3(-120, -25, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }
    public void StartAAQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "AA";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "AA");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "AA");
        TeleportPlayerToQuestLocation(new Vector3(-87, -76, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


       
    }
    public void StartKKKQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "KKK";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "KKK");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "KKK");
        TeleportPlayerToQuestLocation(new Vector3(-29, -63, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }
    public void StartRedScQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "RedScare";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "RedScare");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "RedScare");
        TeleportPlayerToQuestLocation(new Vector3(-39, -25, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }
    public void StartIoWQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "IoW";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "IoW");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "IoW");
        TeleportPlayerToQuestLocation(new Vector3(-29, -76, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }
    public void StartImmiQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "Immi";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "Immi");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "Immi");
        TeleportPlayerToQuestLocation(new Vector3(-87, -59, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }
    public void StartFactoryQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "Factory";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "Factory");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "Factory");
        TeleportPlayerToQuestLocation(new Vector3(-23, -47, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }
    public void StartCrimeQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "Crime";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "Crime");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "Crime");
        TeleportPlayerToQuestLocation(new Vector3(-60, -25, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


     
    }
    public void StartEntertainmentQuest()
    {
        if (currentQuest != null) { EndQuest(); }
        sc.activateDQ();
        currentQuest = "Entertainment";
        GameObject qc = allQuests.Find(c => c.gameObject.name == "Entertainment");
        qc.SetActive(true);
        UpdateNPCInteractionTexts();
        sc.DeactivateQ();
        GameObject qb = allBoxes.Find(s => s.gameObject.name == "Entertainment");
        TeleportPlayerToQuestLocation(new Vector3(-55, -55, 0)); 
        qb.SetActive(true);
        totalNpcsToTalkTo = 4;


        
    }








    public void TeleportPlayerToQuestLocation(Vector3 location)
    {
        player.transform.position = location;
        
    }

    public void NPCInteraction(string npcName)
    {
        List<NPCInteractions> npcs = questNpcs[currentQuest];
        Debug.Log("name is  " + npcName);
        
        for (int i = 0; i < npcs.Count; i++)
        {
            Debug.Log("name need is  " + npcs[i].NPCName);
            if (npcs[i].NPCName == npcName)
            {
                NPCInteractions updatedInteraction = npcs[i];
                updatedInteraction.CurrentInteractions++;
                Debug.Log("interaction incremented");
                npcs[i] = updatedInteraction; 

               
                npcs[i].interactionText.text =  updatedInteraction.CurrentInteractions + "/" + updatedInteraction.RequiredInteractions ;//text displayed 
                Debug.Log("text updated");

                // Check if the quest is complete
                CheckIfQuestComplete();
                break; 
            }
        }
    }
    // Checks if all NPCs in the current quest have been interacted with the required number of times
    private void CheckIfQuestComplete()
    {
        foreach (var npcInteraction in questNpcs[currentQuest])
        {
            if (npcInteraction.CurrentInteractions < npcInteraction.RequiredInteractions)
            {
                return; // If any NPC hasn't been interacted with enough, the quest isn't complete
            }
        }

        
        EndQuest();
    }

    //updates the UI text for all NPCs in quest
    private void UpdateNPCInteractionTexts()
    {
        foreach (var npc in questNpcs[currentQuest])
        {
            if (npc.interactionText != null)
            {
                npc.interactionText.text =  npc.CurrentInteractions + "/" + npc.RequiredInteractions ;
            }
        }
    }


    private void EndQuest()
    {
        // Deactivate quest area highlight and perform cleanup
        GameObject qb = allBoxes.Find(s => s.gameObject.name == currentQuest);
        if (qb != null)
        {
            qb.SetActive(false);
        }

   
        GameObject qc = allQuests.Find(c => c.gameObject.name == currentQuest);
        if (qc != null)
        {
            qc.SetActive(false);
        }
        sc.DeactivateDQ();
        currentQuest = null;

        
        



    }
}

