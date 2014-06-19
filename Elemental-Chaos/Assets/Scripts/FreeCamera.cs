using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour {

	public float cameraSpeed = 1;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		transform.Rotate (Vector3.up, Input.GetAxis("Mouse X")*3, Space.World);

		transform.Rotate (Vector3.right, -Input.GetAxis("Mouse Y")*3, Space.Self);

		if(Input.GetKey(KeyCode.A)){
			transform.position = transform.position - transform.right*cameraSpeed*Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.D)){
			transform.position = transform.position + transform.right*cameraSpeed*Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.W)){
			transform.position = transform.position + transform.forward*cameraSpeed*Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.S)){
			transform.position = transform.position - transform.forward*cameraSpeed*Time.fixedDeltaTime;
		}

	}
}
