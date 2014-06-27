using UnityEngine;
using System.Collections;

public class Scene1 : MonoBehaviour {

	float counter=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;


		if (Input.GetMouseButtonDown (0) || counter > 8)
			Application.LoadLevel (4);
	}
}
