using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject player;
    public void LoadPlayer() {
        PlayerSavedData data = SaveSystem.LoadPlayer();
        Vector3 pos = new Vector3(data.position[0], data.position[1], data.position[2]);
        player.transform.position = pos;
        PlayerHealth.health = data.health;
        player.GetComponent<PlayerHealth>().SetHealthBar();
    }
}
