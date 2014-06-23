using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

	public Texture2D jugar;
	public Texture2D jugar_over;
	public Texture2D instrucciones;
	public Texture2D instrucciones_over;
	public Texture2D creditos;
	public Texture2D creditos_over;
	public Texture2D salir;
	public Texture2D salir_over;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

void OnMouseOver() {
	if (this.gameObject.name == "jugar")
		this.guiTexture.texture = jugar_over;
	if (this.gameObject.name == "instrucciones")
		this.guiTexture.texture = instrucciones_over;
	if (this.gameObject.name == "creditos")
		this.guiTexture.texture = creditos_over;
	if (this.gameObject.name == "salir")
		this.guiTexture.texture = salir_over;
}

void OnMouseExit() {
	if (this.gameObject.name == "jugar")
		this.guiTexture.texture = jugar;
	if (this.gameObject.name == "instrucciones")
		this.guiTexture.texture = instrucciones;
	if (this.gameObject.name == "creditos")
		this.guiTexture.texture = creditos;
	if (this.gameObject.name == "salir")
		this.guiTexture.texture = salir;
}

void OnMouseDown() {
	if (this.gameObject.name == "jugar")
		Application.LoadLevel (2);
	if (this.gameObject.name == "instrucciones")
		this.guiTexture.texture = instrucciones;
	if (this.gameObject.name == "creditos")
		this.guiTexture.texture = creditos;
	if (this.gameObject.name == "salir")
		Application.Quit ();
}
}
