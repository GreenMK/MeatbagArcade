using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	public enum PADDLE_STATE{IDLE,FLIP,UNFLIP}; 
	public PADDLE_STATE paddleState = PADDLE_STATE.IDLE;
	public float buttonTime = 0f;
	public float paddleSpeed = 0.1f;
	public float percentageTime= 0;
	public float flippedRot = 40;
	public float startRot = 80;

	void Start () {
		startRot = transform.eulerAngles.y;
	}
	
	public void triggerPaddle () {
		if (paddleState == PADDLE_STATE.IDLE) {
			buttonTime = Time.time;
			paddleState = PADDLE_STATE.FLIP;
		} else if (paddleState == PADDLE_STATE.UNFLIP) {
			buttonTime = Time.time - 
				(1 - (Time.time -(buttonTime+paddleSpeed))/paddleSpeed)*paddleSpeed;
			paddleState = PADDLE_STATE.FLIP;
		}
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.F)) {
			triggerPaddle();
		}
		if (paddleState == PADDLE_STATE.IDLE) {
		} else if (paddleState == PADDLE_STATE.FLIP) {
			percentageTime = Mathf.Min((Time.time-buttonTime)/paddleSpeed,1);
			transform.localEulerAngles = new Vector3(0,flippedRot*percentageTime+startRot, 0);
			if (percentageTime >= 1f) {
				paddleState = PADDLE_STATE.UNFLIP;
			}
		} else if (paddleState == PADDLE_STATE.UNFLIP) {
			percentageTime = Mathf.Min((Time.time-(buttonTime+paddleSpeed))/paddleSpeed,1);
			transform.localEulerAngles = new Vector3(0,flippedRot-flippedRot*percentageTime+startRot, 0);
			if (percentageTime >= 1f) {
				paddleState = PADDLE_STATE.IDLE;
			}
		}
	}
}
