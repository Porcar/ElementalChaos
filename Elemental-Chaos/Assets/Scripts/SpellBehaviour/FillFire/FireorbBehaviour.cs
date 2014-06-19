using UnityEngine;
using System.Collections;

public class FireorbBehaviour : MonoBehaviour {

	public int rotateSpeed;
	
	void Start () {
		if (rotateSpeed == 0)
			rotateSpeed = 100;
		Destroy (this.gameObject, 2);
	}
	
	void Update () {
		//transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
		transform.position = Vector3.MoveTowards(transform.position, this.transform.parent.position, .01f);
	}
}
