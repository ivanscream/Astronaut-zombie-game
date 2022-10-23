using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Collectibles : MonoBehaviour
{
    public float rotationSpeed = 40f;
    public static Collectibles itemsCaller; // create the static call to parent
    public static List<Collectibles> allItems = new List<Collectibles>(); // General list of all
    public static List<HealthPack> healthPacks = new List<HealthPack>(); // smaller lists of each
    public static int activeHealthPacks; // a way to keep track of "actives"
    
    protected int healthBoost; // only used in items who give health
    
    void Awake() { itemsCaller = this; } // set the static call to parent
    
    public void CountHealthPacks()
    {
        activeHealthPacks = 0;
        for (int i = 0; i < healthPacks.Count; i++)
        {
            if (healthPacks[i].gameObject.activeInHierarchy)
            {
                activeHealthPacks++;
            }
        }
    }
    
    public int GiveHealth(GameObject hPack)
    {
        for (int i = 0; i < healthPacks.Count; i++)
        {
            if (healthPacks[i].gameObject == hPack)
            {
                healthPacks[i].gameObject.SetActive(false);
                return healthPacks[i].healthBoost;
            }

        }
        return 0; // in case no object found, return null 

    }
}

