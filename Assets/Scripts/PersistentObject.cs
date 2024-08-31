using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField] private string prefabId;
    private string objectUUID;

    public static event Action<persistantObjectData> myPersistantObjectData;


    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(objectUUID))
        {
            objectUUID = CreateUUID();
        }



        SaveLoadAllObjects.save += saveObject;
    }
    string CreateUUID()
    {
        return Guid.NewGuid().ToString();
    }

    void saveObject(string ARlocation)
    {
        persistantObjectData objectData = new persistantObjectData(
            ARlocation,
            prefabId,
            objectUUID,
            transform.position,
            transform.localScale,
            transform.rotation
            );

        myPersistantObjectData?.Invoke(objectData);
    }
}

public struct persistantObjectData
{
    public string locationID;
    public string prefabID;
    public string _uuid;

    public Vector3 position;
    public Vector3 localScale;

    public Quaternion rotation;

    public persistantObjectData(string _locationID, string _prefabID, string uuid, Vector3 _position, Vector3 _localScale,Quaternion _rotation)
    {
        locationID = _locationID;
        prefabID = _prefabID;
        _uuid = uuid;
        position = _position;
        localScale = _localScale;
        rotation = _rotation;

    }
}