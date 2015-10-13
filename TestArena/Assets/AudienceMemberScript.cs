using UnityEngine;
using System.Collections;

public class AudienceMemberScript : MonoBehaviour {

	public float jumpHeight = 1;

	public enum AUDIENCE_STATE{idle, excited}
	public AUDIENCE_STATE currentState = AUDIENCE_STATE.idle;

	bool audienceJump = false;
	float startTime;
	float timeTilNextJump = 1;
	float originalY;
	float duration = 2; 
	
	public float floatStrength = 1; // You can change this in the Unity Editor to 
	// change the range of y positions that are possible.

	void Start () {
		this.originalY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (audienceJump == true) {
			transform.position = new Vector3(transform.position.x, originalY + (Mathf.Sin(Time.time) * floatStrength),transform.position.z);
		} else {
			this.transform.position = new Vector3 (this.transform.position.x, this.originalY, this.transform.position.z);
			timeTilNextJump -= Time.deltaTime;
			if (timeTilNextJump < 0) {
				if (currentState == AUDIENCE_STATE.idle) {
					startTime = Time.time;
					audienceJump = true;
					Invoke("StopJump", duration);
					timeTilNextJump = Random.Range (5f, 15f);
				} else if (currentState == AUDIENCE_STATE.excited) {
					startTime = Time.time;
					audienceJump = true;
					Invoke("StopJump", duration);
					timeTilNextJump = Random.Range (3f, 5f);
				}
			}
		}
	}
	
	void StopJump() {
		audienceJump = false;
	}
}
