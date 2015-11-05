using UnityEngine;
using System.Collections;

public class PancakeLerp : MonoBehaviour {

    public GameObject Tarmaq;
    private Vector3 startMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public bool triggered = true;
    private bool startLerp;

    void Start()
    {
        Tarmaq = GameObject.Find("ImageTarget (1)");
    }
    void Update()
    {
        if (!triggered)
        {
            startTime = Time.time;
            startMarker = transform.position;
            journeyLength = Vector3.Distance(startMarker, Tarmaq.transform.GetChild(1).transform.position + new Vector3(0,10,0));
            startLerp = true;
            triggered = true;
            transform.parent = null;
            //transform.rotation = Quaternion.Euler(90,0,0);
        }
        if (startLerp)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(270, 90, 0), fracJourney);
            transform.position = Vector3.Lerp(startMarker, Tarmaq.transform.GetChild(1).transform.position + new Vector3(0, 10, 0), fracJourney);
        }
    }
}
