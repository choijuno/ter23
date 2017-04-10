using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]


public enum Skin
{
    none = 0,
    picket,
    planCard,
    fire,
    tae
}

public enum backGround_Image
{
    none = 0,
    _10,
    _20,
    _50
}


public class myInfo : MonoBehaviour {
    int myNum;

    public GameObject gameManager;
    public GameObject cha_avatar_none;
    public GameObject cha_avatar_picketup;
    public GameObject cha_avatar_picketdown;
    public GameObject cha_avatar_planCardup;
    public GameObject cha_avatar_planCarddown;
    public GameObject cha_avatar_fire1;
    public GameObject cha_avatar_fire2;
    public GameObject cha_avatar_fire3;
    public GameObject cha_avatar_tae1;
    public GameObject cha_avatar_tae2;

    public GameObject _1_p1;
    public GameObject _1_p2;
    public GameObject _2_p1;
    public GameObject _2_p2;
    public GameObject _3_p1;
    public GameObject _3_p2;


    public Skin mySkin;
    public backGround_Image myBackground;

    public float delay_skinAni;
    float delay_skinAni_in;
    bool skinUp;

    public float delay_skinAni_3;
    float delay_skinAni_in_3;
    int skinType;

    public float delay_backAni;
    float delay_backAni_in;
    bool backUp;

    public Text name_txt;
    public Text age_txt;
    public Text sex_txt;


    void Start()
    {
        if(gameObject.name == "myInfo_panel") {

            name_txt.text = GameManager.nameSave;
            age_txt.text = GameManager.ageSave;

            if(GameManager.sexSave == "1")
            {
                sex_txt.text = "남";
            }
            else
            {
                sex_txt.text = "여";
            }
            
        } else
        {
            name_txt.text = "TestBot";
            age_txt.text = "10";
            sex_txt.text = "성별";
        }

        myNum = GameManager.player_select;
        delay_skinAni_in = 0f;
        delay_skinAni_in_3 = 0f;

    }

    void Update()
    {
        //Debug.Log("skinTime : " + delay_skinAni_in_3);
        switch(mySkin)
        {
            case Skin.none:

                break;
            case Skin.picket:
                delay_skinAni_in = delay_skinAni_in - Time.deltaTime;
                
                if (delay_skinAni_in <= 0)
                {
                    if (skinUp)
                    {
                        skinUp = false;
                        cha_avatar_picketup.SetActive(false);
                        cha_avatar_picketdown.SetActive(true);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[myNum];
                    }
                    else
                    {
                        skinUp = true;
                        cha_avatar_picketup.SetActive(true);
                        cha_avatar_picketdown.SetActive(false);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[myNum];
                    }
                    delay_skinAni_in = delay_skinAni;
                }
                


                break;

            case Skin.planCard:
                delay_skinAni_in = delay_skinAni_in - Time.deltaTime;

                if (delay_skinAni_in <= 0)
                {
                    if (skinUp)
                    {
                        skinUp = false;
                        cha_avatar_planCardup.SetActive(false);
                        cha_avatar_planCarddown.SetActive(true);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[myNum];
                    }
                    else
                    {
                        skinUp = true;
                        cha_avatar_planCardup.SetActive(true);
                        cha_avatar_planCarddown.SetActive(false);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[myNum];
                    }
                    delay_skinAni_in = delay_skinAni;
                }

                break;

            case Skin.fire:
                delay_skinAni_in_3 = delay_skinAni_in_3 - Time.deltaTime;

                if (delay_skinAni_in_3 <= 0)
                {
                    if (skinType == 0)
                    {
                        skinType = 1;
                        cha_avatar_fire1.SetActive(true);
                        cha_avatar_fire2.SetActive(false);
                        cha_avatar_fire3.SetActive(false);
                    }
                    else if (skinType == 1)
                    {
                        skinType = 2;
                        cha_avatar_fire1.SetActive(false);
                        cha_avatar_fire2.SetActive(true);
                        cha_avatar_fire3.SetActive(false);
                    }
                    else if (skinType == 2)
                    {
                        skinType = 3;
                        cha_avatar_fire1.SetActive(false);
                        cha_avatar_fire2.SetActive(false);
                        cha_avatar_fire3.SetActive(true);
                    }
                    else if (skinType == 3)
                    {
                        skinType = 0;
                        cha_avatar_fire1.SetActive(false);
                        cha_avatar_fire2.SetActive(true);
                        cha_avatar_fire3.SetActive(false);
                    }
                    delay_skinAni_in_3 = delay_skinAni_3;
                }

                break;
            case Skin.tae:
                delay_skinAni_in = delay_skinAni_in - Time.deltaTime;

                if (delay_skinAni_in <= 0)
                {
                    if (skinUp)
                    {
                        skinUp = false;
                        cha_avatar_tae1.SetActive(false);
                        cha_avatar_tae2.SetActive(true);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[myNum];
                    }
                    else
                    {
                        skinUp = true;
                        cha_avatar_tae1.SetActive(true);
                        cha_avatar_tae2.SetActive(false);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[myNum];
                    }
                    delay_skinAni_in = delay_skinAni;
                }
                break;

        }
        /*
        switch(myBackground)
        {
            case backGround_Image.none:
                break;
            case backGround_Image._10:
                delay_backAni_in = delay_backAni_in - Time.deltaTime;

                if (delay_backAni_in <= 0)
                {
                    if (backUp)
                    {
                        backUp = false;
                        _1_p1.SetActive(false);
                        _1_p2.SetActive(true);
                        //cha_avatar_picketup.SetActive(false);
                        //cha_avatar_picketdown.SetActive(true);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[myNum];
                    }
                    else
                    {
                        backUp = true;
                        _1_p1.SetActive(true);
                        _1_p2.SetActive(false);
                        //cha_avatar_picketup.SetActive(true);
                        //cha_avatar_picketdown.SetActive(false);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[myNum];
                    }
                    delay_backAni_in = delay_backAni;
                }
                break;
            case backGround_Image._20:
                delay_backAni_in = delay_backAni_in - Time.deltaTime;
                if (delay_backAni_in <= 0)
                {
                    if (backUp)
                    {
                        backUp = false;
                        _2_p1.SetActive(false);
                        _2_p2.SetActive(true);
                        //cha_avatar_picketup.SetActive(false);
                        //cha_avatar_picketdown.SetActive(true);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[myNum];
                    }
                    else
                    {
                        backUp = true;
                        _2_p1.SetActive(true);
                        _2_p2.SetActive(false);
                        //cha_avatar_picketup.SetActive(true);
                        //cha_avatar_picketdown.SetActive(false);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[myNum];
                    }
                    delay_backAni_in = delay_backAni;
                }
                break;
            case backGround_Image._50:
                delay_backAni_in = delay_backAni_in - Time.deltaTime;
                if (delay_backAni_in <= 0)
                {
                    if (backUp)
                    {
                        backUp = false;
                        _3_p1.SetActive(false);
                        _3_p2.SetActive(true);
                        //cha_avatar_picketup.SetActive(false);
                        //cha_avatar_picketdown.SetActive(true);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketUp[myNum];
                    }
                    else
                    {
                        backUp = true;
                        _3_p1.SetActive(true);
                        _3_p2.SetActive(false);
                        //cha_avatar_picketup.SetActive(true);
                        //cha_avatar_picketdown.SetActive(false);
                        //cha_avatar.sprite = gameManager.GetComponent<GameManager>().avatarPicketDown[myNum];
                    }
                    delay_backAni_in = delay_backAni;
                }
                break;

        }*/


    }

    public void SetItem(int itemNum)
    {
        allShutdown();

        switch (itemNum)
        {
            case 0:
                mySkin = Skin.none;
                cha_avatar_none.SetActive(true);
                break;
            case 1:
                mySkin = Skin.picket;
                
                break;
            case 2:
                mySkin = Skin.planCard;

                break;
            case 3:
                mySkin = Skin.fire;

                break;
            case 4:
                mySkin = Skin.tae;

                break;

        }

        delay_skinAni_in = 0f;
        delay_skinAni_in_3 = 0f;
    }



    void allShutdown()
    {
        cha_avatar_none.SetActive(false);
        cha_avatar_picketdown.SetActive(false);
        cha_avatar_picketup.SetActive(false);
        cha_avatar_planCarddown.SetActive(false);
        cha_avatar_planCardup.SetActive(false);
        cha_avatar_fire1.SetActive(false);
        cha_avatar_fire2.SetActive(false);
        cha_avatar_fire3.SetActive(false);
        cha_avatar_tae1.SetActive(false);
        cha_avatar_tae2.SetActive(false);
    }





}
