using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
	
	public float speed = 6;
	public float mass;
	public float normalDamage, shieldDamage, generalShield;
	public bool isWater, isFire, isEarth, isAir;
	
	public GameObject explosionPrefab = null;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime*speed);
		rigidbody.AddTorque(Vector3.up * 100);

		if (mass != 0) {
			transform.Rotate (Vector3.right * Time.deltaTime * mass); 
			//transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);   descomentar para ver un efecto cool
		}
		
	}
	
	void explode() {
		GameObject explosion = (GameObject)Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		explosion.audio.Play ();
		Destroy (gameObject);
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.transform.tag == "Enemy"){
			Debug.Log("LE PEGUEEE");
			if(collision.gameObject.GetComponent<DamageNPC>().fireInm && isFire
			   ||collision.gameObject.GetComponent<DamageNPC>().waterInm && isWater
			   ||collision.gameObject.GetComponent<DamageNPC>().airInm && isFire
			   ||collision.gameObject.GetComponent<DamageNPC>().earthInm && isEarth
			   )
				collision.gameObject.GetComponent<DamageNPC>().health -= shieldDamage;
			else
				collision.gameObject.GetComponent<DamageNPC>().health -= normalDamage;
		}
		explode ();
	}

	void damage(){

			if(Healt.isFireShield && isFire || Healt.isWaterShield && isWater ||
		   	   Healt.isEarthShield && isEarth || Healt.isAirShield && isAir)
				Healt.currHealth -= shieldDamage;
			else if(Healt.isElementShield)
				Healt.currHealth -= generalShield;
			else
				Healt.currHealth -= normalDamage;

		}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.transform.name == "DamagePoint" || other.gameObject.transform.name=="Orb") {
			damage();
			explode ();
		}

	}
}
