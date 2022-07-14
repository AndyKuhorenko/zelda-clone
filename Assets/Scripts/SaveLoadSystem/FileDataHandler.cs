using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    private bool useEncryption = false;

    private readonly string encryptionWord = "zelda";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileId)
    {
        if (profileId == null) return null;

        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error occured when trying to load data from file" + fullPath + "\n" + ex);
            }
        }

        return loadedData;

    }

    public void Save(GameData data, string profileId)
    {
        if (profileId == null) return;

        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error occured when trying to save data to file" + fullPath + "\n" + ex);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profiles = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> directoryInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();

        foreach (DirectoryInfo directoryInfo in directoryInfos)
        {
            string profileId = directoryInfo.Name;

            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skip directory without data");
                continue;
            }


            GameData profileData = Load(profileId);

            if (profileData != null)
            {
                profiles.Add(profileId, profileData);
            }
            else
            {
                Debug.LogError("Error occured during profile load. ProfileId:" + profileId);
            }
        }


        return profiles;
    }

    public string GetMostRecentlyUpdatedProfileId()
    {
        string mostRecentProfileId = null;

        var profiles = LoadAllProfiles();

        foreach (KeyValuePair<string, GameData> pair in profiles)
        {
            string profileId = pair.Key;
            GameData gameData = pair.Value;

            if (gameData == null) continue;

            if (mostRecentProfileId == null)
            {
                mostRecentProfileId = profileId;
            }
            else
            {
                DateTime mostRecentDateTime = DateTime.FromBinary(profiles[mostRecentProfileId].lastUpdated);
                DateTime newSaveTime = DateTime.FromBinary(gameData.lastUpdated);

                if (newSaveTime > mostRecentDateTime) mostRecentProfileId = profileId;
            }
        }

        return mostRecentProfileId;
    }


    public void RemoveSaves(string profileId)
    {
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);

        try
        {
            File.Delete(fullPath);

            Debug.Log("Save Removed!");
        }
        catch (Exception ex)
        {
            Debug.LogError("Error occured when trying to delete save at" + fullPath + "\n" + ex);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char) (data[i] ^ encryptionWord[i % encryptionWord.Length]);
        }

        return modifiedData;
    }
}
