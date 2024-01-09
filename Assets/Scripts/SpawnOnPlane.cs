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

    void Update()
    {
        // Check if the player touches the screen and hits an AR plane
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;

            if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                SpawnObject(hitPose.position, Quaternion.identity);
            }
        }
    }

    private void SpawnObject(Vector3 position, Quaternion rotation)
    {
        // Instantiate the objectToSpawn at the given position and rotation
        Instantiate(objectToSpawn, position, rotation);
    }

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
}
