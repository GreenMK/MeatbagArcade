﻿using UnityEngine;
using System.Collections;

public class pushtest : MonoBehaviour {

	public float kickRange = 4f;
	public float pushAmt;
	public float speed;
	public Transform player;
	public bool go;
	public ParticleSystem party;
	Rigidbody rBody;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (go || Input.GetButtonDown ("Fire1")) {
			if (Vector3.Distance (this.transform.position, player.position) < kickRange) {
				party.transform.position = player.position;
				party.Play();
				go = false;
				Vector3 direction = this.transform.position - player.position;
				rBody.velocity = ((direction.normalized * pushAmt));
				speed = pushAmt;
			}
		}
	}



	void FixedUpdate(){
		speed = Mathf.Max(0f,speed -.02f);
		Vector2 horVel = new Vector2 (rBody.velocity.x,rBody.velocity.z);
		rBody.velocity = new Vector3(horVel.normalized.x*speed,rBody.velocity.y,horVel.normalized.y*speed);
		Debug.DrawRay(this.transform.position + rBody.velocity.normalized,rBody.velocity);
		RaycastHit hitInfo;
		if(Physics.Raycast (this.transform.position + rBody.velocity.normalized, rBody.velocity,out hitInfo, speed*.02f)){
			if(hitInfo.collider.tag == "Player"){
				Destroy(hitInfo.collider.gameObject);
			}
		}
	}


}
