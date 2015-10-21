using UnityEngine;
using System.Collections;

public class PaddleTriggerScript : MonoBehaviour {
	public GameObject bumper;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			
		}
	}
}
