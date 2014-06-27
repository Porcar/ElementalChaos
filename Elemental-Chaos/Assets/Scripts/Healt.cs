using UnityEngine;
using System.Collections;

public class Healt : MonoBehaviour {

	public float health;
	static public float currHealth;
	public float fractionHealth;
	float DieTime=0;

	public GameObject h1, h2, h3, h4, h5;
	Color color, colorPoint, transparent;
	public static bool isFireShield, isWaterShield, isEarthShield, isAirShield, isElementShield;
	

	// Use this for initialization
	void Start () {
		color = Color.gray; colorPoint = Color.gray; transparent.a = 0.0f;
		health = 100.0f;
		currHealth = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.gameObject.transform.position.y < 18.0f) 
			Application.LoadLevel (3);
				

		if (currHealth<100)
			currHealth += Time.deltaTime;
		fractionHealth = currHealth / health;
		setOpacity ();
		if(currHealth<=0){
				GameObject.Find("TheWizard").gameObject.animation.Play("Dying");
			DieTime +=Time.deltaTime;
		}
		if (DieTime > 2)
			Application.LoadLevel (3);
	}


	
	void setOpacity(){
		if (fractionHealth <= 0.2) {
			colorPoint.a = fractionHealth / 0.2f;
			h1.guiTexture.color = colorPoint;
			h2.guiTexture.color = transparent;
			h3.guiTexture.color = transparent;
			h4.guiTexture.color = transparent;
			h5.guiTexture.color = transparent;
		}

		if (fractionHealth > 0.2 && fractionHealth <= 0.4) {
			colorPoint.a = (fractionHealth-0.2f) / 0.2f;
			h1.guiTexture.color = color;
			h2.guiTexture.color = colorPoint;
			h3.guiTexture.color = transparent;
			h4.guiTexture.color = transparent;
			h5.guiTexture.color = transparent;
		}

		if (fractionHealth > 0.4 && fractionHealth <= 0.6) {
			colorPoint.a = (fractionHealth-0.4f) / 0.2f;
			h1.guiTexture.color = color;
			h2.guiTexture.color = color;
			h3.guiTexture.color = colorPoint;
			h4.guiTexture.color = transparent;
			h5.guiTexture.color = transparent;
		}

		if (fractionHealth > 0.6 && fractionHealth <= 0.8) {
			colorPoint.a = (fractionHealth-0.6f) / 0.2f;
			h1.guiTexture.color = color;
			h2.guiTexture.color = color;
			h3.guiTexture.color = color;
			h4.guiTexture.color = colorPoint;
			h5.guiTexture.color = transparent;
		}

		if (fractionHealth > 0.8) {
			colorPoint.a = (fractionHealth-0.8f) / 0.2f;
			h1.guiTexture.color = color;
			h2.guiTexture.color = color;
			h3.guiTexture.color = color;
			h4.guiTexture.color = color;
			h5.guiTexture.color = colorPoint;
		}
	}

	void OnGUI(){

	}
}
