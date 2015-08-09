using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public string currentDirection = "Down";
	public float colorPercent = 100.00F;
	public int health;
	public int speed;
	public Transform firePos;

	public GameObject projectile;

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
	
//KEYBOARD
		//--------------------------------------------------------------------
		//Movment Controls
		
		
		//DIAGNOL DIRECTIONS//
		//LEFTUP
		if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)){
			rigidbody.velocity = (-transform.up+-transform.right)*speed;
		}
		//RIGHTUP
		if(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)){
			rigidbody.velocity = (-transform.up+transform.right)*speed;
		}
		//LEFTDOWN
		if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)){
			rigidbody.velocity = (transform.up+-transform.right)*speed;
		}
		//RIGHTDOWN
		if(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S)){
			rigidbody.velocity = (transform.up+transform.right)*speed;
		}
		
		
		// MAIN DIRECTIONS//
		//LEFT
		if(Input.GetKey (KeyCode.A)){
			rigidbody.velocity = transform.right*speed;
		}
		//RIGHT
		if(Input.GetKey (KeyCode.D)){
			rigidbody.velocity = -transform.right*speed;
		}
		//UP
		if(Input.GetKey (KeyCode.W)){
			rigidbody.velocity = -transform.up*speed;
		}
		//DOWN
		if(Input.GetKey (KeyCode.S)){
			rigidbody.velocity = transform.up*speed;
		}
		
		
		
		
		//--------------------------------------------------------------------
		// Direction Controls
		
		
		if(Input.GetKey (KeyCode.LeftArrow)){
			currentDirection = "Left";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		if(Input.GetKey (KeyCode.RightArrow)){
			currentDirection = "Right";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		if(Input.GetKey (KeyCode.UpArrow)){
			currentDirection = "Up";
			renderer.material.mainTexture=upStill;
		}
		//DOWN
		if(Input.GetKey (KeyCode.DownArrow)){
			currentDirection = "Down";
			renderer.material.mainTexture=downStill;
		}
		
		//--------------------------------------------------------------------
		//MISC Controls
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate(projectile,firePos.position,Quaternion.identity);
		}
		
		if (Input.GetKeyDown (KeyCode.Q)) {
			GameObject[] trees = GameObject.FindGameObjectsWithTag("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles+new Vector3(0,-90,0);
			
			for (int i = 0; i < trees.Length; i++)
				trees[i].transform.eulerAngles = trees[i].transform.eulerAngles+new Vector3(0,-90,0);
		}
		
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, 90, 0);
			for (int i = 0; i < trees.Length; i++)
				trees[i].transform.eulerAngles = trees[i].transform.eulerAngles + new Vector3 (0, 90, 0);
		}
		
		//--------------------------------------------------------------------


		//CONTROLLER
		//--------------------------------------------------------------------
		//Movment Controls
		
		
		
		//DIAGNOL DIRECTIONS//
		//LEFTUP
		if(Input.GetAxis("CONTROLLER_VLS")<-0.1F && Input.GetAxis("CONTROLLER_HLS")>0.9F){
			rigidbody.velocity = (-transform.up+-transform.right)*speed;
		}
		//RIGHTUP
		if(Input.GetAxis ("CONTROLLER_VLS")>0.9F && Input.GetAxis ("CONTROLLER_HLS")>0.9F){
			rigidbody.velocity = (-transform.up+transform.right)*speed;
		}
		//LEFTDOWN
		if(Input.GetAxis ("CONTROLLER_VLS")<-0.1F && Input.GetAxis ("CONTROLLER_HLS")<-0.1F){
			rigidbody.velocity = (transform.up+-transform.right)*speed;
		}
		//RIGHTDOWN
		if(Input.GetAxis ("CONTROLLER_VLS")>0.9F && Input.GetAxis ("CONTROLLER_HLS")<-0.1F){
			rigidbody.velocity = (transform.up+transform.right)*speed;
		}

		// MAIN DIRECTIONS//
		//LEFT
		if(Input.GetAxis ("CONTROLLER_HLS")<-0.1F){
			rigidbody.velocity = transform.right*speed;
		}
		//RIGHT
		if(Input.GetAxis("CONTROLLER_HLS")>0.9F){
			rigidbody.velocity = -transform.right*speed;
		}
		//UP
		if(Input.GetAxis ("CONTROLLER_VLS")>0.9F){
			rigidbody.velocity = transform.up*speed;
		}
		//DOWN
		if(Input.GetAxis("CONTROLLER_VLS")<-0.1F){
			rigidbody.velocity = -transform.up*speed;
		}
		
		
		
		
		//--------------------------------------------------------------------
		// Direction Controls
		
		if(Input.GetAxis ("CONTROLLER_HRS")<-0.1F){
			currentDirection = "Left";
			renderer.material.mainTexture=leftStill;
		}
		//RIGHT
		if(Input.GetAxis("CONTROLLER_HRS")>0.9F){
			currentDirection = "Right";
			renderer.material.mainTexture=rightStill;
		}
		//UP
		if(Input.GetAxis ("CONTROLLER_VRS")>0.9F){
			currentDirection = "Down";
			renderer.material.mainTexture=downStill;
		}
		//DOWN
		if(Input.GetAxis("CONTROLLER_VRS")<-0.1F){
			currentDirection = "Up";
			renderer.material.mainTexture=upStill;
		}
		
		//--------------------------------------------------------------------
		//MISC Controls
		if (Input.GetAxis("CONTROLLER_RIGHTTRIGGER")>0) {
			Instantiate(projectile,firePos.position,Quaternion.identity);
		}
		
		if (Input.GetButtonDown ("CONTROLLER_LEFTBUMPER")) {
			GameObject[] trees = GameObject.FindGameObjectsWithTag("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles+new Vector3(0,-90,0);
			
			for (int i = 0; i < trees.Length; i++)
				trees[i].transform.eulerAngles = trees[i].transform.eulerAngles+new Vector3(0,-90,0);
		}
		
		if (Input.GetButtonDown ("CONTROLLER_RIGHTBUMPER")) {
			GameObject[] trees = GameObject.FindGameObjectsWithTag ("rotateWithCamera");
			cameraParent.transform.eulerAngles = cameraParent.transform.eulerAngles + new Vector3 (0, 90, 0);
			for (int i = 0; i < trees.Length; i++)
				trees[i].transform.eulerAngles = trees[i].transform.eulerAngles + new Vector3 (0, 90, 0);
		}
		
		//--------------------------------------------------------------------

	}




}
