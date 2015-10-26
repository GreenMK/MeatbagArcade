using UnityEngine;
using System.Collections;

public class pushtest : MonoBehaviour {

	public float kickRange = 4f;
	public float pushAmt;
	public float speed;
	public float maxSpeed = 30f;
	public Transform player;
	public bool go;
	public ParticleSystem party;


	Rigidbody rBody;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		rBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			return;
		}
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
		speed = Mathf.Clamp(speed -.02f, 0.4f, maxSpeed);
		Vector2 horVel = new Vector2 (rBody.velocity.x,rBody.velocity.z);
		rBody.velocity = new Vector3(horVel.normalized.x*speed,rBody.velocity.y,horVel.normalized.y*speed);
		Debug.DrawRay(this.transform.position + rBody.velocity.normalized,rBody.velocity);
		if (player == null) {
			return;
		}
		RaycastHit hitInfo;
		if(Physics.Raycast (this.transform.position + rBody.velocity.normalized, rBody.velocity,out hitInfo, speed*.02f)){
			if(hitInfo.collider.tag == "Player"){
				Destroy(hitInfo.collider.gameObject);
			}
		}
	}

	public void AddForce(float forceMultiplier) {
		speed = speed * forceMultiplier;
	}
}
