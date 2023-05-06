using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
    public float FollowSpeed = 8f;
    public float yOffset = 1f;
    public Transform target;

    void Start() {
        transform.position = new Vector3(target.position.x,target.position.y + yOffset,-10f);
    }

    void Update() {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}