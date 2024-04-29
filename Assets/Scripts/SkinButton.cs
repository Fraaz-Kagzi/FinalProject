using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//changes skin
public class SkinButton : MonoBehaviour
{
    public Skin skin;
    public SkinManager sm;
    public GameObject button;
    public bool buttonBool;

    public void UseSkin()
    {
        sm.UpdateSkinUI(skin);
    }
    private void Update()
    {
        if (skin.IsUnlocked()) { button.SetActive(true); }
        else { button.SetActive(false); }
    }



}
