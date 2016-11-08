using UnityEngine;
using System.Collections;

public class RaycastCursorDemo : MonoBehaviour {

	public Transform sphere;
	
	// Update is called once per frame
	void Update () {
		//Step 1: define the "ray"
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		//Step 2: declare a variable to remember the "impact" information
		RaycastHit rayHit = new RaycastHit ();

		Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.cyan); 

		//Step 3: Shoot the raycast; often in an if() statement
		if (Physics.Raycast (ray, out rayHit, 1000f)) {
			Debug.Log ("I'm hitting something! There's something undeneath the mouse cursor!");

			//Move sphere to position
			sphere.position = rayHit.point;

			//Instantiate a copy on click
			if (Input.GetMouseButton (0)) {
				Instantiate (sphere, rayHit.point, Quaternion.identity);
			}
		}
	}
}
