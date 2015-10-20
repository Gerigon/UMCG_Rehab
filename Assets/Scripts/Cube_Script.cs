using UnityEngine;
using System.Collections;

public class Cube_Script : MonoBehaviour {

    float yVar = 0;
    public Material playerMaterial;
    Ray ray;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        yVar = Mathf.PingPong(Time.time, 2) - 1;
        transform.position = new Vector3(transform.position.x, transform.position.y + yVar, transform.position.z);
        transform.Translate(0, yVar, 0);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        if (Input.GetButton("Fire1") && Physics.Raycast(ray, out hit))
        {
            
            if (hit.transform.name == "Cube")
            playerMaterial.color = Color.cyan;
        }
        else
        {
            playerMaterial.color = Color.red;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Triggered");
        if (transform.name == "Cube")
        {
            transform.parent = collision.transform.parent;
        }
    }
}
