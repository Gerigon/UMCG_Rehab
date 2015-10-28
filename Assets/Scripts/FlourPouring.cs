using UnityEngine;
using System.Collections;

public class FlourPouring : MonoBehaviour {

    private ParticleSystem FlourParticleEmitter;
	// Use this for initialization
	void Start ()
    {
        FlourParticleEmitter = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
        FlourParticleEmitter.enableEmission = false;
        Debug.Log(FlourParticleEmitter);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.eulerAngles.x > 300)
        {
            Debug.Log("emitting");
            FlourParticleEmitter.enableEmission = true;
        }
    }
}
