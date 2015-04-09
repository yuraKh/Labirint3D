using UnityEngine;
using System.Collections;

public class MoveYourBody : MonoBehaviour {
	public Animation zombie;
	Vector3 startM;

	RaycastHit hit;
	// Use this for initialization
	void Start () {

		zombie = GetComponent<Animation>();
		startM = transform.position;
		//dist = Camera.main.transform.position - transform.position;
	}

	void OnTriggerEnter(Collider Col) {
		if (Col.tag == "Generator") {
			Destroy(Col.gameObject);

		}
    }
    
	void Update () {

		//Camera.main.transform.position = dist + transform.position;
		if (Input.GetMouseButtonDown(0)){
			Ray XRay = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(XRay, out hit, 200f)){
				GetComponent<NavMeshAgent>().SetDestination(hit.point);
			}
		}
		if (Vector3.Distance(GetComponent<NavMeshAgent>().velocity, new Vector3(0,0,0)) == 0) {
			zombie.Play("Idle");
		}
		else if (Vector3.Distance (transform.position, hit.point) > 0.1f) {

			zombie.Play ("Run");
		} 
		else {
			zombie.Play("Stand");
		}
		if (Input.GetMouseButton (2)) {
			Camera.main.transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		}
	}
}