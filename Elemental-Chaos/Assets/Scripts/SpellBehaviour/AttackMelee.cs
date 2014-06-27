using UnityEngine;
using System.Collections;

public class AttackMelee : MonoBehaviour {

	public GameObject wizard;
	public GameObject orb; 
	GameObject shootPoint;
	public RaycastHit hit;
	public Transform spell;
	public string animAttack;
	public float delay, reach, delayAnim;
	float counterDelay;
	public float damagePoints;
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


		direction =  wizard.transform.position - transform.position;
		direction.Normalize ();

		if (Physics.Raycast (this.transform.position, direction, out hit, reach)) {
			if (hit.collider.tag == "Player" ||  hit.collider.tag == "Orb") {
				this.transform.parent.gameObject.animation.Play (animAttack);
				Invoke("Shoot", delayAnim);

			}
		}
	}
	
	void Shoot(){
		Healt.currHealth -= damagePoints;

	}

}
	

