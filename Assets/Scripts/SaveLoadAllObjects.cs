using Niantic.Lightship.AR.LocationAR;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;

public class SaveLoadAllObjects : MonoBehaviour
{
    [SerializeField] Button saveButton;

    public static event Action<string> save;

    private ARLocationManager arLocationManager;
    // Start is called before the first frame update
    void Start()
    {
        arLocationManager = FindObjectOfType<ARLocationManager>();
        saveButton.onClick.AddListener(call: () => save.Invoke(arLocationManager.ARLocations[0].Payload.ToBase64()));
        PersistentObject.myPersistantObjectData += SaveData;

    }

    void SaveData(persistantObjectData persistantObjectData)
    {
        string pathToString = Application.persistentDataPath;
        File.WriteAllText(pathToString + "ARlocation.json", JsonUtility.ToJson(persistantObjectData));

#if UNITY_EDITOR
        OpenFolderInFinder(pathToString);
#endif
    }

    public void OpenFolderInFinder(string folderPath)
    {
        // Ensure the folder path is correct and exists
        if (System.IO.Directory.Exists(folderPath))
        {
            // Open the folder
            Process.Start(new ProcessStartInfo()
            {
                FileName = folderPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        else
        {
            UnityEngine.Debug.LogError("Folder not found: " + folderPath);
        }
    }
}
