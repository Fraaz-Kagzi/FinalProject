using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private bool skinUnlocked;

    public void UnlockSkin()
    {
        skinUnlocked = true;
    }

    // Add a method to check if the skin is unlocked
    public bool IsUnlocked()
    {
        return skinUnlocked;
    }
}

