using UnityEngine;
using System.Collections;

public class SpellOrb : MonoBehaviour {
	
	enum ELEMENTS {ether=0,fire=1,water=2,wind=3,earth=4,spirit=5};
	
	public GameObject camera;
	public RaycastHit hit;
	public Transform center;
	
	public GameObject wind, water, land, fire, spirit;

	bool oWind, oWater, oLand, oFire, oSpirit; //opaque
	float sWind, sWater, sLand, sFire, sSpirit; // percentaje to show
	static public bool isShield, isFill;
	
	public Texture crosshair;
	public Transform fireballPrefab;
	public Transform iceballPrefab;
	public Transform icefirePrefab;
	public Transform landballPrefab;
	public Transform shieldballPrefab;
	public Transform shieldfirePrefab;
	public Transform shieldicePrefab;
	public Transform fillwaterPrefab;
	public Transform fillfirePrefab;
	
	private GameObject fireballGameObject;
	private GameObject iceballGameObject;
	private GameObject icefireGameObject;
	private GameObject landballGameObject;
	private GameObject shieldGameObject;
	private Transform fillGameObject;
	
	Transform position;
	ELEMENTS[] myElements;
	float[] cooldowns;
	public int maxElements = 3;
	public int elementsSelected = 0;
	public float elementCooldown = 1;
	
	void Start () {
		myElements = new ELEMENTS[maxElements];
		cooldowns = new float[6];
		
		float iO = 0.31f; //initial opaccity
		sWind = iO; sWater = iO; sLand = iO; sFire = iO; sSpirit = iO;
		isShield = false; isFill = false;
	}
	
	
	void Update () {
		UpdateCooldowns ();
		HandleInput ();
	}
	
	void UpdateCooldowns ()
	{
		for(int i=1;i<6;i++){
			if(cooldowns[i]>0){
				cooldowns[i]-=Time.deltaTime;
				if(cooldowns[i]<0)
					cooldowns[i]=0;
			}
		}
	}
	
	void HandleInput ()
	{
		if(elementsSelected < 3){
			if (Input.GetKeyUp("1") && Power.sFire > 0.33) {
				selectRune(ELEMENTS.fire);
				Power.sFire -= 0.33f;
				oFire = true;
			}
			if (Input.GetKeyUp("2") && Power.sWater > 0.33) {
				selectRune(ELEMENTS.water);
				Power.sWater -= 0.33f;
				oWater = true;
			}
			if (Input.GetKeyUp("3") && Power.sWind > 0.33) {
				selectRune(ELEMENTS.wind);
				Power.sWind -= 0.33f;
				oWind = true;
			}
			if (Input.GetKeyUp("4") && Power.sLand > 0.33) {
				selectRune(ELEMENTS.earth);
				Power.sLand -= 0.33f;
				oLand = true;
			}
			if (Input.GetKeyUp("5") && Power.sSpirit > 0.33) {
				selectRune(ELEMENTS.spirit);
				Power.sSpirit -= 0.33f;
				oSpirit = true;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			Cast();
		}
		
		
	}
	
	void selectRune(ELEMENTS element){
		elementsSelected++;
		for (int i=0; i<maxElements; i++){
			if(myElements[i]==ELEMENTS.ether){
				if(cooldowns[(int)element]<=0){
					myElements[i]=element;
					cooldowns[(int)element]+=elementCooldown;
				}
				break;
			}
			
		}
		
	}

	void VerifyShield(){
		if (isShield) {
			Destroy(GameObject.Find("Shieldball(Clone)"));
		}
	}

	void VerifyFill(){
		if (isShield) {
			Destroy(GameObject.Find("FillWater(Clone)"));
			Destroy(GameObject.Find("FillFire(Clone)"));
		}
	}

	void Cast(){
		int spellCode = 0;
		for (int i=0; i<maxElements; i++) {
			spellCode += (int)myElements[i]*(int)Mathf.Pow(10,i);
		}

		Debug.Log ("spellcode"+spellCode);

		switch(spellCode){
		case 1:
			if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100.0f)){
				GameObject.Find("TheWizard").animation.Play("FireBallSpell"); //Loads the animation when click is pressed
				Vector3 dir = hit.point - this.transform.position;
				fireballGameObject = Instantiate(fireballPrefab,this.transform.position,Quaternion.LookRotation(dir)) as GameObject;
				Destroy(fireballGameObject, 10);
			}
			break;
			
			
		case 15: case 51:
			shieldGameObject = Instantiate(shieldfirePrefab,this.transform.position,Quaternion.identity) as GameObject;
			Destroy (shieldfirePrefab, 10);
			break;
			break;
			
		case 52: case 25:
			shieldGameObject = Instantiate(shieldicePrefab,this.transform.position,Quaternion.identity) as GameObject;
			Destroy (shieldicePrefab, 10);
			break;
			break;
			
		case 2:
			if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100.0f)){
				GameObject.Find("TheWizard").animation.Play("HelixSpell");
				Vector3 dir = hit.point - this.transform.position;
				iceballGameObject = Instantiate(iceballPrefab,this.transform.position,Quaternion.LookRotation(dir)) as GameObject;
				Destroy (iceballGameObject, 10);
			}
			
			break;
			
		case 21: case 12:
			if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100.0f)){
				icefireGameObject = Instantiate(icefirePrefab,hit.point, Quaternion.LookRotation(Vector3.up)) as GameObject;
			}
			
			break;
			
		case 3:
			Windblow.Cast(transform.position,camera.transform.forward);
			break;
			
		case 4:
			if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100.0f)){
				Vector3 dir = hit.point - this.transform.position;
				landballGameObject = Instantiate(landballPrefab,this.transform.position,Quaternion.LookRotation(dir)) as GameObject;
				Destroy (landballPrefab, 10);
			}
			break;
			
		case 5:
			VerifyShield();
			shieldGameObject = Instantiate(shieldballPrefab,this.transform.position,Quaternion.identity) as GameObject ;
			isShield = true;
			break;

		case 522: case 225: case 252:
			VerifyFill();
			Vector3 pos = new Vector3(center.transform.position.x, center.transform.position.y -1, center.transform.position.z);
			fillGameObject = Instantiate(fillwaterPrefab,pos,Quaternion.identity) as Transform ;
			fillGameObject.parent = center;
			isShield = true;
			break;


		case 511: case 115: case 151:
			VerifyFill();
			Vector3 posf = new Vector3(center.transform.position.x, center.transform.position.y -1, center.transform.position.z);
			fillGameObject = Instantiate(fillfirePrefab,posf,Quaternion.identity) as Transform ;
			fillGameObject.parent = center;
			isShield = true;
			break;

		default:
			break;
		}
		ClearElements();
	}
	Quaternion GetDirection(){
		//		Transform cam = Camera.main.transform;
		//		RaycastHit hit = new RaycastHit();
		//		if (Physics.Raycast (cam.position, cam.forward,out hit, 500)) {
		//			return Quaternion.LookRotation((hit.point-transform.position));
		//
		//		}
		//		return Quaternion.identity;
		return Quaternion.LookRotation (this.transform.forward);
	}
	
	void ClearElements(){
		elementsSelected = 0;
		oWind = false;
		oWater = false;
		oLand = false;
		oFire = false;
		oSpirit = false;
		for(int i=0;i<maxElements;i++){
			myElements[i]=ELEMENTS.ether;
		}
	}

	void ShowHideElements(){

		if (oWind) 
		{
			if(sWind < 1)
				sWind += Time.deltaTime * 2;
			wind.guiTexture.color = Color.gray * sWind;
		}
		else
		{
			if(sWind >= 0.31)
				sWind -= Time.deltaTime * 2;
			wind.guiTexture.color = Color.gray * sWind;
		}
		
		if (oLand)
		{
			if(sLand < 1)
				sLand += Time.deltaTime * 2;
			land.guiTexture.color = Color.gray * sLand;
		}
		else
		{
			if(sLand >= 0.31)
				sLand -= Time.deltaTime * 2;
			land.guiTexture.color = Color.gray * sLand;
		}
		
		if (oWater)
		{
			if(sWater < 1)
				sWater += Time.deltaTime * 2;
			water.guiTexture.color = Color.gray * sWater;
		}
		else
		{
			if(sWater >= 0.31)
				sWater -= Time.deltaTime * 2;
			water.guiTexture.color = Color.gray * sWater;
		}
		
		if (oFire)
		{
			if(sFire < 1)
				sFire += Time.deltaTime * 2;
			fire.guiTexture.color = Color.gray * sFire;
		}
		else
		{
			if(sFire >= 0.31)
				sFire -= Time.deltaTime * 2;
			fire.guiTexture.color = Color.gray * sFire;
		}
		
		if (oSpirit)
		{
			if(sSpirit < 1)
				sSpirit += Time.deltaTime * 2;
			spirit.guiTexture.color = Color.gray * sSpirit;
		}
		else
		{
			if(sSpirit >= 0.31)
				sSpirit -= Time.deltaTime * 2;
			spirit.guiTexture.color = Color.gray * sSpirit;
		}

		}
	
	void OnGUI(){
		
		ShowHideElements ();
		
		string text="";
		for(int i=0;i<6;i++){
			text+=","+cooldowns[i];
		}
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height),text );
		
		//GUI.DrawTexture(new Rect(Screen.width/2-25, Screen.height/2-25, 50, 50), crosshair, ScaleMode.ScaleToFit, true, 1.0F);
	}
}
