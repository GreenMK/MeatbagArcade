using UnityEngine;
using System.Collections;

public class BallSpawnScript : MonoBehaviour {
	public GameObject ball;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2")) {
			Instantiate(ball, this.transform.position, Quaternion.identity);
		}
	}
}
