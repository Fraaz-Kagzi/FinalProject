using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkinManager : MonoBehaviour
{
    
    public List<Skin> allSkins;// List of all Skin components
    public SkinButton[] allSkinButtons;// List of all button components on canvas
    public GameObject imageToDisplay;
    //number of quizzes won for certain npcs
    private int FlapperQCount;
    private int CrimeQCount;
    private int FactoryQCount;
    private int SuffQCount;
    private int EntertainmentQCount;
    private int IoWQCount;
    private int KKKQCount;
    private int AAQCount;
    private int ImmiQCount;
    private int FinanceQCount;
    private int RedScQCount;

   
    
    
    public void IncrementFlapperQCount() { IncrementQuizCount(ref FlapperQCount, "Flapper",3); }
    public void IncrementCrimeQCount() { IncrementQuizCount(ref CrimeQCount, "Crime",3); }
    public void IncrementFactoryQCount() { IncrementQuizCount(ref FactoryQCount, "Factory",3); }
    public void IncrementEntertainmentQCount() { IncrementQuizCount(ref EntertainmentQCount, "Entertainment",4); }
    public void IncrementCommunistQCount() { IncrementQuizCount(ref RedScQCount, "Communist",3); }
    public void IncrementImmiQCount() { IncrementQuizCount(ref ImmiQCount, "Immi",4); }
    public void IncrementFinanceQCount() { IncrementQuizCount(ref FinanceQCount, "Finance",2); }
    public void IncrementRichQCount() { IncrementQuizCount(ref IoWQCount, "Rich",4); }
    public void IncrementKKKQCount() { IncrementQuizCount(ref KKKQCount, "KKK",3); }
    public void IncrementAAQCount() { IncrementQuizCount(ref AAQCount, "AA",3); }
    public void IncrementSuffQCount() { IncrementQuizCount(ref SuffQCount, "Suff",3); }

    // method to increment quiz counts and unlock skins if necessary
    private void IncrementQuizCount(ref int quizCount, string skinName,int quizTarget)
    {
        quizCount++;
        if (quizCount >= quizTarget)
        {
            UnlockSkin(skinName);
        }
        Debug.Log(skinName + " " + quizCount);
    }

    //unlocks character skin
    public void UnlockSkin(string skinName)
    {

        var skinButton = allSkinButtons.FirstOrDefault(sb => sb.skin.gameObject.name == skinName);
        if (skinButton != null)
        {
           
            skinButton.gameObject.SetActive(true);
        }
        Skin skin = allSkins.Find(s => s.gameObject.name == skinName);
        if (skin != null && !skin.IsUnlocked())
        {
            skin.UnlockSkin();
            StartCoroutine(DisplayImageCoroutine());
            //UpdateSkinUI(skin);
        }
        else if (skin == null)
        {
            Debug.LogError("Skin not found: " + skinName);
        }
    }


    // Update the UI for a specific skin
    public void UpdateSkinUI(Skin skin)
    {
        foreach (Skin s in allSkins)
        {
            s.gameObject.SetActive(false);
        }

        
        skin.gameObject.SetActive(skin.IsUnlocked());
    }

    // Method to display only unlocked skins
    public void DisplayUnlockedSkins()
    {
        foreach (Skin skin in allSkins)
        {
            skin.gameObject.SetActive(skin.IsUnlocked());
        }
    }

    
    void Start()
    {
        foreach (var skinButton in allSkinButtons)
        {
            skinButton.gameObject.SetActive(skinButton.skin.IsUnlocked());
        }

        foreach (Skin skin in allSkins)
        {
            //set all skins off
            skin.gameObject.SetActive(skin.IsUnlocked());
        }
        FlapperQCount = 0;
        CrimeQCount =0;
        FactoryQCount=0;
        SuffQCount=0;
        EntertainmentQCount=0;
        IoWQCount=0;
        KKKQCount=0;
        AAQCount=0;
        ImmiQCount=0;
        FinanceQCount=0;
        RedScQCount=0;
        UnlockSkin("Default");


    
    
    }
    //show the pop up image to let player know they have unlocked a new skin
    private IEnumerator DisplayImageCoroutine()
    {
        imageToDisplay.gameObject.SetActive(true); // Show the image
        Debug.Log("skin won");
        yield return new WaitForSeconds(6); // Wait for 6 seconds
        imageToDisplay.gameObject.SetActive(false); // Hide the image
    }
}
