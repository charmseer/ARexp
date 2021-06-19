using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


// This Script is attached to an EmptyObject called Controller in Unity
public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    private GameObject spawnedObject;

    //public GameObject joystickCanvas;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        //Find the AR Raycast Manager from the Scene and assign it to the variable we created
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();

        //joystickCanvas.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
        //Combined conditions to check before calling the method to spawn object
        //1)Check if the scene does not contain a spawned object
        //2) Check if the value of the placementPoseIsValid which indicates that we've made a hit. Then c
        //3) Check if Input.touchCount > 0
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
            //joystickCanvas.SetActive(true);
        }
        UpdatePlacementPose();
        UpdatePlacementIndicator();

    }

    void UpdatePlacementIndicator()
    {
        if(spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        //Get the camera's resolution and  find it's centre, that'll be the screenCenter
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        //A variable to check if we make a hit
        placementPoseIsValid = hits.Count > 0;

        //if the variable is true we take the hit co-ordinates and store it in PlacementPose
        if(placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }    

    }

    //Method to spawn the Object
    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }
}
