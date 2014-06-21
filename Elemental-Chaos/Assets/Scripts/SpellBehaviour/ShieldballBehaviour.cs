using UnityEngine;
using System.Collections;

public class ShieldballBehaviour : MonoBehaviour {

	GameObject center;
	Vector3 desiredPosition;
	float radius;

	// Use this for initialization
	void Start () {
		center = GameObject.Find ("Center");
		radius = 3;
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround(center.transform.position, -transform.up, Time.deltaTime * 180f);
		desiredPosition = (this.transform.position - center.transform.position).normalized * 1.0f + center.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 100f);
		transform.position = new Vector3(transform.position.x, center.transform.position.y, transform.position.z);
	}
}
