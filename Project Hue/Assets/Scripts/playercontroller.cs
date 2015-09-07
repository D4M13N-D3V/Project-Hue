using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public string currentDirection = "Down";
	public float colorPercent = 255.00F;
	public int health;
	public float speed;
	public Transform firePos;
	public int currentAngle = 0;
	bool canShoot = true;

	//WEAPON OPTIONS
	
	public GameObject projectile;
	public float attackCoolDownTime = 1;
	public float attackColorTake = 1;
	public float attackDamage = 1;

	public Animator animator; 

	public GameObject hud;
	public GameObject colorthing;
	public GameObject healththing;


	public Transform camera;
	//PLACE HOLDER VARIABLES
	
	public bool usePlaceHolders = true;
	
	public Texture downStill;
	public Texture upStill;
	public Texture leftStill;
	public Texture rightStill;
	public GameObject cameraParent;
	public Renderer renderer;
	public Rigidbody rigidbody;
	public GameObject colorgauge;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		renderer = GetComponent<Renderer> ();
		rigidbody = GetComponent<Rigidbody> ();
		cameraParent = GameObject.Find ("CameraParent");
		hud = GameObject.Find ("HUD");
		float percent = 1-((255 - colorPercent) / 255);
		colorthing = hud.transform.GetChild(0).gameObject;
		healththing = hud.transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (colorPercent > 100) {
			
			float percent = 1-((155 - (colorPercent-100)) / 155);
			colorthing.GetComponent<Image>().fillAmount=percent;
			healththing.GetComponent<Image>().fillAmount=1;
		} else {
			
			float percent = 1-((100 - (colorPercent)) / 100);
			
			colorthing.GetComponent<Image>().fillAmount=0;
			healththing.GetComponent<Image>().fillAmount=percent;
		}

		//CONTROLLER
		//--------------------------------------------------------------------
		//Movment Controls

		Vector3 newvel = new Vector3 (0, 0, 0);
		if(Input.GetAxis ("CONTROLLER_HLS")<-0.1F || Input.GetAxis ("KEYBOARD_HMOVE")<0F){
			newvel = newvel+(transform.right*speed);
		}
		//RIGHT
		if(Input.GetAxis("CONTROLLER_HLS")>0.1F || Input.GetAxis("KEYBOARD_HMOVE")>0F){
			newvel = newvel+(-transform.right*speed);
		}
		//UP
		if(Input.GetAxis ("CONTROLLER_VLS")>0.1F || Input.GetAxis ("KEYBOARD_VMOVE")>0F){
			newvel = newvel+(transform.up*speed);
		}
		//DOWN
		if(Input.GetAxis("CONTROLLER_VLS")<-0.1F || Input.GetAxis("KEYBOARD_VMOVE")<0F){
			newvel = newvel+(-transform.up*speed);
		}

		if (newvel == new Vector3 (0, 0, 0)) {
			animator.SetBool("Walking",false);
		} else {
			animator.SetBool("Walking",true);
		}	
		rigidbody.velocity = newvel;


		//--------------------------------------------------------------------
		// Direction Controls




		if(Input.GetAxis ("CONTROLLER_HRS")<-0.4F && Input.GetAxis ("CONTROLLER_VRS")<-0.1F || Input.GetAxis ("KEYBOARD_HFACE")<-0F && Input.GetAxis ("KEYBOARD_VFACE")<0.0F){
			currentDirection = "LeftUp";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		else if(Input.GetAxis("CONTROLLER_HRS")>0.4F && Input.GetAxis ("CONTROLLER_VRS")<-0.4F || Input.GetAxis("KEYBOARD_HFACE")>0F && Input.GetAxis ("KEYBOARD_VFACE")<-0F){
			currentDirection = "RightUp";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		else if(Input.GetAxis ("CONTROLLER_HRS")<-0.4F && Input.GetAxis ("CONTROLLER_VRS")>0.4F || Input.GetAxis ("KEYBOARD_HFACE")<-0F && Input.GetAxis ("KEYBOARD_VFACE")>0F){
			currentDirection = "LeftDown";
			renderer.material.mainTexture=leftStill;
		}
		//DOWN
		else if(Input.GetAxis ("CONTROLLER_HRS")>0.4F && Input.GetAxis("CONTROLLER_VRS")>0.4F || Input.GetAxis ("KEYBOARD_HFACE")>0F && Input.GetAxis("KEYBOARD_VFACE")>0F){
			currentDirection = "RightDown";
			renderer.material.mainTexture=rightStill;
		}
		else if(Input.GetAxis ("CONTROLLER_HRS")<-0.4F || Input.GetAxis ("KEYBOARD_HFACE")<-0F){
			currentDirection = "Left";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		else if(Input.GetAxis("CONTROLLER_HRS")>0.4F || Input.GetAxis("KEYBOARD_HFACE")>0F){
			currentDirection = "Right";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		else if(Input.GetAxis ("CONTROLLER_VRS")>0.4F || Input.GetAxis ("KEYBOARD_VFACE")>0F){
			currentDirection = "Down";
			renderer.material.mainTexture=downStill;
		}
		//DOWN
		else if(Input.GetAxis("CONTROLLER_VRS")<-0.4F || Input.GetAxis("KEYBOARD_VFACE")<0F){
			currentDirection = "Up";
			renderer.material.mainTexture=upStill;
		}

		if (currentDirection == "Up") {
			animator.SetInteger ("Dir", 1);
		}
		else if (currentDirection == "RightUp") {
			animator.SetInteger ("Dir", 1);
		}
		else if (currentDirection == "LeftUp") {
			animator.SetInteger ("Dir", 1);
		}
		else if (currentDirection == "Down") {
			animator.SetInteger ("Dir", 2);
		}
		else if (currentDirection == "RightDown") {
			animator.SetInteger ("Dir", 2);
		}
		else if (currentDirection == "LeftDown") {
			animator.SetInteger ("Dir", 2);
		}
		else if (currentDirection == "Left") {
			animator.SetInteger ("Dir", 3);
		}
		else if (currentDirection == "Right") {
			animator.SetInteger ("Dir", 4);
		}

		//--------------------------------------------------------------------
		//MISC Controls
		if (Input.GetAxis ("CONTROLLER_RIGHTTRIGGER") > 0 || Input.GetAxis("KEYBOARD_ATTACK")>0) {
			if (canShoot && colorPercent-attackColorTake>0 && (colorPercent-attackColorTake)>15) {
				GameObject temp = Instantiate (projectile, firePos.position, Quaternion.identity) as GameObject;
				canShoot=false;
				StartCoroutine(coolDown());
				colorPercent = colorPercent-attackColorTake;
				temp.GetComponent<placeholderProjectile>().damage=attackDamage;
			}
		}
		
		if (Input.GetButtonDown ("CONTROLLER_LEFTBUMPER") || Input.GetButtonDown ("KEYBOARD_ANGLESWITCHLEFT")) {
			currentAngle=currentAngle-90;
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, -90, 0);
			for (int i = 0; i < trees.Length; i++){
				trees [i].transform.eulerAngles = trees [i].transform.eulerAngles + new Vector3 (0, -90, 0);
		}

		}
		if (Input.GetButtonDown ("CONTROLLER_RIGHTBUMPER")||Input.GetButtonDown ("KEYBOARD_ANGLESWITCHLEFT")) {
			currentAngle=currentAngle+90;
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, 90, 0);
			for (int i = 0; i < trees.Length; i++) {
				trees [i].transform.eulerAngles = trees [i].transform.eulerAngles + new Vector3 (0, 90, 0);
			}
		}
		//--------------------------------------------------------------------


		// SPECIAL KEYBOARD AND MOUSE ONLY CONTROLS

		// MOUSE AIM
		Vector2 mousepos = Input.mousePosition;



	

	}

	IEnumerator coolDown(){
		yield return new WaitForSeconds(attackCoolDownTime);
		canShoot = true;
	}

	public void damagePlayer(float amount){
		colorPercent = colorPercent - amount;
		animator.SetTrigger ("Hit");
		Vector3 screenPos = camera.gameObject.GetComponent<Camera>().WorldToScreenPoint(transform.position);
	}










}
