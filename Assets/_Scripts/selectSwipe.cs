using UnityEngine;
using System.Collections;

public class selectSwipe : MonoBehaviour {
	public GameObject[] slot = new GameObject[36];

	public int slotPoint;
    public bool slotCheck;

	void Start() {
		slotPoint = 0;
        slotCheck = true;
	}

	void Update () {
        transform.parent = slot[GameManager.player_select - 1].transform;
        Debug.Log("select : " + (GameManager.player_select - 1));
        if (slotCheck)
        {

            //transform.parent = slot[GameManager.player_select - 1].transform;
            slotCheck = false;

        }
		transform.localPosition = new Vector3 (Mathf.Lerp (transform.localPosition.x, 0, 0.3f), transform.localPosition.y, transform.localPosition.z);
	}
}
