using UnityEngine;
using System.Collections;

public class ZombieReturn : MonoBehaviour
{
    public GameObject zombak;
    GameObject ArmyOfDead;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ArmyOfDead = (GameObject)Instantiate(zombak, GameObject.Find("Sphere").transform.position, Quaternion.identity);
        }
    }
}