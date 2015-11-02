using UnityEngine;
using System.Collections;

public class EggBreaker : MonoBehaviour {
    public GameObject brokenEgg; //should be an inactive child of the same target
    public GameObject colliderTargetGameObject; //the ImageTarget belonging to the GameObject that breaks the egg (for relative speed calculations)
    //private GameObject parentObject;
    private Vector3 position = new Vector3();
    private Vector3 prevPosition = new Vector3();
    private Vector3 colliderTargetPosition = new Vector3();
    private Vector3 prevColliderTargetPosition = new Vector3();
    public float breakingSpeed;
    float speed = 0;

	// Use this for initialization
	void Start () {
        //parentObject = transform.parent.gameObject;
        position = transform.position;
        prevPosition = position;

        colliderTargetPosition = colliderTargetGameObject.transform.position;
        prevColliderTargetPosition = colliderTargetPosition;
    }
	
	// Update is called once per frame
	void Update () {
        //find new positions
        position = transform.position;
        colliderTargetPosition = colliderTargetGameObject.transform.position;

        //calculate the speed according to found positions
        Vector3 pDistance = new Vector3( position[0] - prevPosition[0] - (colliderTargetPosition[0] - prevColliderTargetPosition[0]), position[1] - prevPosition[1] - (colliderTargetPosition[1] - prevColliderTargetPosition[1]), position[2] - prevPosition[2] - (colliderTargetPosition[2] - prevColliderTargetPosition[2]) );
        speed = Mathf.Sqrt(pDistance[0] * pDistance[0] + pDistance[1] * pDistance[1] + pDistance[2] * pDistance[2]);
        Debug.Log(speed);

        //save the current position for the next frame
        prevPosition = position;
        prevColliderTargetPosition = colliderTargetPosition;
        //GuiTextDebug.debug("x: " + position[0].ToString() + " y: " + position[1].ToString() + " z: " + position[2].ToString());
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "CollideWithEgg") {
            if (speed > breakingSpeed) {
                breakEgg();
            }
        }
    }

    void breakEgg() {
        //brokenEgg.SetActive(true);
        GameObject temp;
        temp = Instantiate(brokenEgg, transform.position, Quaternion.identity) as GameObject;
        temp.transform.parent = transform.parent;
        temp.GetComponent<EggYokeDropper>().Tarmac = colliderTargetGameObject;
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
