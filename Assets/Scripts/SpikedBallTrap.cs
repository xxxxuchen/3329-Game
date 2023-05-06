using System.Collections;
using System.Collections.Generic;using UnityEngine;

public class SpikedBallTrap : MonoBehaviour
{
    public GameObject chainPrefab;
    public GameObject spikedBallPrefab;
    public GameObject chainAndBlockParent;
    public float delta;
    public float radius;
    public float anglesRange;
    public float startingAngle;
    public float rotationSpeed;

    private Vector3 center;
    private float currentAngle;

    private void Start()
    {
        center = transform.position;
        currentAngle = startingAngle;
        SpawnChain();
        SpawnSpikedBall();
    }

    private void Update()
    {
        currentAngle -= rotationSpeed * Time.deltaTime;
        currentAngle %= 360;

        var offset = new Vector3(Mathf.Sin(currentAngle), 0, Mathf.Cos(currentAngle)) * radius;
        chainAndBlockParent.transform.position = center + offset;
    }

    private void SpawnChain()
    {
        var chainParent = new GameObject("Chain Parent");
        chainParent.transform.parent = chainAndBlockParent.transform;
        chainParent.transform.localPosition = Vector3.zero;
    
        int numSegments = Mathf.FloorToInt(anglesRange / delta);
        float angleStep = anglesRange / numSegments;
        float currentChainAngle = currentAngle;
    
        for (int i = 0; i < numSegments; i++)
        {
            var segment = Instantiate(chainPrefab, chainParent.transform);
            segment.transform.localPosition = new Vector3(Mathf.Sin(currentChainAngle), 0, Mathf.Cos(currentChainAngle)) * radius;
            segment.transform.localRotation = Quaternion.Euler(0, -currentChainAngle * Mathf.Rad2Deg, 0);
            currentChainAngle += angleStep;
        }
    }
    
    private void SpawnSpikedBall()
    {
        var chainParent = chainAndBlockParent.transform.Find("Chain Parent");
        var lastSegment = chainParent.GetChild(chainParent.childCount - 1);
        var spikedBall = Instantiate(spikedBallPrefab, lastSegment.transform);
        spikedBall.transform.localPosition = Vector3.zero;
    }
}

