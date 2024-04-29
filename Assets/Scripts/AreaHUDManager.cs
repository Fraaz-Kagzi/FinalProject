using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To let player know where they are on map
public class AreaHUDManager : MonoBehaviour
{
    public GameObject hudToActivate; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            hudToActivate.SetActive(true);
            DeactivateOtherHUDs();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hudToActivate.SetActive(false);
        }
    }

    private void DeactivateOtherHUDs()
    {
        
        foreach (Transform hud in hudToActivate.transform.parent)
        {
            if (hud.gameObject != hudToActivate)
            {
                hud.gameObject.SetActive(false);
            }
        }
    }
}
