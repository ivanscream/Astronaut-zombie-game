using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
[Header ("Wheel Colliders")]
 [SerializeField] WheelCollider frontRight;
 [SerializeField] WheelCollider frontLeft;
 [SerializeField] WheelCollider rearRight;
 [SerializeField] WheelCollider rearLeft;
 [Header ("WHeel meshes")]
 [SerializeField] Transform frontRightRotation;
 [SerializeField] Transform frontLeftRotation;
 [SerializeField] Transform rearRightRotation;
 [SerializeField] Transform rearLeftRotation;
 public float acceleration = 500f;
 public float brakingForce = 300f;
 private float currentAcceleration = 0f;
 private float currentBreakForce = 0f;
public float wheelTurnAngle = 15f;
private float currentTurnAngle = 0f;

    private void FixedUpdate() {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");


     if(Input.GetKey(KeyCode.Space))
        currentBreakForce = brakingForce;
        else currentBreakForce = 0f;

        rearRight.motorTorque = currentAcceleration;
        rearLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = wheelTurnAngle * Input.GetAxis("Horizontal");

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftRotation);
        UpdateWheel(frontRight, frontRightRotation);
        UpdateWheel(rearLeft, rearLeftRotation);
        UpdateWheel(rearRight, rearRightRotation);
    }

    void UpdateWheel(WheelCollider wcollider, Transform wtransform) {
        Vector3 position;
        Quaternion rotation;
        wcollider.GetWorldPose(out position, out rotation);
        wtransform.position = position;
        wtransform.rotation = rotation;
    }

}
