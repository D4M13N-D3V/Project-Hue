﻿

using UnityEngine;
using System.Collections;

public class CameraFacing : MonoBehaviour
{ 
	public Transform cameraToLookAt;
		
	 void Update()
	 {
		 Vector3 v = cameraToLookAt.transform.position - transform.position;
		v.x = 0.0f;

		v.z = 0.0f;
		 
		//v.y = 90;
		 transform.LookAt(cameraToLookAt.transform.position - v);
		transform.eulerAngles = new Vector3 (90, transform.eulerAngles.y, transform.eulerAngles.z);
		 }

}