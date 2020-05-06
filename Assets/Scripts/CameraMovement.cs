using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script to find object and follow it along screen
*/

public class CameraMovement : MonoBehaviour {

	public Transform target;
	public float smoothing;
	public Vector2 maxPosition;
	public Vector2 minPosition;
//11.48
//6.1
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(transform.position != target.position){
			Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);

			//Boundaries
			
			targetPosition.x = Mathf.Clamp(targetPosition.x,maxPosition.x,minPosition.x);
			targetPosition.y = Mathf.Clamp(targetPosition.y,maxPosition.y,minPosition.y);

			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
		}
	}

}