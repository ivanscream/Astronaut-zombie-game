using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Collectibles
{
        // add the child scripts to the parent List's
    void Awake() 
    { 
        allItems.Add(this); 
        healthPacks.Add(this); 
        healthBoost = 30;
    }
    
    // Handle the counting of actives
    void OnEnable() { CountHealthPacks(); } // recount since new spawn
    void OnDisable() { CountHealthPacks(); } // recount since old used

    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
