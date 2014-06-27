using UnityEngine;
using System.Collections;

public class inWords : MonoBehaviour {

	public float timeIn;
	public float timeOut;

	public GameObject texture;
	float counter=0;
	Color color;
	
	// Use this for initialization
	void Start () {
		color = Color.gray;
		color.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > timeOut) {
			color.a -= Time.deltaTime*1.3f ;
			texture.guiTexture.color = color;
		}
		else if (counter > timeIn) {
			color.a += Time.deltaTime * 0.5f ;
		}
		if (counter > 12) {
			Application.LoadLevel (1);
			}
		texture.guiTexture.color = color;
	}
}
