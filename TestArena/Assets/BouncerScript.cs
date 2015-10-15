using UnityEngine;
using System.Collections;

public class BouncerScript : MonoBehaviour {
	public Material greenmat;
	public Material redmat;
	public float redTime = 0.5f;
	public float multiplierForce = 1.3f;


	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ball") {
			col.gameObject.GetComponent<pushtest>().AddForce(multiplierForce);
			GetComponent<MeshRenderer> ().material = redmat;
			GetComponent<AudioSource>().Play();
			Invoke("ResetGreen", redTime);
		}
	}

	void ResetGreen() {
		GetComponent<MeshRenderer> ().material = greenmat;
	}
}
