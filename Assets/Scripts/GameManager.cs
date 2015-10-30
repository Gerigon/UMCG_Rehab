using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Stones;
    public GameObject Chips;
    public GameObject Tarmac;

    public GameObject Kom;
    public GameObject Bloem;
    public GameObject Melk;
    public GameObject Gripper;
    public GameObject Ei;
    public GameObject GebrokenEi;

    public Canvas Interface;

    public GameObject indicationMarker;
    public GameObject[] indicationMarkers;

    public GameObject MovementMarker;

    public float MultiplacationOffset;
    public float PlusOffset;
    public float HeightOffset;
    public float scaleModifier;

    public int currentCount = 10;
    public int startCount;
    public int circleCount;

    public int currentStep =1;

    private bool iniated;

	void Start ()
    {
        GameObject temp;
        temp = Instantiate(Kom, Tarmac.transform.position + new Vector3(0, 25, 0), Quaternion.AngleAxis(90,Vector3.left)) as GameObject;
        temp.transform.parent = Tarmac.transform;
        temp = Instantiate(Bloem, Chips.transform.position + new Vector3(0, 25, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
        temp.transform.parent = Chips.transform;
        temp = null;
        indicationMarkers = new GameObject[8];
    }
	
	void Update ()
    {
        if (Tarmac.transform.GetChild(0).GetComponent<FillableObject>().progress > 0.5f && currentStep == 1)
        {
            GameObject temp;
            Interface.GetComponent<Text>().text = "Grab the milk and pour it in";
            currentStep = 2;
            Destroy(Chips.transform.GetChild(0).gameObject);
            temp = Instantiate(Melk, Chips.transform.position + new Vector3(0, 15, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform;
            temp = null;
        }
        if (Tarmac.transform.GetChild(0).GetComponent<FillableObject>().progress > 0.95f && currentStep == 2)
        {
            GameObject temp;
            currentStep = 3;
            Destroy(Chips.transform.GetChild(0).gameObject);
            temp = Instantiate(Gripper, Chips.transform.position + new Vector3(0, 15, -10), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform;
            temp.transform.localScale = new Vector3(0.02917157f, 0.2020152f, 0.02917158f);
            MovementMarker = temp;
            IniateObjects(Tarmac.transform.GetChild(0).gameObject);
            temp = null;

        }
        if (currentStep == 3)
        {
            Interface.GetComponent<Text>().text = "Stir the pancake batter "+(3 - circleCount)+" times";
            CheckProgress();
            if (circleCount == 3)
            {
                currentStep = 4;
            }
        }
        if (currentStep == 4)
        {
            GameObject temp;
            Destroy(Chips.transform.GetChild(0).gameObject);
            Interface.GetComponent<Text>().text = "Break the egg on the side of the bowl";
            temp = Instantiate(Ei, Chips.transform.position + new Vector3(0, 10, 0), Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform;
            temp.GetComponent<EggBreaker>().colliderTargetGameObject = Tarmac;

            temp = Instantiate(GebrokenEi, Chips.transform.position + new Vector3(0, 0, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform.GetChild(0).transform;
            temp = null;
            currentStep = 5;
        }
        if (currentStep == 5)
        {

        }
	}

    private void IniateObjects(GameObject kom)
    {
        Debug.Log("objects spawned");
            GameObject tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x - (PlusOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
            tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 0;
            indicationMarkers[0] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x + (PlusOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 4;
            indicationMarkers[4] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x, kom.transform.position.y + HeightOffset, kom.transform.position.z - (PlusOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 6;
            indicationMarkers[6] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x, kom.transform.position.y + HeightOffset, kom.transform.position.z + (PlusOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier; ;
            tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 2;
            indicationMarkers[2] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x - (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z + (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 1;
            indicationMarkers[1] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x - (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z - (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 7;
            indicationMarkers[7] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x + (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z + (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 3;
            indicationMarkers[3] = tempMarker;

            tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x + (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z - (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
            tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = transform;
            tempMarker.GetComponent<Renderer>().material.color = Color.blue;
            tempMarker.GetComponent<IndicationMarker>().CircleCount = 5;
            indicationMarkers[5] = tempMarker;
            tempMarker = null;
    }
    private void CheckProgress()
    {
        if (currentCount == 10)
        {
            for (int i = 0; i < indicationMarkers.Length; i++)
            {
                Debug.Log(Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[i].transform.position) + " " + i);
                if (Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[i].transform.position) < 15)
                {
                    indicationMarkers[i].GetComponent<Renderer>().material.color = Color.green;
                    currentCount = indicationMarkers[i].GetComponent<IndicationMarker>().CircleCount;
                    startCount = indicationMarkers[i].GetComponent<IndicationMarker>().CircleCount;
                    break;
                }
            }
        }
        else
        {
            Debug.Log(Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[currentCount + 1].transform.position)+" + "+ (currentCount+1));

            if (Vector3.Distance(MovementMarker.transform.position + MovementMarker.transform.localToWorldMatrix.MultiplyVector(transform.up), indicationMarkers[currentCount + 1].transform.position) < 15)
            {
                indicationMarkers[currentCount + 1].GetComponent<Renderer>().material.color = Color.green;
                currentCount = indicationMarkers[currentCount + 1].GetComponent<IndicationMarker>().CircleCount;
                if (startCount == currentCount)
                {
                    circleCount++;
                    for (int i = 0; i < indicationMarkers.Length; i++)
                    {
                        indicationMarkers[i].GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
            }
        }
        if (currentCount == 7)
            currentCount = -1;
    }
}
