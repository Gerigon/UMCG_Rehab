using UnityEngine;
using System.Collections;

public class Mixing : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, Vector3.up * 50, Color.red, 5f);
	}
}
