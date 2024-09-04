using Niantic.Lightship.AR.LocationAR;
using Niantic.Lightship.AR.PersistentAnchors;
using Niantic.Lightship.AR.VpsCoverage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoverageClientManager))]
public class CoverageManager : MonoBehaviour
{
    // Start is called before the first frame update
    private CoverageClientManager _coverageClientManager;
    [SerializeField]
    private int coverageRadius = 50;
    public List<AreaTarget> targets;
    private GameObject ArLocationObject;
    public ARLocationManager locationManager;
    void Start()
    {
        _coverageClientManager = GetComponent<CoverageClientManager>();
    }
    void CreateQuery()
    {
        _coverageClientManager.QueryRadius = coverageRadius;
        _coverageClientManager.UseCurrentLocation = true;
    }

    void SendQuery()
    {
        CreateQuery();
        _coverageClientManager.TryGetCoverage(OnResponse);
    }
    void OnResponse(AreaTargetsResult _areaTargetsResult)
    {  
        targets = _areaTargetsResult.AreaTargets;
        ARPersistentAnchorPayload locationPayload = new ARPersistentAnchorPayload(targets[0].Target.DefaultAnchor);
        ArLocationObject = new GameObject(targets[0].Target.Name);
        ArLocationObject.transform.parent = locationManager.transform;

        var locationComponentHolder = ArLocationObject.AddComponent<ARLocation>();

        locationComponentHolder.Payload = locationPayload;

        locationManager.SetARLocations(locationComponentHolder);
        locationManager.StartTracking();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
