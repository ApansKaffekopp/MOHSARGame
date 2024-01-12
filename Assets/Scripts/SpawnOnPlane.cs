using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;
using Unity.Collections;

public class SpawnOnPlane : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; // Your prefab
    [SerializeField] public GameObject rotateInput;
    [SerializeField] public GameObject infoText;
    
    public ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private bool isObjectSpawned = false;

    private void Start()
    {
        
    }

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
        if (!isObjectSpawned)
        {
            // Instantiate the objectToSpawn at the given position and rotation
            Instantiate(objectToSpawn, position, rotation);
            isObjectSpawned = true;
            OpenRotateMenu();
        }
    }

    private void OpenRotateMenu()
    {
        rotateInput.SetActive(true);
        infoText.SetActive(false);
    }
}
