
[System.Serializable]
public class PlayerSavedData
{
    public float health;
    public float[] position;

    public PlayerSavedData (float health, float positionX, float positionY, float positionZ) {
        this.health = health;
        position = new float[3];
        position[0] = positionX;
        position[1] = positionY;
        position[2] = positionZ;

    }
}
