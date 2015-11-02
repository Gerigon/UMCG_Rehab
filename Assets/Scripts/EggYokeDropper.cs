using UnityEngine;
using System.Collections;

public class EggYokeDropper : MonoBehaviour {
    public GameObject Tarmac;
    public GameObject EggYoke;

    private GameObject Bowl;

    private bool Spawned = false;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Bowl == null) {
            Bowl = Tarmac.transform.GetChild(0).gameObject;
        }
        Debug.Log(Vector3.Distance(transform.position, Bowl.transform.position));
        //Debug.Log();
        if (!Spawned && Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(Bowl.transform.position.x, 0, Bowl.transform.position.z)) < 40 && transform.position.y > Bowl.transform.position.y + 30) {
            GameObject temp;
            temp = Instantiate(EggYoke, transform.position, Quaternion.identity) as GameObject;
            temp.transform.parent = Bowl.transform;
            Spawned = true;
        }
	}
}
