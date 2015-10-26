using UnityEngine;
using System.Collections;

public class BarrierBouncerScript : MonoBehaviour {
	public Material greenmat;
	public Material redmat;
	public float redTime = 0.5f;

	public void SetRedMat () {
		foreach (MeshRenderer mr in this.GetComponentsInChildren<MeshRenderer>()) {
			mr.GetComponent<MeshRenderer> ().material = redmat;

		}
		Invoke("ResetGreen", redTime);

	}

	void ResetGreen() {
		foreach (MeshRenderer mr in this.GetComponentsInChildren<MeshRenderer>()) {
			mr.GetComponent<MeshRenderer> ().material = greenmat;
		}
	}
}
