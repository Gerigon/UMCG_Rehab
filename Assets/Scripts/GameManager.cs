using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Stones;
    public GameObject Chips;
    public GameObject Tarmac;
    public GameObject GripperTarget;

    public GameObject Kom;
    public GameObject Bloem;
    public GameObject Melk;
    public GameObject Gripper;
    public GameObject Ei;
    public GameObject GebrokenEi;
    public GameObject Boter;
    public GameObject Bord;
    public GameObject Mixer;
    public GameObject currentGripper;

    public GameObject BeslagEmitter;
    private GameObject tempEmitter;

    public Canvas Interface;

    public GameObject indicationMarker;
    public GameObject[] indicationMarkers;

    public GameObject MovementMarker;

    private Vector3 prevPanPosition;

    public Texture PancakeDone;

    public float MultiplacationOffset;
    public float PlusOffset;
    public float HeightOffset;
    public float scaleModifier;

    public int currentCount = 10;
    public int startCount;
    public int circleCount;

    public int currentStep =1;

    public bool iniated;
    public bool lerping;

    public Animation PancakeFlip;

    private Quaternion startingRotation;

    void Start ()
    {
        GameObject temp;

        temp = Instantiate(Kom, Tarmac.transform.position + new Vector3(0, 25, 0), Quaternion.AngleAxis(90,Vector3.left)) as GameObject;
        temp.transform.parent = Tarmac.transform;
        temp = Instantiate(Bloem, Chips.transform.position + new Vector3(0, 25, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
        temp.transform.parent = Chips.transform;
        temp = null;
        indicationMarkers = new GameObject[8];

        currentGripper = GameObject.Find("Gripperr(Clone)");
    }

    void Update()
    {
        if (currentStep == 1)
        {
            GripperStick(Chips.transform.GetChild(0).gameObject);
        }
        if (Tarmac.transform.GetChild(0).GetComponent<FillableObject>().progress > 0.5f && currentStep == 1)
        {
            GameObject temp;
            Interface.GetComponent<Text>().text = "Pak de melk en giet het in de kom";
            
            Destroy(Chips.transform.GetChild(0).gameObject);
            temp = Instantiate(Melk, Chips.transform.position + new Vector3(0, 75, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform;
            Debug.Log(Chips.transform.GetChild(0).gameObject);

            temp = null;

            currentStep = 2;
        }
        if (currentStep == 2)
        {
            GripperStick(Chips.transform.GetChild(0).gameObject);
        }
        if (Tarmac.transform.GetChild(0).GetComponent<FillableObject>().progress >= 1f && currentStep == 2)
        {
            GameObject temp;
            Destroy(Chips.transform.GetChild(0).gameObject);
            temp = Instantiate(Mixer, Chips.transform.position + new Vector3(0, 15, -10), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            //temp.transform.localScale = new Vector3(2, 2, 2);
            temp.transform.parent = Chips.transform;
            MovementMarker = temp;
            IniateObjects(Tarmac.transform.GetChild(0).gameObject);
            temp = null;

            currentStep = 3;

        }
        if (currentStep == 3)
        {
            GripperStick(Chips.transform.GetChild(0).gameObject);
            Interface.GetComponent<Text>().text = "Mix het beslag door alle bolletjes " + (3 - circleCount) + " maal groen te maken";
            CheckProgress();
            if (circleCount == 3)
            {
                for (int i = 0; i < indicationMarkers.Length; i++)
                {
                    Destroy(indicationMarkers[i].gameObject);
                }
                Destroy(Chips.transform.GetChild(0).gameObject);
                currentStep = 4;
            }
        }
        if (currentStep == 4 && !iniated)
        {
            GameObject temp;
            Interface.GetComponent<Text>().text = "Breek het ei op de zijkant van de beslag kom";
            temp = Instantiate(Ei, Chips.transform.position + new Vector3(0, 10, 0), Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform;
            temp.GetComponent<EggBreaker>().colliderTargetGameObject = Tarmac;

            //temp = Instantiate(GebrokenEi, Chips.transform.position + new Vector3(0, 0, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            //temp.transform.parent = Chips.transform.GetChild(0).transform;
            temp = null;
            iniated = true;
        }
        if (currentStep == 4)
        {
            GripperStick(Chips.transform.GetChild(0).gameObject);
            //GripperStick(Chips.transform.GetChild())
        }
        if (currentStep == 5)
        {
            iniated = false;
            GameObject temp;
            Destroy(Chips.transform.GetChild(0).gameObject);
            temp = Instantiate(Mixer, Chips.transform.position + new Vector3(0, 15, -10), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
            temp.transform.parent = Chips.transform;
            MovementMarker = temp;
            IniateObjects(Tarmac.transform.GetChild(0).gameObject);
            startCount = 0;
            currentCount = 10;
            //temp = null;
            currentStep = 6;
            circleCount = 0;
        }
        if (currentStep == 6)
        {
            GripperStick(Chips.transform.GetChild(0).gameObject);
            Interface.GetComponent<Text>().text = "Mix het beslag door alle bolletjes " + (3 - circleCount) + " maal groen te maken";
            CheckProgress();
            if (circleCount == 3)
            {
                for (int i = 0; i < indicationMarkers.Length; i++)
                {
                    Destroy(indicationMarkers[i].gameObject);
                }
                Destroy(Chips.transform.GetChild(0).gameObject);
                currentStep = 7;
            }
        }
        if (currentStep == 7)
        {
            Interface.GetComponent<Text>().text = "Pak een stuk boter en gooi het in de pan";
            Debug.Log(Vector3.Distance(currentGripper.transform.position + currentGripper.transform.localToWorldMatrix.MultiplyVector(transform.up), Stones.transform.GetChild(2).transform.GetChild(0).transform.position));
            if (!iniated && Vector3.Distance(currentGripper.transform.position + currentGripper.transform.localToWorldMatrix.MultiplyVector(transform.up), Stones.transform.GetChild(2).transform.GetChild(0).transform.position) < 40)
            {
                iniated = true;
                GameObject temp;
                temp = Instantiate(Boter, currentGripper.transform.position + currentGripper.transform.localToWorldMatrix.MultiplyVector(transform.up * 1.1f), Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                temp.transform.parent = currentGripper.transform;
                temp.transform.localScale = new Vector3(30f, 350f,400f);
                Stones.transform.GetChild(2).localScale = new Vector3(0.8f, 1, 1);
            }
            /*
            if (iniated)
            {
                if (temp.transform.GetChild(0).transform.GetComponent<Renderer>().material.color.a == 0)
                {
                    currentStep = 8;
                    
                }
            
            }
        */
        }
        if (currentStep == 8)
        {
            Interface.GetComponent<Text>().text = "Giet het pannenkoeken beslag in de pan";
            GripperStick(Tarmac.transform.GetChild(0).gameObject);
            if (Vector3.Angle(Tarmac.transform.GetChild(0).transform.forward, Vector3.up) > 10)
            {
                if (!iniated)
                {
                    //Tarmac.transform.GetChild(0).GetComponent<FillableObject>().enabled = false;
                    tempEmitter = Instantiate(BeslagEmitter, CalculatePouringPoint(), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
                    Debug.Log("spawned emitter");
                    iniated = true;
                }
                else
                {
                    tempEmitter.GetComponent<ParticleSystem>().enableEmission = true;
                }
                tempEmitter.transform.position = CalculatePouringPoint();
            }
            else if (iniated)
            {
                tempEmitter.GetComponent<ParticleSystem>().enableEmission = false;
            }
            
            if (Stones.transform.GetChild(1).transform.GetChild(0).localScale.x == 1.2f)
            {
                currentStep = 9;
                iniated = false;
                prevPanPosition = Stones.transform.GetChild(1).transform.position;
                Destroy(tempEmitter);
                Tarmac.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if (currentStep == 9)
        {
            GripperStick(Stones.transform.GetChild(1).gameObject);
            Debug.Log(Vector3.Distance(Stones.transform.GetChild(1).transform.position, prevPanPosition));
            Interface.GetComponent<Text>().text = "Draai de pannenkoek door de pan snel op te tillen";
            if (Vector3.Distance(Stones.transform.GetChild(1).transform.position, prevPanPosition) > 30)
            {
                Debug.Log("playing animation");
                //Stones.transform.GetChild(1).transform.GetChild(0).GetComponent<Animation>().Play();
                startingRotation = Stones.transform.GetChild(1).transform.GetChild(0).transform.rotation;
                if (!iniated)
                StartCoroutine(FlipPannenkoek());
                currentStep = 10;
            }
            prevPanPosition = Stones.transform.GetChild(1).transform.position;
        }
        if (currentStep == 10)
        {
            if (!iniated)
            {
                GameObject temp;
                temp = Instantiate(Bord, Tarmac.transform.position + new Vector3(0, 10, 0), Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
                temp.transform.parent = Tarmac.transform;
                iniated = true;
            }
            if (!lerping)
            {
                Debug.Log(Vector3.Angle(Stones.transform.GetChild(1).transform.forward, Vector3.up));
                Debug.Log(Vector3.Distance(Stones.transform.GetChild(1).transform.GetChild(0).transform.position, Tarmac.transform.GetChild(1).transform.position));
                if (Vector3.Angle(Stones.transform.GetChild(1).transform.forward, Vector3.up) > 10)
                {
                    if (Vector3.Distance(Stones.transform.GetChild(1).transform.GetChild(0).transform.position, Tarmac.transform.GetChild(1).transform.position) < 165)
                    {
                        if (!lerping)
                        {
                            Stones.transform.GetChild(1).transform.GetChild(0).GetComponent<PancakeLerp>().triggered = false;
                            lerping = true;
                            Interface.GetComponent<Text>().text = "Goed Gedaan! dit is het einde van de demo. Dankje voor je participatie";
                        }
                    }
                }
            }
        }
    }
    public void GripperStick (GameObject objectToStick)
    {
        /*
        if (Vector3.Distance(GripperTarget.transform.GetChild(0).transform.position + GripperTarget.transform.GetChild(0).transform.localToWorldMatrix.MultiplyVector(Vector3.up),objectToStick.transform.position) < 10)
        {
            objectToStick.GetComponent<FollowTarget>().following = true;
        }
        */
        Debug.Log(objectToStick);
        Debug.Log(Vector3.Distance(currentGripper.transform.position + currentGripper.transform.localToWorldMatrix.MultiplyVector(Vector3.up), objectToStick.transform.position));
        if (Vector3.Distance(currentGripper.transform.position + currentGripper.transform.localToWorldMatrix.MultiplyVector(Vector3.up), objectToStick.transform.position) < 30)
        {
            objectToStick.GetComponent<FollowTarget>().following = true;
        }
    }
    IEnumerator FlipPannenkoek()
    {
        Vector3 beginPos = Stones.transform.GetChild(1).transform.GetChild(0).transform.position;
        Quaternion desiredRotation = Quaternion.Euler(0, 180, 0) * startingRotation;
        for (int i = 0; i < 60; i++)
        {
            
            if (i < 30)
                Stones.transform.GetChild(1).transform.GetChild(0).transform.position = new Vector3(0, 4, 0) + Stones.transform.GetChild(1).transform.GetChild(0).transform.position;
            else
                Stones.transform.GetChild(1).transform.GetChild(0).transform.position = new Vector3(0, -4, 0) + Stones.transform.GetChild(1).transform.GetChild(0).transform.position;

            Stones.transform.GetChild(1).transform.GetChild(0).transform.Rotate(0, 3, 0, Space.Self);
            yield return new WaitForEndOfFrame();
        }
        Stones.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().material.SetTexture(0, PancakeDone);
    }
    IEnumerator LerpPancake()
    {
        lerping = true;
        while (Vector3.Distance(Stones.transform.GetChild(1).transform.GetChild(0).transform.position, Tarmac.transform.GetChild(1).transform.position) > 0.05f)
        {
            Stones.transform.GetChild(1).transform.GetChild(0).transform.position = Vector3.Lerp(Stones.transform.GetChild(1).transform.GetChild(0).transform.position, Tarmac.transform.GetChild(1).transform.position, 20f*Time.deltaTime);

            yield return null;
        }
        
    }

    private void IniateObjects(GameObject kom)
    {
        Debug.Log("objects spawned");
        GameObject tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x - (PlusOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 0;
        indicationMarkers[0] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x + (PlusOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 4;
        indicationMarkers[4] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x, kom.transform.position.y + HeightOffset, kom.transform.position.z - (PlusOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 6;
        indicationMarkers[6] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x, kom.transform.position.y + HeightOffset, kom.transform.position.z + (PlusOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier; ;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 2;
        indicationMarkers[2] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x - (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z + (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 1;
        indicationMarkers[1] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x - (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z - (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 7;
        indicationMarkers[7] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x + (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z + (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
        tempMarker.GetComponent<Renderer>().material.color = Color.blue;
        tempMarker.GetComponent<IndicationMarker>().CircleCount = 3;
        indicationMarkers[3] = tempMarker;

        tempMarker = Instantiate(indicationMarker, new Vector3(kom.transform.position.x + (MultiplacationOffset * transform.localScale.x * 100), kom.transform.position.y + HeightOffset, kom.transform.position.z - (MultiplacationOffset * transform.localScale.x * 100)), Quaternion.identity) as GameObject;
        tempMarker.transform.localScale = Vector3.one * scaleModifier;
        tempMarker.transform.parent = Tarmac.transform.GetChild(0).transform;
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
                    Debug.Log("green");
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
    private Vector3 CalculatePouringPoint()
    {
        Vector3 KomUp = Tarmac.transform.GetChild(0).transform.forward;
        Vector3 NormalVlak = Vector3.Cross(KomUp, Vector3.up);
        Vector3 LowestVector = Quaternion.AngleAxis(-90, NormalVlak) * KomUp;
        //Debug.DrawRay(Tarmac.transform.GetChild(0).transform.position +(KomUp * 31f) , LowestVector * 50, Color.red, 10f);
        return Tarmac.transform.GetChild(0).transform.position + (KomUp * 31f) + LowestVector * 52;
    }
}
