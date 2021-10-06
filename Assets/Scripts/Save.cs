using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

/******************************************************************************/

//Author: Brackeys 2018
//Title: SAVE & LOAD SYSTEM in Unity
//Available at: https://www.youtube.com/watch?v=XOjd_qU2Ido
//Accessed: 2 October 2021 

//The above was used to assist with the code below

/******************************************************************************/

public static class Save
{
    public static string SaveFileName = "/playerData.txt";
    public static string SaveCollectablesName = "/collectablesData.txt";

    public static void SavePlayer (GameAnalytics analytics, bool SurveyActive1, bool SurveyActive2, bool SurveyActive3, bool SurveyActive4, bool SurveyActive5, bool SurveyActive6, bool SurveyActive7, bool SurveyActive8)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + SaveFileName;
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(analytics, SurveyActive1, SurveyActive2, SurveyActive3, SurveyActive4, SurveyActive5, SurveyActive6, SurveyActive7, SurveyActive8);

        formatter.Serialize(stream, data);

        stream.Close();

    }


    public static void SaveCollectablesData(List<int> collectables)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + SaveCollectablesName;
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData collectabledata = new SaveData(collectables);

        formatter.Serialize(stream, collectabledata);

        stream.Close();
    }

    public static SaveData LoadCollectabblesData()
    {
        string path = Application.persistentDataPath + SaveCollectablesName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


    public static SaveData LoadData ()
    {
        string path = Application.persistentDataPath + SaveFileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data =  formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }



    public static bool CheckPathExists()
    {
        string path = Application.persistentDataPath + SaveFileName;
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
