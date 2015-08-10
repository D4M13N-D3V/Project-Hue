using UnityEngine;
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
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		rigidbody = GetComponent<Rigidbody> ();
		cameraParent = GameObject.Find ("CameraParent");
	}
	
	// Update is called once per frame
	void Update () {

		//CONTROLLER
		//--------------------------------------------------------------------
		//Movment Controls
		
		
		
		//DIAGNOL DIRECTIONS//			

		//LEFTUP

		Vector3 newvel = new Vector3 (0, 0, 0);
		if(Input.GetAxis ("CONTROLLER_HLS")<-0.1F){
			newvel = newvel+(transform.right*speed);
		}
		//RIGHT
		if(Input.GetAxis("CONTROLLER_HLS")>0.1F){
			newvel = newvel+(-transform.right*speed);
		}
		//UP
		if(Input.GetAxis ("CONTROLLER_VLS")>0.1F){
			newvel = newvel+(transform.up*speed);
		}
		//DOWN
		if(Input.GetAxis("CONTROLLER_VLS")<-0.1F){
			newvel = newvel+(-transform.up*speed);
		}
		rigidbody.velocity = newvel;


		//--------------------------------------------------------------------
		// Direction Controls


		if(Input.GetAxis ("CONTROLLER_HRS")<-0.4F && Input.GetAxis ("CONTROLLER_VRS")<-0.1F){
			currentDirection = "LeftUp";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		else if(Input.GetAxis("CONTROLLER_HRS")>0.4F && Input.GetAxis ("CONTROLLER_VRS")<-0.4F){
			currentDirection = "RightUp";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		else if(Input.GetAxis ("CONTROLLER_HRS")<-0.4F && Input.GetAxis ("CONTROLLER_VRS")>0.4F){
			currentDirection = "LeftDown";
			renderer.material.mainTexture=downStill;
		}
		//DOWN
		else if(Input.GetAxis ("CONTROLLER_HRS")>0.4F && Input.GetAxis("CONTROLLER_VRS")>0.4F){
			currentDirection = "RightDown";
			renderer.material.mainTexture=upStill;
		}
		else if(Input.GetAxis ("CONTROLLER_HRS")<-0.4F){
			currentDirection = "Left";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		else if(Input.GetAxis("CONTROLLER_HRS")>0.4F){
			currentDirection = "Right";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		else if(Input.GetAxis ("CONTROLLER_VRS")>0.4F){
			currentDirection = "Down";
			renderer.material.mainTexture=downStill;
		}
		//DOWN
		else if(Input.GetAxis("CONTROLLER_VRS")<-0.4F){
			currentDirection = "Up";
			renderer.material.mainTexture=upStill;
		}
		//--------------------------------------------------------------------
		//MISC Controls
		if (Input.GetAxis ("CONTROLLER_RIGHTTRIGGER") > 0) {
			if (canShoot && colorPercent-attackColorTake>0) {
				Instantiate (projectile, firePos.position, Quaternion.identity);
				canShoot=false;
				StartCoroutine(coolDown());
				colorPercent = colorPercent-attackColorTake;
			}
		}
		
		if (Input.GetButtonDown ("CONTROLLER_LEFTBUMPER")) {
			currentAngle=currentAngle-90;
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, -90, 0);
			for (int i = 0; i < trees.Length; i++){
				trees [i].transform.eulerAngles = trees [i].transform.eulerAngles + new Vector3 (0, -90, 0);
		}

		}
		if (Input.GetButtonDown ("CONTROLLER_RIGHTBUMPER")) {
			currentAngle=currentAngle+90;
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, 90, 0);
			for (int i = 0; i < trees.Length; i++) {
				trees [i].transform.eulerAngles = trees [i].transform.eulerAngles + new Vector3 (0, 90, 0);
			}
		}
		//--------------------------------------------------------------------


		if(Input.GetAxis ("KEYBOARD_HMOVE")<0F){
			newvel = newvel+(transform.right*speed);
		}
		//RIGHT
		if(Input.GetAxis("KEYBOARD_HMOVE")>0F){
			newvel = newvel+(-transform.right*speed);
		}
		//UP
		if(Input.GetAxis ("KEYBOARD_VMOVE")>0F){
			newvel = newvel+(transform.up*speed);
		}
		//DOWN
		if(Input.GetAxis("KEYBOARD_VMOVE")<0F){
			newvel = newvel+(-transform.up*speed);
		}
		rigidbody.velocity = newvel;
		
		
		//--------------------------------------------------------------------
		// Direction Controls
		
		if(Input.GetAxis ("KEYBOARD_HFACE")<-0F && Input.GetAxis ("KEYBOARD_VFACE")<0.0F){
			currentDirection = "LeftUp";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		else if(Input.GetAxis("KEYBOARD_HFACE")>0F && Input.GetAxis ("KEYBOARD_VFACE")<-0F){
			currentDirection = "RightUp";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		else if(Input.GetAxis ("KEYBOARD_HFACE")<-0F && Input.GetAxis ("KEYBOARD_VFACE")>0F){
			currentDirection = "LeftDown";
			renderer.material.mainTexture=downStill;
		}
		//DOWN
		else if(Input.GetAxis ("KEYBOARD_HFACE")>0F && Input.GetAxis("KEYBOARD_VFACE")>0F){
			currentDirection = "RightDown";
			renderer.material.mainTexture=upStill;
		}
		else if(Input.GetAxis ("KEYBOARD_HFACE")<-0F){
			currentDirection = "Left";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		else if(Input.GetAxis("KEYBOARD_HFACE")>0F){
			currentDirection = "Right";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		else if(Input.GetAxis ("KEYBOARD_VFACE")>0F){
			currentDirection = "Down";
			renderer.material.mainTexture=downStill;
		}
		//DOWN
		else if(Input.GetAxis("KEYBOARD_VFACE")<0F){
			currentDirection = "Up";
			renderer.material.mainTexture=upStill;
		}
		//--------------------------------------------------------------------
		//MISC Controls
		if (Input.GetAxis("KEYBOARD_ATTACK")>0) {
			if (canShoot && colorPercent-attackColorTake>0) {
				Instantiate (projectile, firePos.position, Quaternion.identity);
				canShoot=false;
				StartCoroutine(coolDown());
				colorPercent = colorPercent-attackColorTake;
			}
		}
		
		if (Input.GetButtonDown ("KEYBOARD_ANGLESWITCHLEFT")) {
			currentAngle=currentAngle-90;
			GameObject[] trees = GameObject.FindGameObjectsWithTag("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles+new Vector3(0,-90,0);
			
			for (int i = 0; i < trees.Length; i++)
				trees[i].transform.eulerAngles = trees[i].transform.eulerAngles+new Vector3(0,-90,0);
		}
		
		if (Input.GetButtonDown ("KEYBOARD_ANGLESWITCHRIGHT")) {
			currentAngle=currentAngle+90;
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, 90, 0);
			for (int i = 0; i < trees.Length; i++)
				trees[i].transform.eulerAngles = trees[i].transform.eulerAngles + new Vector3 (0, 90, 0);
		}


	}

	IEnumerator coolDown(){
		yield return new WaitForSeconds(attackCoolDownTime);
		canShoot = true;
	}


}
