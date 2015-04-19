using UnityEngine;
using System.Collections;

public class AnemyControl : MonoBehaviour
{

    bool GamIsTacken = false;
    GameObject[] Zombie;
    GameObject[] Zomb;


    GameObject FindClosestGem() // Пошук найближчого
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("cube");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "cube")
        {
            print(FindClosestGem().name);
            FindClosestGem().transform.SetParent(transform);
            FindClosestGem().tag = "cub";
            transform.tag = "Zomb";
        }

        if (other.tag == "cub")
        {
            GamIsTacken = true;
            other.transform.GetComponent<BoxCollider>().enabled = false;
        }

        if ((other.name == "Sphere") && (GamIsTacken))
        {
            print("no");
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        Zombie = GameObject.FindGameObjectsWithTag("Zombie");
        for (int i = 0; i < Zombie.Length; i++)
        {
            if (FindClosestGem() != null)
            {
                Zombie[i].GetComponent<NavMeshAgent>().SetDestination(FindClosestGem().transform.position);
            }
            else Zombie[i].GetComponent<NavMeshAgent>().SetDestination(GameObject.Find("Sphere").transform.position);
        }
        Zomb = GameObject.FindGameObjectsWithTag("Zomb");
        foreach (GameObject zzomb in Zomb)
        {
            if (zzomb != null)
            {
                zzomb.GetComponent<NavMeshAgent>().SetDestination(GameObject.Find("Sphere").transform.position);
            }
            else break;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (GamIsTacken)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).tag == "cub")
                    {
                        transform.GetChild(i).position = new Vector3(transform.GetChild(i).position.x, 0.5f, transform.GetChild(i).position.z);
                        transform.GetChild(i).tag = "cube";
                        transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
                        transform.GetChild(i).transform.parent = null;
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}