using UnityEngine;
using System.Collections;

public class CamCont : MonoBehaviour {
	private Transform target;
	float startTime = 0f;
	bool inOverview = false;
	public float lerpSpeed = 2f;
	public Vector3 offset = new Vector3(0f, 10f, -4f);
	public Vector3 overview = new Vector3(0f, 27f, -10f);



	public void Start() {
		target = Camera.main.transform;
	}

	private void LateUpdate() {

		if (Input.GetButtonDown ("Overview")){
			inOverview = !inOverview;
			startTime = Time.time;
			Debug.Log("down");
		}

		if (inOverview) {
			target.position = Vector3.Lerp(transform.position + offset,overview,(Time.time-startTime)* lerpSpeed);
		} else {
			target.position = Vector3.Lerp(overview,transform.position + offset,(Time.time-startTime)* lerpSpeed);
		}


	}
}
