using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    public GameObject indicationMarker;
    public GameObject tempMarker;
    public float MultiplacationOffset = 0.25f;
    public float PlusOffset = 0.4f;
    public float HeightOffset = 1f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("objects spawned");

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x - (PlusOffset * transform.localScale.x), transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset * transform.localScale.x, transform.position.z), Quaternion.identity)as GameObject;
        tempMarker.transform.localScale = transform.localScale/2;
        tempMarker.transform.parent = transform;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x + (PlusOffset * transform.localScale.x), transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset * transform.localScale.x, transform.position.z), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + (HeightOffset * transform.localScale.x), transform.position.z - (PlusOffset * transform.localScale.x)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + (HeightOffset * transform.localScale.x), transform.position.z + (PlusOffset * transform.localScale.x)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x - (MultiplacationOffset * transform.localScale.x), transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + (HeightOffset * transform.localScale.x), transform.position.z + (MultiplacationOffset * transform.localScale.x)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x - (MultiplacationOffset * transform.localScale.x), transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + (HeightOffset * transform.localScale.x), transform.position.z - (MultiplacationOffset * transform.localScale.x)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x + (MultiplacationOffset * transform.localScale.x), transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + (HeightOffset * transform.localScale.x), transform.position.z + (MultiplacationOffset * transform.localScale.x)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x + (MultiplacationOffset * transform.localScale.x), transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + (HeightOffset * transform.localScale.x), transform.position.z - (MultiplacationOffset * transform.localScale.x)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale;
        tempMarker.transform.parent = transform;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
