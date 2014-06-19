using UnityEngine;
using System.Collections;

public class FillwaterBehaviour : MonoBehaviour {

	public int rotateSpeed;

	void Start () {
		Power.water_rate = 0.08f;
		if (rotateSpeed == 0)
			rotateSpeed = 300;
		Destroy (this.transform.gameObject, 30.0f);
	}
	
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime* rotateSpeed);
		transform.position = Vector3.MoveTowards(transform.position, this.transform.parent.position, .02f);
	}

	void OnDestroy(){
		Power.water_rate = 0.03f;
	}
}
