using UnityEngine;
using System.Collections;

public class ZombieReturn : MonoBehaviour
{
	public GameObject cube;
	// Use this for initialization
	void Start ()
	{
	
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "cube") {
			print ("yes");
			//other.GetComponent<NavMeshAgent> ().SetDestination (GameObject.Find ("Sphere").transform.position);
			GetComponent<NavMeshAgent> ().SetDestination (GameObject.Find ("Sphere").transform.position);
			Destroy (other.gameObject);
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			GameObject Cube = (GameObject)Instantiate (cube, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
