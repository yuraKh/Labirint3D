using UnityEngine;
using System.Collections;

public class eretet : MonoBehaviour {
	public GameObject boom;
	float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown (0)) {
			GameObject Flame = (GameObject)Instantiate (boom, transform.position, Quaternion.identity);
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.Lerp (gameObject.GetComponent<MeshRenderer> ().material.color, new Color (0.255f, 0.255f, 0.255f, 0.255f), 10f);
		}
		if (gameObject.GetComponent<MeshRenderer> ().material.color == new Color (0.255f, 0.255f, 0.255f, 0.255f)) {
			Destroy(gameObject);
		}
		gameObject.transform.Rotate(0, 0.3f, 0);
	}
}
