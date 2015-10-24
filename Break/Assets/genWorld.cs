using UnityEngine;
using System.Collections;

public class genWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {


		GenCorridor (5);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenCorridor(int width) {
		createTile (-1, 1, 0);
		for (int i = 0; i < width; i++) {
			createTile(i,0,0);
		}
		createTile(width,1,0);
	}

	void createTile(float xOffset = 0, float yOffset = 0,float zOffset = 0) {
		GameObject part = GameObject.CreatePrimitive (PrimitiveType.Cube);
		part.AddComponent<BoxCollider>();
		part.transform.position = new Vector3(part.transform.position.x+xOffset, part.transform.position.y+yOffset,part.transform.position.z+zOffset);
	}


}
