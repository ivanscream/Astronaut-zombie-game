using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject player;
    public void SavePlayer() {
        float saveHealth = PlayerHealth.health;
        float positionX = player.transform.position.x;
        float positionY = player.transform.position.y;
        float positionZ = player.transform.position.z;

        SaveSystem.SaveData(saveHealth, positionX, positionY, positionZ);
    }
}
