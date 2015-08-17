using UnityEngine;
using System.Collections;

public class ColorFlower : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.name == "Player") {
			if(col.gameObject.GetComponent<playercontroller>().colorPercent>=216){
				col.gameObject.GetComponent<playercontroller>().colorPercent=216;
			}else{
				col.gameObject.GetComponent<playercontroller>().colorPercent=	col.gameObject.GetComponent<playercontroller>().colorPercent+0.5F;
			}
		}
	}

}
