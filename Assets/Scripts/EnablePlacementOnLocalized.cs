using Niantic.Lightship.AR.LocationAR;
using Niantic.Lightship.AR.PersistentAnchors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EnablePlacementOnLocalized : MonoBehaviour
{
    ARLocationManager _arLocationManager;
    ARPlaneManager arPlaneManager;
    ARPlacements arPlacements;
    // Start is called before the first frame update
    void Start()
    {
        _arLocationManager = GetComponent<ARLocationManager>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlacements = FindObjectOfType<ARPlacements>();

        arPlaneManager.enabled = false;
        arPlacements.enabled = false;

        _arLocationManager.locationTrackingStateChanged += OnLocalised;
    }

    void OnLocalised(ARLocationTrackedEventArgs eventArgs)
    {
        if (eventArgs.Tracking)
        {
            arPlaneManager.enabled = true;
            arPlacements.enabled = true;
        }
        else 
        {
            arPlaneManager.enabled = false;
            arPlacements.enabled = false;
        }
    }
}
