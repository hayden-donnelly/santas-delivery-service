using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	[SerializeField] float rotationSpeed;
	[SerializeField] Transform target;
	[SerializeField] float offset;
	Vector2 pitchMinMax = new Vector2(-40, 85);

	[SerializeField] float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void Update()
	{
		offset += Input.GetAxis("Mouse ScrollWheel") * 10;
		offset = Mathf.Clamp(offset, 6, 17);
	}
	void LateUpdate()
	{
		yaw += Input.GetAxis ("Mouse X") * rotationSpeed;
		pitch -= Input.GetAxis ("Mouse Y") * rotationSpeed;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		transform.position = target.position - transform.forward * offset;
	}
}
