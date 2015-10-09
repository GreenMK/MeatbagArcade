using UnityEngine;
using System.Collections;

public class BouncerScript : MonoBehaviour {
	public float additionalForce = 10f;

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ball") {
			col.gameObject.GetComponent<Rigidbody>().AddForce(col.gameObject.GetComponent<Rigidbody>().velocity*additionalForce, ForceMode.Impulse);
		}

	}
}
