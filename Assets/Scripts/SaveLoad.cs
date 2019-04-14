using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class SaveLoad
{
   public static PlayerProgress playerProgress;

    public static void Save() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create (Application.persistentDataPath + "/savedProgress.gd");
        bf.Serialize(file, SaveLoad.playerProgress);
        file.Close();
    }

    public static void Load() 
    {
        if(File.Exists(Application.persistentDataPath + "/savedProgress.gd")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedProgress.gd", FileMode.Open);
            SaveLoad.playerProgress = (PlayerProgress) bf.Deserialize(file);
            file.Close();
        }
    }
}
