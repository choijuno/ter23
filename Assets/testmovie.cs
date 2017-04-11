using UnityEngine;
using System.Collections;

public class testmovie : MonoBehaviour {
	 string strUrl = "http://ter23api.viewlab.kr/api/movie/?cidx=1";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testURL()
	{
		Application.OpenURL("http://ter23api.viewlab.kr/api/movie/?cidx=1");
	}
}
