using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public bool following;
    public GameObject gripper;
    public Vector3 offSet;
	// Use this for initialization
	void Start () {
        gripper = GameObject.Find("Gripperr(Clone)");
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (following)
        {
            transform.position = gripper.transform.position + gripper.transform.localToWorldMatrix.MultiplyVector(Vector3.up) + offSet;
            transform.rotation = gripper.transform.rotation;
            if(gameObject.name == "Staafmixer(Clone)") {
                transform.Rotate(270, 90, 90);
            }
        }
	}
}
