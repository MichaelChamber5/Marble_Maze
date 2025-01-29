using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForces : MonoBehaviour
{
    [SerializeField] float acceleration;
    GameObject cam;
    [SerializeField] float maxVelocity;
    CameraMovement camScript;

    Vector3 gravityDirection;
    Rigidbody rbody;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        camScript = cam.GetComponent<CameraMovement>();
        rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        gravityDirection = camScript.GetRotation();
        if(rbody.velocity.magnitude < maxVelocity)
        {
            rbody.velocity = rbody.velocity + (gravityDirection * acceleration);
        }
    }
}
