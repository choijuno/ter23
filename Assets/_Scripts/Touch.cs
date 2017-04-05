using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public GameObject myAvatar;
	public float AvatarScale;

	public Transform myCamera;
	public float Camera_BaseY;

	public float speed;
	private Vector3 target;

	public GameObject top;
	public GameObject bottom;
	public GameObject left;
	public GameObject right;


    public GameObject myInfo;

	int testCount;

	void Start () {
		
		target = transform.position;
		myAvatar.transform.localScale = new Vector3 (AvatarScale, AvatarScale, AvatarScale);

	}

	void Update () {

		//Debug.Log ("speed : " + speed);

		Ray HookRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (HookRay.origin, HookRay.direction, Color.green);

		RaycastHit HookHit;

		if (Input.GetMouseButtonDown (0)) {
			
			if (!GameManager.talkCheck) {
				
				if (Physics.Raycast (HookRay, out HookHit)) {

					if (HookHit.collider.CompareTag ("ground")) {
						Debug.DrawRay (HookRay.origin, HookRay.direction, Color.red);

						target = HookHit.point;

						Debug.Log ("Hook was hit to ground.");

                        if (transform.position.x >= Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
                        {
                            myAvatar.transform.localScale = new Vector3(AvatarScale, AvatarScale, AvatarScale);
                        }
                        else
                        {
                            myAvatar.transform.localScale = new Vector3(-AvatarScale, AvatarScale, AvatarScale);
                        }
                    }

                        if (HookHit.collider.CompareTag("myCha"))
                        {
                            GameManager.talkCheck = true;
                            myInfo.SetActive(true);
                        }

                        if (HookHit.collider.CompareTag("other"))
                        {
                        
                        }
                    }
			} else {
				target = transform.position;
			}


		}





		if (Input.GetMouseButtonUp (0)) {
			
			if (!GameManager.talkCheck) {

				if (testCount == 0) {
					//target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					//target.y = transform.position.y;

					//Debug.Log (Camera.main.ScreenToWorldPoint (Input.mousePosition).x);

                    /*
					

                    */
				} else {
					testCount = 0;
				}

			} else {
				testCount = 1;
				//target.x = transform.position.x;
				//target.z = transform.position.z;
			}


		}

		if (!GameManager.talkCheck) {
			//lerp
			transform.position = new Vector3(Mathf.Lerp(transform.position.x,target.x,0.01f), Mathf.Lerp(transform.position.y,target.y,0.01f), Mathf.Lerp(transform.position.z,target.z,0.01f));

			//transform.position = new 
		}

		if (transform.position.z > top.transform.position.z) {
			target = transform.position;
			transform.position = new Vector3 (transform.position.x,transform.position.y,top.transform.position.z);
		}

		if (transform.position.z < bottom.transform.position.z) {
			target = transform.position;
			transform.position = new Vector3 (transform.position.x,transform.position.y,bottom.transform.position.z);
		}

		if (transform.position.x > right.transform.position.x) {
			target = transform.position;
			transform.position = new Vector3 (right.transform.position.x,transform.position.y,transform.position.z);
		}

		if (transform.position.x < left.transform.position.x) {
			target = transform.position;
			transform.position = new Vector3 (left.transform.position.x,transform.position.y,transform.position.z);
		}

		myCamera.transform.position = new Vector3 (Mathf.Lerp(myCamera.transform.position.x,transform.position.x,0.05f), myCamera.transform.position.y, Mathf.Lerp(myCamera.transform.position.z,transform.position.z + Camera_BaseY,0.05f));
	}
}
