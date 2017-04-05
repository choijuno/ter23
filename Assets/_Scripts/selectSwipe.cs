using UnityEngine;
using System.Collections;

public class selectSwipe : MonoBehaviour {
	public GameObject[] slot = new GameObject[3];
	public int slotPoint;

	void Start() {
		slotPoint = 1;
	}

	void Update () {
		transform.localPosition = new Vector3 (Mathf.Lerp (transform.localPosition.x, slot [slotPoint].transform.localPosition.x, 0.3f), Mathf.Lerp (transform.localPosition.y, slot [slotPoint].transform.localPosition.y, 0.3f), Mathf.Lerp (transform.localPosition.z, slot [slotPoint].transform.localPosition.z, 0.3f));
	}
}
