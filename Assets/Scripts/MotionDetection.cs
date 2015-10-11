using UnityEngine;
using System.Collections;

public class MotionDetection : MonoBehaviour {

    public GameObject indicationMarker;
    public float MultiplacationOffset = 0.25f;
    public float PlusOffset = 0.4f;
    public float HeightOffset = 1f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("objects spawned");
        Instantiate(indicationMarker, new Vector3(transform.position.x - PlusOffset, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x + PlusOffset, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x , transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z -PlusOffset), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x , transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z +PlusOffset), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x - MultiplacationOffset, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z + MultiplacationOffset), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x - MultiplacationOffset, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z - MultiplacationOffset), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x + MultiplacationOffset, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z + MultiplacationOffset), Quaternion.identity);
        Instantiate(indicationMarker, new Vector3(transform.position.x + MultiplacationOffset, transform.position.y + (transform.GetComponent<CapsuleCollider>().bounds.size.y / 2) + HeightOffset, transform.position.z - MultiplacationOffset), Quaternion.identity);
    }
    // Update is called once per frame
    void Update ()
    {
	    
	}
}
