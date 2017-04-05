using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public Camera myCamera;

	private Vector3 mousePos;

	Ray myRay;
	RaycastHit Hit;

	// Use this for initialization
	void Start () {
		myCamera = myCamera.GetComponent<Camera> ();
		StartCoroutine ("moveRay2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator moveRay() {

		RaycastHit Hit;

		while (true) {
				//Vector3
			/*
			if (Input.GetMouseButtonDown (0)) {
				if (Physics.Raycast (lazerPos.transform.position, lazerPos.transform.LookAt(myCamera.ScreenToWorldPoint (mousePos)), out Hit, 4000f)) {
					if (Hit.collider.gameObject.CompareTag ("ground")) {
						Debug.Log ("hit! ==== " + Hit.point);
					}
				}
			}*/

			yield return null;
		}
	}

	IEnumerator moveRay2() {
		
		while (true) {
			
			//Camera.main.ScreenToWorldPoint (mousePos);

			//Debug.Log (mousePos);

			if (Input.GetMouseButtonDown (0)) {

				//transform.position = new Vector3 (Camera.main.ScreenPointToRay().GetPoint);

				
				mousePos = Input.mousePosition;
				myRay = myCamera.ScreenPointToRay (mousePos);

				Debug.Log (myCamera.ScreenToWorldPoint (mousePos));
			}


			yield return null;
		}
	}



}
