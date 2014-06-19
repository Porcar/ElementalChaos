using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
	
	public float speed = 6;
	public float mass;
	
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
		if (collision.gameObject.tag == "player") {
		}
		explode ();
		
	}
}
