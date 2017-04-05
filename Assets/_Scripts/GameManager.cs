using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class roomInfo_base
{
    public Text roomName;
    public Text roomMasterName;
    public GameObject Create_btn;
}


public class GameManager : MonoBehaviour {
    //login
    public static string user_id;
    public static string user_pass;

    //_2_room
    public static int select_roomNum;
    public roomInfo_base[] roomInfo;


    //
    public static bool talkCheck;
    public static bool playCheck;
    public static int channelNum;
    public static int picketNum;
    public static int plancardNum;
    public static int fireNum;
    public static int taeNum;
    public static int playerXp;

    //sginup
    public static int genderCheck = 0;

    //new
    public bool testVer;
	public bool deleteAll_data;
	public static string player_id;
	public static string player_pass;


    public static int player_select;

	public static bool[] player_char_have = new bool[3];
	public static int[] player_char_job = new int[3];	//1:시위대, 2:진행요원, 3:경찰.
	public static int[] player_char_level = new int[3];
	public GameObject[] slot_none = new GameObject[3];
	public GameObject[] slot_avatar = new GameObject[3];
	public GameObject[] slot_stat = new GameObject[3];
	public GameObject slot_true;
	public GameObject slot_false;



	public GameObject main_main;
	public GameObject backGround_name;
    public GameObject _0_login;
    public GameObject _1_cha;
    public GameObject _2_room;
    public GameObject _3_channel;
    public GameObject _4_chatLobby;
    public GameObject webviewObj;

    public Text ChannelNum_txt;
    public GameObject myPlayerAvatar;
    public GameObject myPlayerAvatar_Info;
    public GameObject myPlayerAvatar_picketUp;
    public GameObject myPlayerAvatar_picketDown;
    public GameObject myPlayerAvatar_planCardUp;
    public GameObject myPlayerAvatar_planCardDown;
    public GameObject myPlayerAvatar_fire1;
    public GameObject myPlayerAvatar_fire2;
    public GameObject myPlayerAvatar_fire3;
    public GameObject myPlayerAvatar_tae1;
    public GameObject myPlayerAvatar_tae2;

    public Sprite[] avatarImage;
    public Sprite[] avatarFace;
    public Sprite[] avatarPicketUp;
    public Sprite[] avatarPicketDown;
    public Sprite[] avatarPlanCardUp;
    public Sprite[] avatarPlanCardDown;
    public Sprite[] avatarFire1;
    public Sprite[] avatarFire2;
    public Sprite[] avatarFire3;
    public Sprite[] avatarTae1;
    public Sprite[] avatarTae2;



    public GameObject blackfade_out;
	// Use this for initialization
	void Start () {
        //WebViewScript.destroyCheck = false;
        //player_id = "player";
        Debug.Log(player_id);

        switch (Application.loadedLevelName) {
		case "0.testMain":
			Invoke ("mainSet", 1f);
			break;


		case "1.testGame":



			break;


		case "0.Main":


			if (deleteAll_data) {
				PlayerPrefs.DeleteAll ();
			}

            if(playCheck)
                {

                    backGround_name.SetActive(true);
                    backGround_name.GetComponent<Animator>().SetTrigger("up");
                    blackfade_out.SetActive(true);
                    _0_login.SetActive(true);
                    _0_login.GetComponent<Animator>().SetTrigger("out");
                    _1_cha.SetActive(true);
                    _1_cha.GetComponent<Animator>().SetTrigger("out");
                    _2_room.SetActive(true);
                    _2_room.GetComponent<Animator>().SetTrigger("out");
                    _3_channel.SetActive(true);
                    _3_channel.GetComponent<Animator>().SetTrigger("out");
                    _4_chatLobby.SetActive(true);


                    ChannelNum_txt.text = channelNum + " 채널";

                    _4_chatLobby.GetComponent<chatManager>().channelNum = channelNum.ToString();
                    _4_chatLobby.GetComponent<chatManager>().Invoke("chatJoin", 0.2f);

                    webviewObj.GetComponent<WebViewScript>().StartWebView();
                }
                else
                {
                    player_select = 0;
                    backGround_name.SetActive(true);
                    main_main.SetActive(false);
                    blackfade_out.SetActive(true);
                    Invoke("mainSet", 1f);
                }

			
                /*
                if (PlayerPrefs.HasKey ("slot_1_have")) {
                    player_char_have [0] = true;
                    slot_none [0].SetActive (false);
                    slot_avatar [0].SetActive (true);
                    slot_stat [0].SetActive (true);
                }
                if (PlayerPrefs.HasKey ("slot_2_have")) {
                    player_char_have [1] = true;
                    slot_none [1].SetActive (false);
                    slot_avatar [1].SetActive (true);
                    slot_stat [1].SetActive (true);
                    slot_true.SetActive (true);
                    slot_false.SetActive (false);
                }
                if (PlayerPrefs.HasKey ("slot_3_have")) {
                    player_char_have [2] = true;
                    slot_none [2].SetActive (false);
                    slot_avatar [2].SetActive (true);
                    slot_stat [2].SetActive (true);
                }
                */

            

            
			break;

		case "1.Game":
                talkCheck = false;
                playCheck = true;
                myPlayerAvatar.GetComponent<SpriteRenderer>().sprite = avatarFace[GameManager.player_select];
                myPlayerAvatar_Info.GetComponent<Image>().sprite = avatarImage[GameManager.player_select];
                myPlayerAvatar_picketUp.GetComponent<Image>().sprite = avatarPicketUp[GameManager.player_select];
                myPlayerAvatar_picketDown.GetComponent<Image>().sprite = avatarPicketDown[GameManager.player_select];
                myPlayerAvatar_planCardUp.GetComponent<Image>().sprite = avatarPlanCardUp[GameManager.player_select];
                myPlayerAvatar_planCardDown.GetComponent<Image>().sprite = avatarPlanCardDown[GameManager.player_select];
                myPlayerAvatar_fire1.GetComponent<Image>().sprite = avatarFire1[GameManager.player_select];
                myPlayerAvatar_fire2.GetComponent<Image>().sprite = avatarFire2[GameManager.player_select];
                myPlayerAvatar_fire3.GetComponent<Image>().sprite = avatarFire3[GameManager.player_select];
                myPlayerAvatar_tae1.GetComponent<Image>().sprite = avatarTae1[GameManager.player_select];
                myPlayerAvatar_tae2.GetComponent<Image>().sprite = avatarTae2[GameManager.player_select];
                blackfade_out.SetActive (true);

                ChannelNum_txt.text = channelNum.ToString() + " 채널";

            break;
		}
	}

	void mainSet() {
		main_main.SetActive (true);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
