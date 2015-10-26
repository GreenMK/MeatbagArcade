using UnityEngine;
using System.Collections;

public class BarrierPartScript : MonoBehaviour {	
	public float multiplierForce = 1.3f;
	
	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ball") {
			col.gameObject.GetComponent<pushtest>().AddForce(multiplierForce);
			GetComponent<AudioSource>().Play ();
			GetComponentInParent<BarrierBouncerScript>().SetRedMat();

		}
	}
	

}
