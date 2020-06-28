using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;
    public Vector3 velocity;
    public Vector3 otherVelocity;
    public AudioManager am;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float audioStepLengthWalk = 1f;
    public float overallSpeed;

    public bool collision = false;
    public bool step = false;

    void Start () {
        am = FindObjectOfType<AudioManager> ();
        audioStepLengthWalk = 1f;
    }

    // Update is called once per frame
    void Update () {

        overallSpeed = controller.velocity.magnitude;

        if(overallSpeed > 0.0000000000000001f) {
            step = true;
        }
        else {
            step = false;
        }

        float x = Input.GetAxis ("Horizontal"); // W = 1, S = -1 
        float z = Input.GetAxis ("Vertical"); // A = -1, D = 1

        Vector3 move = transform.right * x + transform.forward * z;

        velocity.y += gravity * Time.deltaTime;

        controller.Move (move * speed * Time.deltaTime);
        controller.Move (velocity * Time.deltaTime);
    }

    void OnControllerColliderHit (ControllerColliderHit hit) {

        if (controller.velocity.magnitude > 0 && hit.gameObject.tag == "Street" && controller.isGrounded) {
            am.Stop ("StepOnGravel");
            am.Stop ("StepOnGrass");
            am.Play ("StepOnStreet");
            StartCoroutine (WaitForFootSteps (audioStepLengthWalk));
        } else if (controller.velocity.magnitude > 0 && hit.gameObject.tag == "Gravel" && controller.isGrounded) {
            am.Stop ("StepOnStreet");
            am.Stop ("StepOnGrass");
            am.Play ("StepOnGravel");
            StartCoroutine (WaitForFootSteps (audioStepLengthWalk));
        } else if (controller.velocity.magnitude > 0 && hit.gameObject.tag == "Grass" && controller.isGrounded) {
            am.Stop ("StepOnStreet");
            am.Stop ("StepOnGravel");
            am.Play ("StepOnGrass");
            StartCoroutine (WaitForFootSteps (audioStepLengthWalk));
        }
    }

    IEnumerator WaitForFootSteps (float stepsLength) {
        step = false;
        yield return new WaitForSeconds (stepsLength);
    }

}