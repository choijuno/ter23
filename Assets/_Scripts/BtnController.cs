using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BtnController : MonoBehaviour {
    //https
    public GameObject https;

    //ingame
    public GameObject bot_testNum;
    public GameObject[] botImage;

    public GameObject send_window;
	public GameObject send_panel;
	public GameObject sendclose_panel;

    public GameObject myInfo;
	public InputField send_input_txt;
    public Text[] output_txt;

    public Text picketNum_txt;
    public Text plancardNum_txt;
    public Text fireNum_txt;
    public Text taeNum_txt;



    //main
    public GameObject wait_Panel;
    public GameObject open_panel;
	public GameObject open_panel2;
	public GameObject close_panel;
	public GameObject close_panel2;

	//_etc
	public GameObject gameManager;
	public GameObject menupanel;
	public GameObject backName;
	public GameObject myAni;
	public GameObject myAni_in;
	public GameObject myAni_out;

	//_0_login
	public InputField playerid_txt;
	public InputField playerpass_txt;

    //_0_1_phoneCheck
    public InputField phoneNum_Check;
    public InputField CheckNum_Check;

    //_1_cha
    public GameObject falseMenu;
	public GameObject trueMenu;
	public GameObject selectPoint;
	public GameObject[] slot_none = new GameObject[3];
	public GameObject[] slot_avatar = new GameObject[3];
	public GameObject[] slot_stat = new GameObject[3];

    public Text myTxt;
    public Text testTxt;

    //_2_room
    public Text[] roomInfo;
    public InputField roomInput;
    public Text roomOut;
    public Text[] channelInfo;


    //_4_channel
    public GameObject webviewObj;
	public Text channelNum_txt;
	public GameObject chat_back;
	public InputField myInput;



	public void _0_login() {

		GameManager.player_id = playerid_txt.text;
		GameManager.player_pass = playerpass_txt.text;
        https.GetComponent<https>().logindata_r.id = playerid_txt.text;
        https.GetComponent<https>().logindata_r.pass = playerpass_txt.text;

        https.GetComponent<https>().SendMessage("Login");
        //코드 200,100밖에 없어서 아이디 비밀번호 오류 구분 불가.
        wait_Panel.SetActive(true);
        Invoke("_0_login_wait", 2f);

		
	}
    public void _0_login_wait()
    {
        wait_Panel.SetActive(false);
        Debug.Log(https.GetComponent<https>().login_r.code);
        if (https.GetComponent<https>().login_r.code == "100")
        {

            //open_panel.SetActive (true);
            open_panel2.SetActive(true);
            //close_panel.SetActive (false);



            myAni.GetComponent<Animator>().SetTrigger("up");
            myAni_out.GetComponent<Animator>().SetTrigger("out");

        }
    }


    public void _0_login_signup()
    {
        open_panel.SetActive(true);

    }

    public void _0_login_sendSms()
    {
        if(phoneNum_Check.text.Length >= 11)
        {
            this.gameObject.SetActive(false);
            Invoke("_0_login_sendSms_reset",10f);
            https.GetComponent<https>().SendMessage("Login_Sms", phoneNum_Check.text);

        }


    }

    void _0_login_sendSms_reset()
    {
        this.gameObject.SetActive(true);
    }

    public void _0_login_phoneCheck()
    {
        if (CheckNum_Check.text != "")
        {

            if (https.GetComponent<https>().smsCheck.cert_code == CheckNum_Check.text)
            {
                open_panel.SetActive(true);
            }

        }


    }

    public void _0_login_signup_gender()
    {
        if(GameManager.genderCheck == 0)
        {
            GameManager.genderCheck = 1;

            open_panel.SetActive(true);
            close_panel.SetActive(false);

            Debug.Log("여자");

        } else
        {
            GameManager.genderCheck = 0;

            open_panel2.SetActive(true);
            close_panel2.SetActive(false);
            Debug.Log("남자");
        }

        
    }
    
    public void _0_login_signup_finish()
    {
        //if
        close_panel.SetActive(false);
        close_panel2.SetActive(false);

    }



    public void _1_cha_slot_btn() {
        GameManager.player_select = int.Parse(gameObject.transform.parent.name.Substring(4, 2)) - 1;
        testTxt.text = myTxt.text;

        /*switch (gameObject.transform.parent.name.Substring(4,2)) {
		case "01":
			GameManager.player_select = 0;
			selectPoint.GetComponent<selectSwipe> ().slotPoint = 0;
			if (GameManager.player_char_have [0]) {
				falseMenu.SetActive (false);
				trueMenu.SetActive (true);
			} else {
				trueMenu.SetActive (false);
				falseMenu.SetActive (true);
			}

			break;
		case "02":
			GameManager.player_select = 1;
			selectPoint.GetComponent<selectSwipe> ().slotPoint = 1;
			if (GameManager.player_char_have [1]) {
				falseMenu.SetActive (false);
				trueMenu.SetActive (true);
			} else {
				trueMenu.SetActive (false);
				falseMenu.SetActive (true);
			}

			break;
		case "03":
			GameManager.player_select = 2;
			selectPoint.GetComponent<selectSwipe> ().slotPoint = 2;
			if (GameManager.player_char_have [2]) {
				falseMenu.SetActive (false);
				trueMenu.SetActive (true);
			} else {
				trueMenu.SetActive (false);
				falseMenu.SetActive (true);
			}

			break;
		}*/
    }

	public void _1_cha_create() {
		switch (GameManager.player_select) {
		case 0:
			if (gameManager.GetComponent<GameManager> ().testVer) {
				PlayerPrefs.SetInt ("slot_1_have", 1);
				GameManager.player_char_have [0] = true;
				//GameManager.player_char_job [0] = 1;
				//GameManager.player_char_level [0] = 1;
				slot_none [0].SetActive (false);
				slot_avatar [0].SetActive (true);
				slot_stat [0].SetActive (true);
				falseMenu.SetActive (false);
				trueMenu.SetActive (true);
			}
			break;
		case 1:
			if (gameManager.GetComponent<GameManager> ().testVer) {
				PlayerPrefs.SetInt ("slot_2_have", 1);
				GameManager.player_char_have [1] = true;
				slot_none [1].SetActive (false);
				slot_avatar [1].SetActive (true);
				slot_stat [1].SetActive (true);
				falseMenu.SetActive (false);
				trueMenu.SetActive (true);
			}
			break;
		case 2:
			if (gameManager.GetComponent<GameManager> ().testVer) {
				PlayerPrefs.SetInt ("slot_3_have", 1);
				GameManager.player_char_have [2] = true;
				slot_none [2].SetActive (false);
				slot_avatar [2].SetActive (true);
				slot_stat [2].SetActive (true);
				falseMenu.SetActive (false);
				trueMenu.SetActive (true);
			}
			break;
		}
	}
		
	public void _1_cha_select() {

		if (myAni_in.activeInHierarchy) {
			myAni_in.GetComponent<Animator> ().SetTrigger ("in");
		}

		open_panel.SetActive (true);

		myAni_out.GetComponent<Animator> ().SetTrigger ("out");



		switch (GameManager.player_select) {
		case 0:

			break;
		case 1:

			break;
		case 2:

			break;
		}
	}
		
	public void _1_cha_delete() {
		switch (GameManager.player_select) {
		case 0:
			if (gameManager.GetComponent<GameManager> ().testVer) {
				//PlayerPrefs.DeleteKey("slot_1_have");
				GameManager.player_char_have [0] = false;
				slot_none [0].SetActive (true);
				//slot_avatar [0].SetActive (false);
				//slot_stat [0].SetActive (false);
				falseMenu.SetActive (true);
				trueMenu.SetActive (false);
			}
			break;
		case 1:
			if (gameManager.GetComponent<GameManager> ().testVer) {
				//PlayerPrefs.DeleteKey("slot_2_have");
				GameManager.player_char_have [1] = false;
				slot_none [1].SetActive (true);
				//slot_avatar [1].SetActive (false);
				//slot_stat [1].SetActive (false);
				falseMenu.SetActive (true);
				trueMenu.SetActive (false);
			}
			break;
		case 2:
			if (gameManager.GetComponent<GameManager> ().testVer) {
				//PlayerPrefs.DeleteKey("slot_3_have");
				GameManager.player_char_have [2] = false;
				slot_none [2].SetActive (true);
				//slot_avatar [2].SetActive (false);
				//slot_stat [2].SetActive (false);
				falseMenu.SetActive (true);
				trueMenu.SetActive (false);
			}
			break;
		}
	}

	public void _2_room_join() {
		myAni_out.GetComponent<Animator> ().SetTrigger ("out");
		myAni_in.GetComponent<Animator> ().SetTrigger ("in");
		open_panel.SetActive (true);

	}

    public void _2_room_create()
    {
        //myAni_out.GetComponent<Animator>().SetTrigger("out");
        //myAni_in.GetComponent<Animator>().SetTrigger("in");
        open_panel.SetActive(true);

    }

    public void _2_room_create_done()
    {
        if (roomInput.text != "") {
            roomInfo[0].text = "진행중인 집회";
            roomInfo[1].text = "주최자 : player" + GameManager.player_id;
            channelInfo[0].text = roomInput.text;
            channelInfo[1].text = "주최 : player \n 일정: 01 / 11 18:00~24:00";

            Debug.Log(GameManager.player_id);
            roomOut.text = roomInput.text;
            close_panel.SetActive(false);
            roomInput.text = "";


            roomOut.transform.parent.gameObject.GetComponent<Button>().enabled = true;
        }
    }

    public void _2_room_create_cancel()
    {
        //myAni_out.GetComponent<Animator>().SetTrigger("out");
        //myAni_in.GetComponent<Animator>().SetTrigger("in");
        roomInput.text = "";
        close_panel.SetActive(false);

    }

    public void _3_channel_join() {
        GameManager.channelNum = int.Parse(gameObject.name.Substring(8, 2));

        myAni_out.GetComponent<Animator> ().SetTrigger ("out");
		myAni_in.GetComponent<Animator> ().SetTrigger ("in");
		open_panel.SetActive (true);
		channelNum_txt.text = gameObject.name.Substring (8, 2) + " 채널";

		chat_back.GetComponent<chatManager> ().channelNum = gameObject.name.Substring (8, 1);
		chat_back.GetComponent<chatManager> ().Invoke("chatJoin",0.2f);

        //new
        webviewObj.GetComponent<WebViewScript>().StartWebView();

    }


	//_4
	public void _4_lobby_send(){
		if (myInput.text != "") {
			chat_back.GetComponent<chatManager> ().SendMessage ("send");
		}
	}

	public void _4_lobby_back() {

        WebViewScript.destroyCheck = true;
		myAni_out.GetComponent<Animator> ().SetTrigger ("out");
		myAni_in.GetComponent<Animator> ().SetTrigger ("in");

	}

	public void _4_lobby_ingame() {

		Application.LoadLevel ("1.Game");

	}

    public void _4_lobby_menuBtn()
    {
        this.GetComponent<Button>().enabled = false;
        open_panel.SetActive(true);
        open_panel2.SetActive(true);
        myAni_in.GetComponent<Animator>().SetTrigger("in");
        myAni_out.GetComponent<Animator>().SetTrigger("in");
    }

    public void _4_lobby_menuBackBtn()
    {
        open_panel.GetComponent<Button>().enabled = true;
        close_panel.SetActive(false);
        close_panel2.SetActive(false);
        myAni_out.GetComponent<Animator>().SetTrigger("out");
        myAni_in.GetComponent<Animator>().SetTrigger("out");

    }





    public void _0_openClose() {
		open_panel.SetActive (true);
		close_panel.SetActive (false);
	}

	public void _0_create() {
		open_panel.SetActive (true);
		open_panel2.SetActive (true);
		close_panel.SetActive (false);
	}

	public void _0_delete() {
		close_panel.SetActive (false);
		close_panel2.SetActive (false);
		open_panel.SetActive (true);
	}

	public void _0_room() {
		Application.LoadLevel ("1.testGame");

	}

	public void sendTalk() {
		GameManager.talkCheck = true;

		send_window.transform.localPosition = new Vector3 (transform.localPosition.x + 55f, transform.localPosition.y + 30f, transform.localPosition.z);
		send_panel.SetActive (true);

		Debug.Log ("send_talk!");
	}

	public void _1_send() {
        sendclose_panel.SetActive(false);
        send_panel.SetActive(true);
        close_panel.SetActive(false);
    }

	public void _1_sendclose() {

		GameManager.talkCheck = false;
		sendclose_panel.SetActive (false);

	}

	public void _1_sendFinish() {

		send_input_txt.text = "";
		GameManager.talkCheck = false;
		sendclose_panel.SetActive (false);
		send_panel.SetActive (true);
		close_panel.SetActive (false);

    }

	public void _1_sendFinishclose() {
		send_input_txt.text = "";
		GameManager.talkCheck = false;
		sendclose_panel.SetActive (false);
		send_panel.SetActive (true);
		close_panel.SetActive (false);
	}

    public void _ingame_lobbyBtn()
    {
        Application.LoadLevel("0.Main");

    }

    public void _ingame_itemBtn()
    {
        open_panel.SetActive(true);
        picketNum_txt.text = "X " + GameManager.picketNum;
        plancardNum_txt.text = "X " + GameManager.plancardNum;
        fireNum_txt.text = "X " + GameManager.fireNum;
        taeNum_txt.text = "X " + GameManager.taeNum;
    }

    public void _ingame_useBtn()
    {
        open_panel.SetActive(true);
    }

    public void _ingame_usePicketBtn()
    {
        if (GameManager.picketNum > 0)
        {
            open_panel.SetActive(true);
        }
        else
        {
            open_panel2.SetActive(true);
        }
    }
    public void _ingame_usePlanCardBtn()
    {
        if (GameManager.plancardNum > 0)
        {
            open_panel.SetActive(true);
        }
        else
        {
            open_panel2.SetActive(true);
        }
    }
    public void _ingame_useFireBtn()
    {
        if (GameManager.fireNum > 0)
        {
            open_panel.SetActive(true);
        }
        else
        {
            open_panel2.SetActive(true);
        }
    }
    public void _ingame_useTaeBtn()
    {
        if (GameManager.taeNum > 0)
        {
            open_panel.SetActive(true);
        }
        else
        {
            open_panel2.SetActive(true);
        }
    }

    public void _ingame_usePicket()
    {
        
            _ingame_myTalkBtn();
            GameManager.picketNum--;
            myInfo.GetComponent<myInfo>().SetItem(1);
    }

    public void _ingame_usePlanCard()
    {
            _ingame_myTalkBtn();
            GameManager.plancardNum--;
            myInfo.GetComponent<myInfo>().SetItem(2);
    }

    public void _ingame_useFire()
    {
            GameManager.fireNum--;
            myInfo.GetComponent<myInfo>().SetItem(3);
            close_panel.SetActive(false);
            close_panel2.SetActive(false);
    }

    public void _ingame_useTae()
    {
            GameManager.taeNum--;
            myInfo.GetComponent<myInfo>().SetItem(4);
            close_panel.SetActive(false);
            close_panel2.SetActive(false);
    }

    public void _ingame_useItem_cancel()
    {
        send_input_txt.text = "";
        close_panel.SetActive(false);
    }

    public void _ingame_useItem_cancel_just()
    {
        close_panel.SetActive(false);
    }

    public void _ingame_myTalkBtn()
    {
        for (int i = 0; i < output_txt.Length; i++) {
            output_txt[i].text = send_input_txt.text;
        }
        send_input_txt.text = "";
        close_panel.SetActive(false);
        close_panel2.SetActive(false);
    }

    public void _ingame_itemExitBtn()
    {
        close_panel.SetActive(false);
    }

    public void _ingame_notice()
    {
        if(!GameManager.talkCheck)
        {
            GameManager.talkCheck = true;
            open_panel.SetActive(true);

        }
    }

    public void _ingame_menu()
    {

    }

    public void _ingame_shop_btn()
    {
        if (!GameManager.talkCheck)
        {
            GameManager.talkCheck = true;
            open_panel.SetActive(true);
        }

    }

    public void _ingame_shop_picket()
    {
        open_panel.SetActive(true);

    }
    public void _ingame_shop_picket_buy() //피켓 인앱
    {
        close_panel.SetActive(false);
        GameManager.picketNum++;
        GameManager.playerXp = GameManager.playerXp - 10;
    }

    public void _ingame_shop_planCard() 
    {
        open_panel.SetActive(true);

    }
    public void _ingame_shop_planCard_buy() //플랜카드 인앱
    {
        close_panel.SetActive(false);
        GameManager.plancardNum++;
        GameManager.playerXp = GameManager.playerXp - 20;
    }

    public void _ingame_shop_fire() 
    {
        open_panel.SetActive(true);
    }
    public void _ingame_shop_fire_buy() //불 인앱
    {
        close_panel.SetActive(false);
        GameManager.fireNum++;
        GameManager.playerXp = GameManager.playerXp - 40;
    }

    public void _ingame_shop_tae()
    {
        open_panel.SetActive(true);
    }
    public void _ingame_shop_tae_buy() // 태극기 인앱
    {
        close_panel.SetActive(false);
        GameManager.taeNum++;
        GameManager.playerXp = GameManager.playerXp - 40;
    }

    public void _ingame_shop_buy_cancel()
    {
        close_panel.SetActive(false);
    }

    public void _ingame_shop_close_btn()
    {
        GameManager.talkCheck = false;
        close_panel.SetActive(false);
    }

    public void _ingame_tv_btn()
    {
        GameManager.talkCheck = true;
        open_panel.SetActive(true);
        webviewObj.GetComponent<WebViewScript>().StartWebView();
    }

    public void _ingame_tv_closebtn()
    {
        WebViewScript.destroyCheck = true;
        GameManager.talkCheck = false;
        close_panel.SetActive(false);
    }


    public void _ingame_notice_close()
    {

        GameManager.talkCheck = false;
        close_panel.SetActive(false);

    }

    public void sendTalk_test()
    {
        if (!GameManager.talkCheck)
        {
            GameManager.talkCheck = true;

            //send_window.transform.localPosition = new Vector3(transform.localPosition.x + 55f, transform.localPosition.y + 30f, transform.localPosition.z);
            send_panel.SetActive(true);


            botImage[0].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarFace[GetComponent<botTestNum>().bot_testNum];
            botImage[1].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[GetComponent<botTestNum>().bot_testNum];
            botImage[2].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[GetComponent<botTestNum>().bot_testNum];
            botImage[3].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarPlanCardUp[GetComponent<botTestNum>().bot_testNum];
            botImage[4].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarPlanCardDown[GetComponent<botTestNum>().bot_testNum];
            botImage[5].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarFire1[GetComponent<botTestNum>().bot_testNum];
            botImage[6].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarFire2[GetComponent<botTestNum>().bot_testNum];
            botImage[7].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarFire3[GetComponent<botTestNum>().bot_testNum];
            botImage[8].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarTae1[GetComponent<botTestNum>().bot_testNum];
            botImage[9].GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarTae2[GetComponent<botTestNum>().bot_testNum];



            switch (GetComponent<botTestNum>().botTestStat)
            {
                case botTestNum.botStat.none:

                    myInfo.GetComponent<myInfo>().SetItem(0);
                    break;
                case botTestNum.botStat.picket:

                    myInfo.GetComponent<myInfo>().SetItem(1);
                    break;
                case botTestNum.botStat.card:

                    myInfo.GetComponent<myInfo>().SetItem(2);
                    break;
                case botTestNum.botStat.fire:

                    myInfo.GetComponent<myInfo>().SetItem(3);
                    break;
                case botTestNum.botStat.tae:

                    myInfo.GetComponent<myInfo>().SetItem(4);
                    break;
            }


            Debug.Log("send_talk!");
        }
    }
}