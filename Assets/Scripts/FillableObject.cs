using UnityEngine;
using System.Collections;

public class FillableObject : MonoBehaviour {

    public float maxFilled;
    public float maxWidth;
    public GameManager _gameManager;
    public GameObject scalableLiquid;
    public GameObject scalableBatter;
    public AnimationCurve curve;
    public float progress;

    public Vector3 startScale;
    public Vector3 startVector;
    private float fillProgress =0;

    private bool initiated;
    public bool IsPan = false;
    public GameObject Pannenkoek;
    private float pancakeSize = 0.0f;

    private GameObject Tarmac;
    private GameObject Stones;

    // Use this for initialization
    void Start ()
    {
        _gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
        Tarmac = _gameManager.Tarmac;
        if (!IsPan)
        {
            startScale = scalableLiquid.transform.lossyScale;
            startVector = scalableLiquid.transform.localPosition;
            Stones = _gameManager.Stones;
            Stones.transform.GetChild(1).GetComponent<FillableObject>().startScale = startScale;
            Stones.transform.GetChild(1).GetComponent<FillableObject>().startVector = startVector;
            Stones.transform.GetChild(1).GetComponent<FillableObject>().maxFilled = maxFilled;
            Stones.transform.GetChild(1).GetComponent<FillableObject>().maxWidth = maxWidth;
        }
    }
	
	// Update is called once per frame
	void Update () {
        progress = /*curve.Evaluate(fillProgress)*/ Mathf.Sin(fillProgress * Mathf.PI * 0.5f);
        if(_gameManager.currentStep == 8 && !initiated && IsPan)
        {
            scalableBatter = Instantiate(Pannenkoek) as GameObject;
            scalableBatter.transform.position += new Vector3(0, 1, 0);
            scalableBatter.transform.parent = gameObject.transform;
            scalableBatter.transform.localScale = new Vector3(pancakeSize, pancakeSize, scalableBatter.transform.localScale.z);

            scalableLiquid = Tarmac.transform.GetChild(0).transform.GetChild(0).gameObject;

            //startScale = scalableLiquid.transform.lossyScale;
            //startVector = scalableLiquid.transform.localPosition;

            initiated = true;
        }
	}

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Particles Colliding");
        if (_gameManager.currentStep < 8)
        {
            fillProgress += 0.001f * (1 / 0.747f);
            scalableLiquid.transform.localPosition = new Vector3(scalableLiquid.transform.localPosition.x, scalableLiquid.transform.localPosition.y, startVector.z +  Mathf.Sin(fillProgress * Mathf.PI * 0.5f) * (maxFilled - startVector.z));
            scalableLiquid.transform.localScale = new Vector3(startScale[0] + Mathf.Sin(fillProgress * Mathf.PI * 0.5f) * (maxWidth - startScale[0]), 0.001f, startScale[2] + Mathf.Sin(fillProgress * Mathf.PI * 0.5f) * (maxWidth - startScale[2]));
        }
        else
        {
            pancakeSize += 0.002f;
            scalableBatter.transform.localScale = new Vector3(curve.Evaluate(pancakeSize) * 1.2f, curve.Evaluate(pancakeSize) * 1.6f, scalableBatter.transform.localScale.z);
            Debug.Log(gameObject.name);
            if(IsPan)
            {
                

                fillProgress += 0.001f * (1 / 0.747f);
                if (fillProgress > 1)
                {
                    fillProgress = 1;
                    _gameManager.currentStep = 9;
                }
                scalableLiquid.transform.localPosition = new Vector3(scalableLiquid.transform.localPosition.x, scalableLiquid.transform.localPosition.y, startVector.z + Mathf.Sin(fillProgress * Mathf.PI * 0.5f + Mathf.PI * 0.5f) * (maxFilled - startVector.z));
                Debug.Log("fill progress: " + fillProgress + " MaxWidth: " + maxWidth + " Startscale: " + startScale + " Sinus: " + Mathf.Sin(fillProgress * Mathf.PI * 0.5f + Mathf.PI * 0.5f));
                scalableLiquid.transform.localScale = new Vector3(startScale[0] + Mathf.Sin(fillProgress * Mathf.PI * 0.5f + Mathf.PI * 0.5f) * (maxWidth - startScale[0]), 0.001f, startScale[2] + Mathf.Sin(fillProgress * Mathf.PI * 0.5f + Mathf.PI * 0.5f) * (maxWidth - startScale[2]));
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("EggYoke"))
        {
            Debug.Log("colliding with eggyoke");
            _gameManager.currentStep++;
            _gameManager.iniated = false;
            Destroy(collision.gameObject);
        }
    }
}
