using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	public float health = 10;
	public float maxHealth = 10;
	public Animator animator;
	public GameObject healthbar;
	public GameObject healthbarprefab;
	public Vector3 offset = new Vector3(0,1,0);
	public float displayDistance = 8;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		GameObject temp = Instantiate (healthbarprefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		temp.transform.eulerAngles = new Vector3 (temp.transform.eulerAngles.x, 235, temp.transform.eulerAngles.y);
		healthbar = temp;
	}
	
	// Update is called once per frame
	void Update () {

		healthbar.transform.position = transform.position+offset; 

		if (Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position) < displayDistance) {
			healthbar.SetActive (true);
		} else {
			healthbar.SetActive(false);
		}
		float percent = 1-((maxHealth - health) / maxHealth);

		healthbar.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().fillAmount=percent; 
	}
	public void Damage(float amount){
		health = health - amount;
		if (health==0) {
			animator.SetTrigger ("death");
			StartCoroutine(removeSelf());
			Destroy(healthbar.gameObject);
		} 
		else if(health>0){
			animator.SetTrigger ("hit");
		}
	}

	IEnumerator removeSelf(){
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
	

}
