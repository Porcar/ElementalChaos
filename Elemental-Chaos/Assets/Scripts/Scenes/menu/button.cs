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
	public Texture2D iralmenu;
	public Texture2D iralmenu_over;
	public Texture2D reiniciar;
	public Texture2D reiniciar_over;
	public Texture2D salirdeljuego;
	public Texture2D salirdeljuego_over;
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
		if (this.gameObject.name == "iralmenu")
			this.guiTexture.texture = iralmenu_over;
		if (this.gameObject.name == "reiniciar")
			this.guiTexture.texture = reiniciar_over;
		if (this.gameObject.name == "salirdeljuego")
			this.guiTexture.texture = salirdeljuego_over;
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
		if (this.gameObject.name == "iralmenu")
			this.guiTexture.texture = iralmenu;
		if (this.gameObject.name == "reiniciar")
			this.guiTexture.texture = reiniciar;
		if (this.gameObject.name == "salirdeljuego")
			this.guiTexture.texture = salirdeljuego;
	}
	void OnMouseDown() {
		if (this.gameObject.name == "jugar")
			Application.LoadLevel (2);
		if (this.gameObject.name == "instrucciones") {
						Application.LoadLevel (5);
				}
		if (this.gameObject.name == "creditos")
			this.guiTexture.texture = creditos;
		if (this.gameObject.name == "salir" || this.gameObject.name == "salirdeljuego")
			Application.Quit ();
		
		if (this.gameObject.name == "iralmenu")
			Application.LoadLevel (1);
		if (this.gameObject.name == "reiniciar")
			Application.LoadLevel (2);
	}
}