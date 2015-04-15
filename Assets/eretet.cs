using UnityEngine;
using System.Collections;

public class eretet : MonoBehaviour
{
	public GameObject boom;

	// Use this for initialization
	void Start ()
	{
	
	}


	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray XRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit XRayHit;
			if (Physics.Raycast (XRay, out XRayHit, 100f)) {
				GameObject Flame = (GameObject)Instantiate (boom, transform.position, Quaternion.identity);
				Destroy (gameObject, 1f);
			}
		}
		gameObject.transform.Rotate (0, 0.3f, 0);
	}
}
