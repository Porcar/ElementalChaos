using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

	static public float sWind, sWater, sLand, sFire, sSpirit;
	static public float water_rate, wind_rate, land_rate, fire_rate, spirit_rate;

	public GameObject wind, water, land, fire, spirit;


	// Use this for initialization
	void Start () {
		sWind = 0.5f; sLand = 0.5f; sWater = 0.5f; sFire = 0.5f; sSpirit = 0.5f;
		water_rate = 0.03f; wind_rate = 0.03f; land_rate= 0.03f; fire_rate= 0.03f; spirit_rate= 0.03f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if(sWind < 1)
			sWind += Time.deltaTime * wind_rate;
		wind.guiTexture.color = Color.gray * sWind;
		
		if(sLand < 1)
			sLand += Time.deltaTime * land_rate;
		land.guiTexture.color = Color.gray * sLand;
		
		if(sWater < 1)
			sWater += Time.deltaTime * water_rate;
		water.guiTexture.color = Color.gray * sWater;
		
		if(sFire < 1)
			sFire += Time.deltaTime * fire_rate;
		fire.guiTexture.color = Color.gray * sFire;
		
		if(sSpirit < 1)
			sSpirit += Time.deltaTime * spirit_rate;
		spirit.guiTexture.color = Color.gray * sSpirit;
	}
}
