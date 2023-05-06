using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving: MonoBehaviour
{
    public Transform[] _waypoints;
    public float  _speed;
    public int startingPoint;

    private int i;

    void Start()
    {
        transform.position = _waypoints[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, _waypoints[i].position) < 0.02f)
        {
            i++;
            if (i == _waypoints.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[i].position, _speed * Time.deltaTime);
    }
}
