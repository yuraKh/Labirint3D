using UnityEngine;
using System.Collections;

public class AnemyControl : MonoBehaviour
{
	public GameObject zombak;
	GameObject ArmyOfDead;
	float[] distan;
	GameObject[] dist;

	public GameObject FindClosestGem () // Пошук найближчого
	{ 
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("cube");
		GameObject closest = null;
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

	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			print (FindClosestGem ().name);
			ArmyOfDead = (GameObject)Instantiate (zombak, transform.position, Quaternion.identity);
			ArmyOfDead.GetComponent<NavMeshAgent> ().SetDestination (FindClosestGem ().transform.position);
		}
	}
}