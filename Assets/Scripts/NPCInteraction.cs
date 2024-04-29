using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionUI; 
    public CharacterManager CM;
    public bool onPlayer;
    [SerializeField] string phpLink;// php data url 
    public GameController questionLoader;
   //public string npcName;
    public NPC npc;
    [SerializeField] Dialogue dialogue;// lines for talk function

    private void Start()
    {
        onPlayer = false;
        if (interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }
    private void Update()
    {
        inPlayerView();
        if (onPlayer)
        {
            interactionUI.SetActive(true);
            
            questionLoader.SetQuestionsURL(phpLink);
            CM.setQuizC(npc.npcName);
            questionLoader.SetNPC(npc);


            onPlayer = false;
        }
        else { interactionUI.SetActive(false); }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collided");
        if (other.CompareTag("Player"))

        {
            //Debug.Log("with player");
            interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exited");
        if (other.CompareTag("Player"))
        {
            Debug.Log("from player");
            interactionUI.SetActive(false);
        }
    }

    private void inPlayerView()
    {
        if(Physics2D.OverlapCircle(transform.position,0.2f,GamerLayers.i.Player) != null)
        {
            //Debug.Log("player is here");
        }
    }

    public void talk()
    {
        StartCoroutine(TextManager.Instance.ShowText(dialogue));
        questionLoader.qm.NPCInteraction(npc.npcName);
    }
}
