using UnityEngine;
using System.Collections;



public class DamageNPC : MonoBehaviour {

	public float health;
	public bool fireInm;
	public bool waterInm;
	public bool earthInm;
	public bool airInm;
	public string deadAnimation;


	public void Dead (){
		Destroy (this.gameObject);
		}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			this.gameObject.animation.Play(deadAnimation);
			Invoke("Dead",3.0f);
				}

	}
}
