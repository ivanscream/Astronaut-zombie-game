using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(float health, float positionX, float positionY, float positionZ) {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.txt";
        FileStream file = new FileStream(path, FileMode.Create);
        PlayerSavedData data = new PlayerSavedData(health, positionX, positionY, positionZ);

        binary.Serialize(file, data);
        file.Close();
    }

    public static PlayerSavedData LoadPlayer() {
        string path = Application.persistentDataPath + "/saveData.txt";
        if(File.Exists(path)) {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            PlayerSavedData data = binary.Deserialize(file) as PlayerSavedData;
            file.Close();
            return data;
        } else {
            Debug.LogError("File not found" + path);
            return null;
        }
         
    }
}
