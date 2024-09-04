using Niantic.Lightship.AR.LocationAR;
using Niantic.Lightship.AR.PersistentAnchors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARLocationTracking : MonoBehaviour
{
    [SerializeField]
    private ARLocationManager ArLocationManager;

    [SerializeField]
    private ARLocation[] ArLocations;
    private bool firstTrackingUpdateReceived = false;
    public void StartTracking()
    {
        ArLocationManager.locationTrackingStateChanged += OnLocationTrackingStateChanged;
        ArLocationManager.SetARLocations(ArLocations);
        ArLocationManager.StartTracking();
    }

    private void OnLocationTrackingStateChanged(ARLocationTrackedEventArgs args)
    {
        var trackedLocation = args.ARLocation;
        var isTracking = args.Tracking;

        if (!firstTrackingUpdateReceived && isTracking)
        {
            Debug.Log("First tracking update received");
            firstTrackingUpdateReceived = true;
        }
        
        trackedLocation.gameObject.SetActive(isTracking);
    }

    public void UpdateTracking()
    {
        ArLocationManager.TryUpdateTracking();
    }

    public void Start()
    {
        StartTracking();
    }
}
