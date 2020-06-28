using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{ 
    public AudioManager am;
    public Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        // am = FindObjectOfType<AudioManager>();
        // FindObjectOfType<AudioManager>().Play("StepOnGravel");
    }

    void Update()
    {
        Vector3 curPos = transform.position;
        if(curPos != lastPos) {
            // am.Play("StepOnGravel");
            FindObjectOfType<AudioManager>().Play("StepOnGravel");
        }
        lastPos = curPos;
    }
}
