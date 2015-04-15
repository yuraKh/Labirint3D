using UnityEngine;
using System.Collections;

public class SPACESHIP : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.RotateAround (new Vector3 (25f, 10f, 112.3f), Vector3.down, 0.5f);
	}
}
