using UnityEngine;
using System.Collections;

public class AudienceScript : MonoBehaviour {

	public enum BLEACHER{straight,corner,goal};
	public bool invert = false;
	public BLEACHER bleacherType= BLEACHER.straight;
	public GameObject[] members = new GameObject[0];

	// Use this for initialization
	void Start () {
		if (bleacherType == BLEACHER.straight) {
			//columns
			for (int a = 0; a <= 9; a++) {
				//rows
				for (int i = 0; i <= 19; i++) {
					GameObject temp = Instantiate (members [Random.Range (0, members.Length)], this.transform.position + new Vector3 (-1 * i, a, a + (invert? 1:-1)), this.transform.localRotation) as GameObject;
					temp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
					temp.GetComponent<MeshRenderer> ().material.color = new Color (Random.Range (0f, 0.6f), Random.Range (0f, 0.6f), Random.Range (0f, 0.6f));
				}
			}
		} else if (bleacherType == BLEACHER.goal) {
			for (int a = 0; a <= 9; a++) {
				for (int i = 0; i <= 21; i++) {
					GameObject temp = Instantiate (members [Random.Range (0, members.Length)], this.transform.position + new Vector3 (a*(invert? 1:-1), a, i*-1), this.transform.localRotation) as GameObject;
					temp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
					temp.GetComponent<MeshRenderer> ().material.color = new Color (Random.Range (0f, 0.6f), Random.Range (0f, 0.6f), Random.Range (0f, 0.6f));
				}
			}
		} else if (bleacherType == BLEACHER.corner) {
			//columns
			for (int a = 0; a <= 9; a++) {
				//rows
				for (int i = 0; i <= 0+a; i++) {
					GameObject temp = Instantiate (members [Random.Range (0, members.Length)], this.transform.position + new Vector3 ((invert? 1:-1)*i, a ,a-i), this.transform.localRotation) as GameObject;
					temp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
					temp.GetComponent<MeshRenderer> ().material.color = new Color (Random.Range (0f, 0.6f), Random.Range (0f, 0.6f), Random.Range (0f, 0.6f));
				}
			}
		} 
	}
	
	// Update is called once per frame
	void Update () {

	}
}
