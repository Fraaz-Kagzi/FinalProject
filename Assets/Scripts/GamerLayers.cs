using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerLayers : MonoBehaviour
{
    
    [SerializeField] LayerMask solidObjects;
    [SerializeField] LayerMask player;
    [SerializeField] LayerMask npc;
    public static GamerLayers i { get; set; }
    void Awake()
    {
        i = this;
    }

    
    void Update()
    {
        
    }
    public LayerMask SolidObjects
    {
        get => solidObjects;
    }
    public LayerMask Player
    {
        get => player;
    }
    public LayerMask NPC
    {
        get => npc;
    }
}
