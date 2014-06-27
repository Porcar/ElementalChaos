using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject wizard; //*
	public GameObject orb; //*
	GameObject shootPoint; //*

	public RaycastHit hit;
	public Transform spell;
	public string animAttack;
	public float delay, reach, delayAnim;
	float counterDelay;
	bool shootPrepared;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("PrepareShoot", delay, delay);
		wizard = GameObject.FindGameObjectWithTag ("Shootme");
		orb = GameObject.FindGameObjectWithTag ("Orb");
	}

	void PrepareShoot(){
		float distanceToOrb = Vector3.Distance (this.gameObject.transform.position, orb.transform.position);//*
		float distanceToWizzard = Vector3.Distance (this.gameObject.transform.position, wizard.transform.position);//*
		if (distanceToOrb < distanceToWizzard)
			shootPoint = orb;
		else
			shootPoint = wizard;

		direction =  shootPoint.transform.position - transform.position;

			if (Physics.Raycast (this.transform.position, direction, out hit, reach)) {
			if (hit.collider.tag == "Player" ||  hit.collider.name == "Orb") {
					this.transform.parent.gameObject.animation.Play (animAttack);
				shootPrepared =true;
				}
			}
		}

	void Shoot(){
		Instantiate (spell, this.transform.position, Quaternion.LookRotation (direction));
	}

	// Update is called once per frame
	void Update () {
		if (shootPrepared) {
			counterDelay+= Time.deltaTime;
				}

		if (shootPrepared && counterDelay >= delayAnim) {
			Shoot();
			shootPrepared = false;	
			counterDelay = 0;
		}



		direction.Normalize ();
		Debug.DrawRay (transform.position, direction *15 , Color.green);
	}
}
