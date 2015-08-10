using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;


public class debugui : MonoBehaviour {
	public GameObject fpscounter;
	public GameObject ramcounter;
	public GameObject cpucounter;
	public GameObject health;
	public GameObject color;
	public GameObject player;
	public GameObject attkcd;
	public GameObject attkdrn;
	public GameObject attackdmg;
	public GameObject direction;
	public GameObject angle;
	
	public GameObject attkcdslider;
	public GameObject attkdrnslider;
	public GameObject attackdmgslider;
	public GameObject colorslider;
	
	public GameObject attkcdstext;
	public GameObject attkdrntext;
	public GameObject attackdmgtext;
	public GameObject colortext;

	System.Diagnostics.PerformanceCounter cpuCounter;
	System.Diagnostics.PerformanceCounter ramCounter;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		System.Diagnostics.PerformanceCounterCategory.Exists("PerformanceCounter");         
		cpuCounter = new PerformanceCounter();
		cpuCounter.CategoryName = "Processor";
		cpuCounter.CounterName = "% Processor Time";
		cpuCounter.InstanceName = "_Total";
		ramCounter = new PerformanceCounter("Memory", "Available MBytes");

		attkcdslider.GetComponent<Slider> ().value = player.GetComponent<playercontroller> ().attackCoolDownTime;
		attkdrnslider.GetComponent<Slider> ().value = player.GetComponent<playercontroller> ().attackColorTake;
		attackdmgslider.GetComponent<Slider> ().value = player.GetComponent<playercontroller> ().attackDamage;
		colorslider.GetComponent<Slider> ().value = Mathf.Round (player.GetComponent<playercontroller> ().colorPercent);

		attkcdstext.GetComponent<Text> ().text = "ATK COOLDOWN : "+player.GetComponent<playercontroller> ().attackCoolDownTime.ToString(); ;
		attkdrntext.GetComponent<Text> ().text = "ATK DRAIN : "+player.GetComponent<playercontroller> ().attackColorTake.ToString(); ;
		attackdmgtext.GetComponent<Text> ().text = "ATK DAMAGE : "+player.GetComponent<playercontroller> ().attackDamage.ToString(); ;

		float numbah = player.GetComponent<playercontroller> ().colorPercent;
		numbah = 100 * (255 - numbah) / 255;
		numbah = 100 - numbah;
		colortext.GetComponent<Text>().text = "COLOR LVL : "+numbah+"%"; 
	}
	
	// Update is called once per frame
	void Update () {


		fpscounter.GetComponent<Text> ().text = "FPS : " + 1.0f / Time.deltaTime;
		ramcounter.GetComponent<Text> ().text = "RAM : "+getAvailableRAM();
		cpucounter.GetComponent<Text> ().text = "CPU : "+getCurrentCpuUsage();
		health.GetComponent<Text> ().text = "HEALTH : "+player.GetComponent<playercontroller>().health;
		
		double percent = player.GetComponent<playercontroller>().colorPercent;
		percent = System.Math.Round ((100 * (255 - percent) / 255), 2);
		color.GetComponent<Text> ().text = "COLOR : "+(100-percent)+"%";
		attkcd.GetComponent<Text> ().text = "ATK CD : "+player.GetComponent<playercontroller>().attackCoolDownTime;
		attkdrn.GetComponent<Text> ().text = "ATK DRN : "+player.GetComponent<playercontroller>().attackColorTake;
		attackdmg.GetComponent<Text> ().text = "ATK DMG : "+player.GetComponent<playercontroller>().attackDamage;
		direction.GetComponent<Text> ().text = "DIRECTION : "+player.GetComponent<playercontroller>().currentDirection;
		angle.GetComponent<Text> ().text = "ANGLE : "+player.GetComponent<playercontroller>().currentAngle;
	} 

	public string getCurrentCpuUsage(){
		return cpuCounter.NextValue()+"%";
	}
	
	public string getAvailableRAM(){
		return ramCounter.NextValue()+"MB";
	} 
	
	public void changeAttackCooldown( float value ){
		float numbah = attkcdslider.GetComponent<Slider> ().value;
		attkcdstext.GetComponent<Text>().text = "ATK COOLDOWN : " + numbah;
		player.GetComponent<playercontroller> ().attackCoolDownTime = numbah;
	}
	public void changeAttackDrain( float value ){
		float numbah = attkdrnslider.GetComponent<Slider> ().value;
		attkdrntext.GetComponent<Text>().text = "ATL DRAIN : " + numbah;
		player.GetComponent<playercontroller> ().attackColorTake = numbah;
	}
	public void changeAttackDamage( float value ){
		float numbah = attackdmgslider.GetComponent<Slider> ().value;
		attackdmgtext.GetComponent<Text>().text = "ATK DAMAGE : " + numbah;
		player.GetComponent<playercontroller> ().attackDamage = numbah;
	}
	public void changeColor( float value ){
		float numbah = colorslider.GetComponent<Slider> ().value;
		numbah = 100 * (255 - numbah) / 255;
		numbah = 100 - numbah;
		colortext.GetComponent<Text>().text = "COLOR LVL : " + numbah;
		player.GetComponent<playercontroller> ().colorPercent = numbah;
	}

	public void resetColor(){
		
		float numbah = 255;
		player.GetComponent<playercontroller> ().colorPercent = numbah;
		colorslider.GetComponent<Slider>().value = numbah;
		numbah = 100 * (255 - numbah) / 255;
		numbah = 100 - numbah;
		colortext.GetComponent<Text>().text = "COLOR LVL : " + numbah;
	}


}
