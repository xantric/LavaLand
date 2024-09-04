using System;
using System.Collections;
using System.Collections.Generic;
using Niantic.Lightship.AR.LocationAR;
using Niantic.Lightship.AR.PersistentAnchors;
using Niantic.Lightship.AR.VpsCoverage;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(CoverageClientManager))]
public class EnablePlacementOnLocalized : MonoBehaviour
{
    private ARLocationManager _arLocationManager;

    private ARPlaneManager _planeManager;

    private ARPlacements _arPlacements;

    public TextMeshProUGUI _textMeshProUGUI;

    private CoverageClientManager _coverageClientManager;
    [SerializeField]
    private int coverageRadius = 50;
    public List<AreaTarget> targets;
    private GameObject ArLocationObject;


    bool isCurrentlyScanning = false;
    private float queryCooldown = 2f;
    private float lastQueryTime;
    // Start is called before the first frame update
    void Start()
    {
        _arLocationManager = FindObjectOfType<ARLocationManager>();
        _planeManager = FindObjectOfType<ARPlaneManager>();
        _arPlacements = FindObjectOfType<ARPlacements>();
        _coverageClientManager = GetComponent<CoverageClientManager>();
        _planeManager.enabled = false;
        

    }
    void CreateQuery()
    {
        
        _coverageClientManager.QueryRadius = coverageRadius;
        _coverageClientManager.UseCurrentLocation = true;
        _textMeshProUGUI.text += "\nQuery Created";
    }

    void SendQuery()
    {
        _textMeshProUGUI.text += "\nQuery Sent";
        CreateQuery();
        _coverageClientManager.TryGetCoverage(OnResponse);
    }
    void OnResponse(AreaTargetsResult _areaTargetsResult)
    {
        _textMeshProUGUI.text += "\nArea Target Results found";
        targets = _areaTargetsResult.AreaTargets;
        _textMeshProUGUI.text += "\nArea Target: " + targets[0].Target.Name;
        isCurrentlyScanning = true;
        _textMeshProUGUI.text += "\n" + isCurrentlyScanning.ToString();
        var location = _arLocationManager.transform.Find(targets[0].Target.Name).gameObject.GetComponent<ARLocation>();
        _arLocationManager.SetARLocations(location);
        _arLocationManager.StartTracking();
        _textMeshProUGUI.text += "\n" + "Tracking started";
        _arLocationManager.locationTrackingStateChanged += OnLocalized;
    }
    private void Update()
    {
        if (!isCurrentlyScanning && Time.time - lastQueryTime >= queryCooldown)
        {
            lastQueryTime = Time.time;
            SendQuery();
        }
        
    }

    private void OnDestroy()
    {
        _arLocationManager.locationTrackingStateChanged -= OnLocalized;
    }

    void OnLocalized(ARLocationTrackedEventArgs eventArgs)
    {
        _textMeshProUGUI.text += "\nOn Localized run";
        var trackingLocation = eventArgs.ARLocation;
        if (eventArgs.Tracking)
        {
            _textMeshProUGUI.text += "\nNow Tracking..." + trackingLocation.name;
            //_planeManager.enabled = true;
            _arPlacements.enabled = true;
            _arPlacements.spawnLocation = trackingLocation.gameObject.GetNamedChild("Sphere").transform;
        }
        else
        {
            //_planeManager.enabled = false;
            _arPlacements.enabled = false;
            isCurrentlyScanning = false;
        }

    }
}