using UnityEngine;
using System.Collections;

public class ray : MonoBehaviour {

	public Transform player;

	public GameObject Hook;

	public GameObject HookChild;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray HookRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (HookRay.origin, HookRay.direction, Color.green);
		//Debug.Log (HookRay);

		RaycastHit HookHit;


		if (Input.GetMouseButtonDown (0)) {
			HookChild = null;
			if (Physics.Raycast (HookRay, out HookHit)) {
				Debug.DrawRay (HookRay.origin, HookRay.direction, Color.red);
				//HookChild = Instantiate (Hook, HookHit.point, Quaternion.identity) as GameObject;
				player.localPosition = HookHit.point;
				Debug.Log ("Hook was hit");
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			if (HookChild != null) {
				Destroy (HookChild);
			}
		}


	}
}
