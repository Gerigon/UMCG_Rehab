using UnityEngine;
using System.Collections;

public class BoterDropper : MonoBehaviour {
    private GameObject pan;
    private GameObject stones;
    public GameObject _GameManager;

    private float alpha = 1f;

	// Use this for initialization
	void Start () {
        _GameManager = GameObject.Find("_GameManager");
	}
	
	// Update is called once per frame
	void Update () {
        if (pan == null)
        {
            stones = GameObject.Find("ImageTarget");
            pan = stones.transform.GetChild(0).gameObject;
        }
        
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(pan.transform.position.x, 0, pan.transform.position.z)) < 50 && transform.position.y > pan.transform.position.y + 120)
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = pan.transform;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(fade());
        _GameManager.GetComponent<GameManager>().iniated = false;
        _GameManager.GetComponent<GameManager>().currentStep = 8;
    }

    IEnumerator fade()
    {
        for (int i = 0; i < 180; i++)
        {
            transform.GetChild(0).transform.GetComponent<Renderer>().material.color = new Color(transform.GetChild(0).transform.GetComponent<Renderer>().material.color.r, transform.GetChild(0).transform.GetComponent<Renderer>().material.color.g, transform.GetChild(0).transform.GetComponent<Renderer>().material.color.b, 1 - (i / 179f));
            yield return new WaitForEndOfFrame();
        }
    }
}
