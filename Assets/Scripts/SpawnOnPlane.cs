using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;
using Unity.Collections;

public class SpawnOnPlane : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; // Your prefab
    public ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;
    private bool planeSpawned = false;

    void Update()
    {
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
        if (!planeSpawned)
        {
            // Instantiate the objectToSpawn at the given position and rotation
            Instantiate(objectToSpawn, position, rotation);
            planeSpawned = true;
        }
    }

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
}
