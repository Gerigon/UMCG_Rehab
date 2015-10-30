using UnityEngine;
using System.Collections;

public class FillableObject : MonoBehaviour {

    public float maxFilled;
    public float maxWidth;
    public GameObject scalableLiquid;
    public AnimationCurve curve;
    public float progress;

    private Vector3 startScale;
    private Vector3 startVector;
    private float fillProgress =0;

	// Use this for initialization
	void Start ()
    {
        startScale = scalableLiquid.transform.lossyScale;
        startVector = scalableLiquid.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        curve.Evaluate(fillProgress);
        progress = curve.Evaluate(fillProgress);
	}

    void OnParticleCollision(GameObject other)
    {
        fillProgress += 0.001f;
        //Debug.Log(startScale.localPosition.z);
        //if (scalableLiquid.transform.localScale.z < maxFilled)\
        scalableLiquid.transform.localPosition = new Vector3(scalableLiquid.transform.localPosition.x, scalableLiquid.transform.localPosition.y, startVector.z + curve.Evaluate(fillProgress) * (maxFilled - startVector.z));
        scalableLiquid.transform.localScale = new Vector3(startScale[0] + curve.Evaluate(fillProgress) * (maxWidth - startScale[0]), 0.001f, startScale[2] + curve.Evaluate(fillProgress) * (maxWidth - startScale[2]));

    }
}
