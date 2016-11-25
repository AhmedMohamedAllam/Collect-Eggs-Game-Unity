using UnityEngine;
using System.Collections;

public class BrokeEgg : MonoBehaviour {

	void Start(){
		StartCoroutine (disableBrokenEgg ());
		}
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
		gameObject.GetComponent<Renderer>().enabled = true;
		float EggX = other.gameObject.transform.position.x;
		Vector3 position = new Vector3 (EggX, -.7f, 0f);
		Quaternion rotation = Quaternion.identity;
		Instantiate (gameObject , position , rotation);

		}

	IEnumerator disableBrokenEgg(){
		yield return new WaitForSeconds (2f);
		gameObject.GetComponent<Renderer>().enabled = false;

	}
}
