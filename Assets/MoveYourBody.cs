using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MoveYourBody : MonoBehaviour
{
	public Text Score;
	public Animation zombie;

	public GameObject boom;
	RaycastHit hit;
	int _Score = 0;

	// Use this for initialization
	void Start ()
	{

		zombie = GetComponent<Animation> ();

		//dist = Camera.main.transform.position - transform.position;
	}

	void OnTriggerEnter (Collider Col)
	{
		if (Col.tag == "Generator") {
			//GameObject Flame = (GameObject)Instantiate (boom, Col.transform.position, new Quaternion (0, 0, 0, 0));
			Destroy (Col.gameObject);
		}
	}

	void OnParticleCollision (GameObject other)
	{
		if (other.name == "red") {
			_Score ++;
		}
		if (other.name == "blue") {
			_Score--;
		}
		print ("TEST");
	}
    
	void Update ()
	{
		Score.text = "Score: " + _Score;
		//Camera.main.transform.position = dist + transform.position;
		if (Input.GetMouseButtonDown (0)) {
			Ray XRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (XRay, out hit, 200f)) {
				GetComponent<NavMeshAgent> ().SetDestination (hit.point);
			}
		}
		if (Vector3.Distance (GetComponent<NavMeshAgent> ().velocity, new Vector3 (0, 0, 0)) == 0) {
			zombie.Play ("Idle");
		} else if (Vector3.Distance (transform.position, hit.point) > 0.1f) {

			zombie.Play ("Run");
		} else {
			zombie.Play ("Stand");
		}
		if (Input.GetMouseButton (2)) {
			Camera.main.transform.Rotate (Input.GetAxis ("Mouse Y"), Input.GetAxis ("Mouse X"), 0);
		}
	}
}