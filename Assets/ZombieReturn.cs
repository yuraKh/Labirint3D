using UnityEngine;
using System.Collections;

public class ZombieReturn : MonoBehaviour
{
	bool GamIsTacken = false;


	void Start ()
	{

	}
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "cube") {
			print ("yes");
			//Gem.transform.SetParent (transform);
			//GetComponent<AnemyControl> ().FindClosestGem ().transform.SetParent (transform);
			other.gameObject.transform.SetParent (transform);
			GetComponent<NavMeshAgent> ().SetDestination (GameObject.Find ("Sphere").transform.position);
			GamIsTacken = true;
		}
		if ((other.name == "Sphere") && (GamIsTacken)) {
			print ("no");
			Destroy (gameObject);
		}
	}


	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			if (GamIsTacken) {
				for (int i = 0; i < transform.childCount; i++) {
					if (transform.GetChild (i).tag == "cube") {
						transform.GetChild (i).position = new Vector3 (transform.GetChild (i).position.x, 0.5f, transform.GetChild (i).position.z);
						transform.GetChild (i).transform.parent = null;
					}
				}
			} 
			Destroy (gameObject);
		}
	}
}
