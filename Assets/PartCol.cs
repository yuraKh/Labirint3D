using UnityEngine;
using System.Collections;

public class PartCol : MonoBehaviour
{


	void Start ()
	{
	
	}
	void OnParticleCollision (GameObject other)
	{
		if (other.tag == "cube") {
			Vector3 move = transform.position - other.transform.position;
			other.GetComponent<Rigidbody> ().AddForce (other.transform.position * 5f);
		}
	}

	void Update ()
	{
	
	}
}
