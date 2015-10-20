using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    public GameObject indicationMarker;
    public GameObject[] indicationMarkers;

    public GameObject MovementMarker;

    public float MultiplacationOffset;
    public float PlusOffset;
    public float HeightOffset;
    public float scaleModifier;

    public int currentCount = 10;


    // Use this for initialization
    void Start()
    {
        indicationMarkers = new GameObject[8];
        IniateObjects();
    }

    

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), Vector3.forward * 100, Color.yellow, 10f);
        //Debug.Break();
        if (currentCount == 10)
        {
            for (int i = 0; i < indicationMarkers.Length; i++)
            {
                Debug.Log(Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[i].transform.position) + " " + i);
                if (Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[i].transform.position) < 25)
                {
                    indicationMarkers[i].GetComponent<Renderer>().material.color = Color.green;
                    currentCount = indicationMarkers[i].GetComponent<IndicationMarker>().CircleCount;
                    break;
                }
            }
        }
        else
        {
            Debug.Log(Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[currentCount + 1].transform.position)+" + "+ (currentCount+1));

            if (Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[currentCount + 1].transform.position) < 25)
            {
                indicationMarkers[currentCount + 1].GetComponent<Renderer>().material.color = Color.green;
                currentCount = indicationMarkers[currentCount + 1].GetComponent<IndicationMarker>().CircleCount;
            }
        }
        if (currentCount == 7)
            currentCount = -1;
    }

    private void IniateObjects()
    {
        Debug.Log("objects spawned");

        GameObject tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x - (PlusOffset * transform.localScale.x*100), transform.position.y + HeightOffset, transform.position.z), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale*100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 0;
        indicationMarkers[0] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x + (PlusOffset * transform.localScale.x*100), transform.position.y + HeightOffset, transform.position.z), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 4;
        indicationMarkers[4] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x, transform.position.y + HeightOffset, transform.position.z - (PlusOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 6;
        indicationMarkers[6] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x, transform.position.y + HeightOffset, transform.position.z + (PlusOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 2;
        indicationMarkers[2] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x - (MultiplacationOffset * transform.localScale.x*100), transform.position.y + HeightOffset, transform.position.z + (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 1;
        indicationMarkers[1] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x - (MultiplacationOffset * transform.localScale.x*100), transform.position.y + HeightOffset, transform.position.z - (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 7;
        indicationMarkers[7] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x + (MultiplacationOffset * transform.localScale.x*100), transform.position.y + HeightOffset, transform.position.z + (MultiplacationOffset * transform.localScale.x*100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 3;
        indicationMarkers[3] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(transform.position.x + (MultiplacationOffset * transform.localScale.x*100), transform.position.y + HeightOffset, transform.position.z - (MultiplacationOffset * transform.localScale.x*100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = transform.localScale * 100 / scaleModifier;
        tempMarker.transform.parent = transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 5;
        indicationMarkers[5] = tempMarker;
    }
}
