using UnityEngine;
using System.Collections;

public class Autodestruct : MonoBehaviour {

	public float timeDestruction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeDestruction -= Time.deltaTime;
		if(timeDestruction <=0){
			Destroy(this.gameObject);
		}
	}
}
