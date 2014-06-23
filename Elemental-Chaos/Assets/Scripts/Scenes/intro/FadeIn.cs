using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

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
		if (counter > 5.0f) {
			color.a += Time.deltaTime * 0.5f ;
		}
		texture.guiTexture.color = color;
	}
}
