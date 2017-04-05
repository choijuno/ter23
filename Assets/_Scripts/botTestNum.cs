using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class botTestNum : MonoBehaviour {

    public int bot_testNum;
    public GameObject gameManager;
    

    public enum botStat
    {
        none=0,
        picket,
        card,
        fire,
        tae

    }

    public botStat botTestStat;

    // Use this for initialization
    void Start () {
        this.GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarFace[bot_testNum];

	}
	
	
}
