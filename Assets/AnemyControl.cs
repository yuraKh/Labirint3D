using UnityEngine;
using System.Collections;

public class AnemyControl : MonoBehaviour
{
	public GameObject zombak;
	GameObject ArmyOfDead;
	float[] distan;
	GameObject[] dist;

	GameObject FindClosestEnemy ()
	{ 
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("cube");
		GameObject closest;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}


	void Start ()
	{
		print (FindClosestEnemy ().name);
	}

	void Update ()
	{
		/*if (Input.GetMouseButtonDown (0)) {
			ArmyOfDead = (GameObject)Instantiate (zombak, transform.position, Quaternion.identity);
			ArmyOfDead.GetComponent<NavMeshAgent> ().SetDestination (FindClosestEnemy ().transform.position);
		}*/
	}
}