using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField]
    private PaintBall paintBallPrefab;

    [SerializeField]
    public Transform spawnPoint;

    [SerializeField]
    private float reloadTime;

    private PaintBall currentPaintBall;

    private bool isReloading;

    [SerializeField]
    private MeshRenderer myRenderer;

    [SerializeField]
    public int arrayLength;
    public int currentMaterialIndex = 0;
	
	[SerializeField]
    LineRenderer lineRenderer;

    //ToDo
    //Tweak until the trajectory looks good
    [SerializeField]
    private int numPoints = 50;
    [SerializeField]
    private float timeBetweenPoints = 0.1f;

    [SerializeField]
    private LayerMask CollidableLayers;

    private Material currentMaterial;


    public void renderTrejectory(Vector3 direction, float power)
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPoint = spawnPoint.position;
        Vector3 startingVelocity = spawnPoint.TransformDirection(Vector3.forward + direction) * power;

        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPoint + t * startingVelocity;
            newPoint.y = startingPoint.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 0.01f, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());
    }

    public void resetTrejectory()
    {
        lineRenderer.positionCount = 0;
    }

    public void Reload()
    {
        if (isReloading || currentPaintBall != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
    public void Shoot(Vector3 direction, float power)
    {
        if (isReloading) return;
        currentPaintBall = Instantiate(paintBallPrefab, spawnPoint);
        var force = spawnPoint.TransformDirection((Vector3.forward + direction) * power);
        currentPaintBall.Move(force);
        currentPaintBall = null;
        //Reload();
    }


    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        arrayLength = paintBallPrefab.materials.Length;
        paintBallPrefab.currentMaterialIndex = 0;
    }

    public void RotateColor() {
        // Cycle to the next material
        currentMaterialIndex = (currentMaterialIndex + 1) % arrayLength;
        paintBallPrefab.currentMaterialIndex = currentMaterialIndex;

        Material[] materials = myRenderer.materials;
        materials[3] = paintBallPrefab.materials[currentMaterialIndex];
        myRenderer.materials = materials;
        currentMaterial = paintBallPrefab.materials[currentMaterialIndex];
    }

    public Material GetCurrentMaterial(){
        return currentMaterial;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RotateColor();
        }
    }

}