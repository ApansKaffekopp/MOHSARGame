using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;
using Unity.Collections;

public class SpawnOnPlane : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; // Your prefab
    //[SerializeField] public GameObject goodSpawnIndicator;
    //[SerializeField] public GameObject badSpawnIndicator;
    
    public ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private bool isGoodPlacement = false;
    private bool isObjectSpawned = false;

    private void Start()
    {
        //goodSpawnIndicator.SetActive(false);
        //badSpawnIndicator.SetActive(false);
    }

    void Update()
    {

        //Find suitable place to spawen the canvas.
        /*if (!isObjectSpawned && arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            Vector3 hitPose = hits[0].pose.position;

            // Update indicator positions
            goodSpawnIndicator.transform.position = hitPose;
            badSpawnIndicator.transform.position = hitPose;

            //CheckIf good spawn position

            if (isGoodPlacement)
            {
                badSpawnIndicator.SetActive(false);
                goodSpawnIndicator.SetActive(true);
            }
            else
            {
                goodSpawnIndicator.SetActive(false);
                badSpawnIndicator.SetActive(true);
            }
        }
        else
        {
            badSpawnIndicator.SetActive(false);
            goodSpawnIndicator.SetActive(false);
        }*/

        // Check if the player touches the screen and hits an AR plane
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;

            if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                SpawnObject(hitPose.position, Quaternion.LookRotation(hitPose.forward, hitPose.up));
            }
        }
    }

    private void SpawnObject(Vector3 position, Quaternion rotation)
    {
        if (!isObjectSpawned)
        {
            // Instantiate the objectToSpawn at the given position and rotation
            Instantiate(objectToSpawn, position, rotation);
            isObjectSpawned = true;
        }
    }

    private bool checkIfGoodPlacment()
    {
        //Add conditions for placement.
        Debug.Log("NOT IMPLEMENTED");
        return true;
    }
}
