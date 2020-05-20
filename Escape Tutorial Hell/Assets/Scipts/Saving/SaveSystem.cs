using UnityEngine;
//Namespaces to save files
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    private static bool needToLoad = false;
    public static Player player;

    public static void SetNeedToLoad(bool needToLoad)
    {
        SaveSystem.needToLoad = needToLoad;
    }

    public static bool IsNeedToLoad()
    {
        return needToLoad;
    }

    public static void SavePlayer()
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

    public static void LoadPlayer()
    {
        if (needToLoad)
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

                data.LoadDataToPlayer(player);
            }
            else
            {
                Debug.Log("Save file not found in " + path);
            }
        }
    }

    public static void DeleteSave()
    {
        //Must be the same as in save file. 
         string path_player = Application.persistentDataPath + "/player.fun";

        //Check if path is exists
        if (File.Exists(path_player))
        {
            File.Delete(path_player);
        }
        else
        {
            Debug.Log("Save file not found in " + path_player);
        }
    }

    public static bool IsSaveExist()
    {
        //Must be the same as in save file. 
        string path = Application.persistentDataPath + "/player.fun";
        return File.Exists(path);
    }
}
