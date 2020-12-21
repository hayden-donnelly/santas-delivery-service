using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    
public class TruckController : MonoBehaviour 
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    [SerializeField] float maxMotorTorque; // maximum torque the motor can apply to wheel
    [SerializeField] float maxSteeringAngle; // maximum steer angle the wheel can have
    [SerializeField] GameObject wheelVisual;
    [SerializeField] List <Transform> wheelVisuals = new List<Transform>();

    void Start()
    {
        if(wheelVisual != null)
        {
            foreach(AxleInfo axleInfo in axleInfos)
            {
                Transform aL = Instantiate(wheelVisual, axleInfo.leftWheel.transform.position, Quaternion.Euler(0, 0, 0)).transform;
                Transform aR = Instantiate(wheelVisual, axleInfo.rightWheel.transform.position, Quaternion.Euler(0, 0, 0)).transform;

                wheelVisuals.Add(aL);
                wheelVisuals.Add(aR);
            }
        }
    }
    float motor;
    float steering;
    void Update()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
    }
    public void FixedUpdate()
    {
        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        UpdateWheelVisuals();

        foreach (AxleInfo axleInfo in axleInfos) 
        {
            if(axleInfo.steering) 
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if(axleInfo.motor) 
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
    void UpdateWheelVisuals()
    {
        // I fucking hate this method.
        for(int i = 0; i < 2; i++)
        {
            Quaternion q;
			Vector3 p;

            int index = i * 2;

            // Left Wheel.
            axleInfos[i].leftWheel.GetWorldPose(out p, out q);
            wheelVisuals[index + 1].position = p;
            wheelVisuals[index + 1].rotation = q;  

            // Right Wheel.
            axleInfos[i].rightWheel.GetWorldPose(out p, out q);
            wheelVisuals[index].position = p;
            wheelVisuals[index].rotation = q;
        }
    }
}
[System.Serializable]
public class AxleInfo 
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
