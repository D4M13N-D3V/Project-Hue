using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public string currentDirection = "Forward";
	public float colorPercent = 100.00F;
	public int health;
	public int speed;


	public Transform camera;
	//PLACE HOLDER VARIABLES
	
	public bool usePlaceHolders = true;
	
	public Texture frontStill;
	public Texture backStill;
	public Texture leftStill;
	public Texture rightStill;
	public GameObject cameraParent;
	public Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		
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


		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.RightArrow) || !Input.GetKey(KeyCode.D)){
			if(usePlaceHolders){
				renderer.material.mainTexture=leftStill;
				Vector3 temp = -camera.right;
				temp.y = 0;
				transform.position += (temp*speed) * Time.deltaTime;
			}
		}

		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.A)){
			if(usePlaceHolders){
				renderer.material.mainTexture=rightStill;
				Vector3 temp = camera.right;
				temp.y = 0;
				transform.position += (temp*speed) * Time.deltaTime;
			}
		}

		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			if(usePlaceHolders){
				renderer.material.mainTexture=backStill;
				Vector3 temp = camera.up;
				temp.y = 0;
				transform.position += (temp*speed) * Time.deltaTime;
			}
		}

		if( Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
			if(usePlaceHolders){
				renderer.material.mainTexture=frontStill;
				Vector3 temp = -camera.up;
				temp.y = 0;
				transform.position += (temp*speed) * Time.deltaTime;
			}
		}



	}




}
