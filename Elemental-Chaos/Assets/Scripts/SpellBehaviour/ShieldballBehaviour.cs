using UnityEngine;
using System.Collections;

public class ShieldballBehaviour : MonoBehaviour {

	GameObject center;
	Vector3 desiredPosition;
	float radius;
	float duration=15.0f;

	// Use this for initialization
	void Start () {
		center = GameObject.Find ("Center");
		radius = 3;
		OnShield ();
	}


	void OnShield(){
		switch (this.gameObject.name) {
		case("Shieldball(Clone)"):
			Healt.isElementShield = true;
			break;
		case("ShieldIce(Clone)"):
			Healt.isWaterShield = true;
			break;
		case("ShieldFire(Clone)"):
			Healt.isFireShield = true;
			break;
		case("ShieldEarth(Clone)"):
			Healt.isEarthShield= true;
			break;
		case("ShieldAir(Clone)"):
			Healt.isAirShield= true;
			break;
		}

	}

	void OffShield(){
		switch (this.gameObject.name) {
		case("Shieldball(Clone)"):
			Healt.isElementShield = false;
			break;
		case("ShieldIce(Clone)"):
			Healt.isWaterShield = false;
			break;
		case("ShieldFire(Clone)"):
			Healt.isFireShield = false;
			break;
		case("ShieldEarth(Clone)"):
			Healt.isEarthShield = false;
			break;
		case("ShieldAir(Clone)"):
			Healt.isAirShield = false;
			break;
	}
		
	}

	void OnDestroy(){
		OffShield ();
	}

	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;

		transform.RotateAround(center.transform.position, -transform.up, Time.deltaTime * 180f);
		desiredPosition = (this.transform.position - center.transform.position).normalized * 1.0f + center.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 100f);
		transform.position = new Vector3(transform.position.x, center.transform.position.y, transform.position.z);

		if (duration <= 0) {
			OffShield();
			Destroy (this.gameObject);
			}
	}
}
