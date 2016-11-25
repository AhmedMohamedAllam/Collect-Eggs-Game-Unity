using UnityEngine;
using System.Collections;



public class Score : MonoBehaviour {
	public GUIText ScoreText;

	public int score;
	public int NormalEggValue;
	public int RedEggValue;
	public int HappyEggValue;
	private int EggValue;

	void Start()
	{
		EggValue = 0;
		score = 0;
	}

	void FixedUpdate()
	{
		ScoreText.text = "Score: " + score;
	}


	void OnTriggerEnter2D(Collider2D other){
	

		if (other.GetComponent<Collider2D>().gameObject.tag == "Happy") {
				EggValue = HappyEggValue;	
		} else if (other.GetComponent<Collider2D>().gameObject.tag == "Evil") {
				EggValue = RedEggValue;
		} else if (other.GetComponent<Collider2D>().gameObject.tag == "Normal") {
				EggValue = NormalEggValue;
		}


		score += EggValue;
		Destroy (other.gameObject);
	}

}
