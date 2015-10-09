using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rig;
	public float speed;
	public Vector3 repulsion = Vector3.zero;
	public Animator anim;
	Vector3 inputs;
	float mag;
	public bool isControllable = true;

	// Use this for initialization
	void Start () {
		rig = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", inputs.magnitude, .05f, Time.deltaTime);
		anim.SetFloat("PlaySpeed", Mathf.Max(inputs.magnitude*speed*mag*.1f,1f), .05f, Time.deltaTime);

	}

	private void FixedUpdate()
	{
		if (isControllable) {
			inputs = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
			mag = Mathf.Max (Mathf.Abs (inputs.x), Mathf.Abs (inputs.z));
			if (inputs.x != 0 || inputs.z != 0) {
				inputs.Normalize ();
				inputs = (inputs + repulsion.normalized).normalized;
				Vector3 movement = new Vector3 (inputs.x * speed * mag, rig.velocity.y, inputs.z * speed * mag);
				rig.velocity = movement;
				this.transform.LookAt (this.transform.position + new Vector3 (inputs.x, transform.position.y, inputs.z));
				repulsion = Vector3.zero;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			repulsion = contact.normal;
		}
		
	}

	void OnCollisionStay(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			repulsion = contact.normal;
		}
		
	}
}
