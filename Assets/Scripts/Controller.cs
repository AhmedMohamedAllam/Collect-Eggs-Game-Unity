using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Camera cam;
	public GameObject NormalEgg;
	public GameObject HappyEgg;
	public GameObject RedEgg;
	public GUIText GameOverText;
	public GUIText RestartText;
	public GUIText ContactMeText;
	public GUIText Timetext;
	public float StartTime;
	public float MinTime;
	public float MaxTime;
	private float maxWidth ;
	public float time;


	// Use this for initialization
	void Start () {

		if (cam == null)
			cam = Camera.main;
		Vector3 uppercorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (uppercorner);
		float eggWidth = NormalEgg.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - eggWidth;
		StartCoroutine (Spawn1 ());
		StartCoroutine (Spawn2 ());
		StartCoroutine (Spawn3 ());


	}
	void FixedUpdate() {
		time -= Time.deltaTime;
		if(time < 0){
			time = 0;
			GameOverText.text = "Game Over!";
						RestartText.text = "Press <Double Touch> to LEVEL2!";
			ContactMeText.text = "www.facebook.com/AhmedAllam2013";


			if(Input.GetKeyDown(KeyCode.Return)){
				Application.LoadLevel(1);
					
						}else if(Input.touches[0].tapCount==2){ 
								Application.LoadLevel(1);
						}
			
		}

		Timetext.text = "Time: "+(int)time ;

	}

	IEnumerator Spawn1(){
		
		yield return new WaitForSeconds( StartTime);
		while(time > 1){
			Vector3 position = new Vector3(Random.Range(- maxWidth , maxWidth) , transform.position.y , 0f);
			Quaternion rotation = Quaternion.identity;
			Instantiate (NormalEgg , position , rotation);
			yield return new WaitForSeconds(Random.Range(MinTime , MaxTime));
		}
	}

	IEnumerator Spawn2(){
		
		yield return new WaitForSeconds( StartTime+2f);
		while(time > 1){
			Vector3 position = new Vector3(Random.Range(- maxWidth , maxWidth) , transform.position.y , 0f);
			Quaternion rotation = Quaternion.identity;
			Instantiate (RedEgg , position , rotation);
			yield return new WaitForSeconds(Random.Range(MinTime+.1f , MaxTime+.2f));
		}
	}

	IEnumerator Spawn3(){
		
		yield return new WaitForSeconds( StartTime+4f);
		while(time > 1){
			Vector3 position = new Vector3(Random.Range(- maxWidth , maxWidth) , transform.position.y , 0f);
			Quaternion rotation = Quaternion.identity;
			Instantiate (HappyEgg , position , rotation);
			yield return new WaitForSeconds(Random.Range(MinTime+4f , MaxTime+5f));
		}
	}



}
