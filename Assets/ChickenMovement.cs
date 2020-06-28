using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour {
    public GameObject[] waypoints;
    int current = 0;
    public float speed = 3f;
    public float wPointRadius = 1f;

    void Update () {
        if (Vector3.Distance (waypoints[current].transform.position, transform.position) < wPointRadius) {
            current++;
            if (current >= waypoints.Length) {
                current = 0;

            }
        }
        transform.position = Vector3.MoveTowards (transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
}