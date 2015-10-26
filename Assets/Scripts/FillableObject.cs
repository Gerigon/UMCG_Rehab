using UnityEngine;
using System.Collections;

public class FillableObject : MonoBehaviour {


    public GameObject scalableLiquid;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnParticleCollision(GameObject other)
    {
        if (scalableLiquid.transform.localScale.z < 18)
        scalableLiquid.transform.localScale += new Vector3(0, 0, 0.05f);

    }
}
