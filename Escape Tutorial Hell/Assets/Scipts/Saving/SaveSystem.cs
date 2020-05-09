using UnityEngine;
//Namespaces to save files
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Path where save file is created
        string path = Application.persistentDataPath + "/player.fun";
        //Creating save file
        FileStream stream = new FileStream(path, FileMode.Create);

        //Save data that is in PlayerData class
        PlayerData data = new PlayerData(player);

        //Encrypts data in binary
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        //Must be the same as in save file. 
        string path = Application.persistentDataPath + "/player.fun";

        //Check if path is exists
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //Dissolv encrypt
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
