using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	
	public GameObject texture;
	float counter=0;
	public Color color = Color.black ;
	
	// Use this for initialization
	void Start () {
		color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > 3.8f) {
			color.a -= Time.deltaTime*1.3f ;
			texture.guiTexture.color = color;
		}
	}
}
