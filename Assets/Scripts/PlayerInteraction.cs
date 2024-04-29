using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject selectedNPC;

    private void Update()
    {

        inPlayerView();
    }

    private void inPlayerView()
    {
       
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.2f, GamerLayers.i.NPC);
        if (collider != null)
        {
            NPCInteraction npcScript = collider.gameObject.GetComponent<NPCInteraction>();
            if (npcScript != null)
            {
                
                var variable = npcScript.onPlayer;

               
                npcScript.onPlayer = true;

                //Debug.Log("Player is near NPC, variable value: " + variable);
            }
        }


    }
}
