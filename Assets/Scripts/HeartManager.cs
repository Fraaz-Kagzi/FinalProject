using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//ui for life system for quizz
public class HeartManager : MonoBehaviour
{
    public GameObject playerHeartContainer;
    public GameObject npcHeartContainer;
    public GameController gm;
    public Sprite fullHeart;

    private List<GameObject> playerHearts = new List<GameObject>();
    private List<GameObject> npcHearts = new List<GameObject>();

    void OnEnable()
    {
        InitializeHearts();
    }

    public void InitializeHearts()
    {
        Debug.Log("adding hearts");
        int npcHealth = gm.GetNPC().NPCHealth;
        Debug.Log("NPC HEALTH = " + npcHealth);

        ClearHearts(playerHearts, playerHeartContainer);
        ClearHearts(npcHearts, npcHeartContainer);

        // Create player hearts
        for (int i = 0; i < 5; i++)  // Always 5 hearts for the player
        {
            playerHearts.Add(CreateHeart(playerHeartContainer));
        }

        // Create NPC hearts based on their health level
        for (int i = 0; i < npcHealth; i++)
        {
            npcHearts.Add(CreateHeart(npcHeartContainer));
        }
    }

    private void ClearHearts(List<GameObject> hearts, GameObject container)
    {
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();
    }

    private GameObject CreateHeart(GameObject container)
    {
        Debug.Log("creating heart");
        GameObject heartGO = new GameObject("Heart");
        heartGO.transform.SetParent(container.transform, false); 

        Image heartImage = heartGO.AddComponent<Image>();
        heartImage.sprite = fullHeart;
        heartImage.SetNativeSize();
        return heartGO;
    }


    public void RemovePlayerHeart()
    {
        RemoveHeart(playerHearts);
    }

    public void RemoveNPCHeart()
    {
        RemoveHeart(npcHearts);
    }

    private void RemoveHeart(List<GameObject> hearts)
    {
        if (hearts.Count > 0)
        {
            GameObject heartToRemove = hearts[hearts.Count - 1];
            hearts.RemoveAt(hearts.Count - 1);
            Destroy(heartToRemove);
        }
    }
}
