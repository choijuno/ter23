using UnityEngine;
using System.Collections;

public class GoogleLogin : MonoBehaviour {

	// Use this for initialization
	void Awake ()
	{
		GoogleManager.GetInstance.InitializeGPGS();

		if(GoogleManager.GetInstance.CheckLogin())
			GoogleManager.GetInstance.LoginGPGS();
	}
}
