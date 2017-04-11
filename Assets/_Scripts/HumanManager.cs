using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HumanManager : MonoBehaviour
{

    public Button[] human;
    public Button[] human2;

    public List<string> humanId = new List<string>();
    Dictionary<string, int> humanKey = new Dictionary<string, int>();

    GameManager gameManager;

	public GameObject clickscript;
    
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void HumanEnter(int userCount,string[] id,int[] icon) //최대 20명
    {
        for (int i = 0; i < userCount; i++)
        {
            human[i].gameObject.SetActive(true);

            human[i].GetComponent<Image>().sprite = gameManager.avatarImage[icon[i]];
            human[i].gameObject.GetComponentInChildren<Text>().text = id[i];
            int avatar = 0;
        }
    }

    public void HumanEnter2(int userCount, string[] id, int[] icon) //최대 20명
    {
        for (int i = 0; i < userCount; i++)
        {

			//clickscript.GetComponent<BtnController>().clickname_txt;
			//clickscript.GetComponent<BtnController>().clicknum_int;
			if(id[i] == clickscript.GetComponent<BtnController>().clickname_txt)
			{
				id[i] = GameManager.idSave;

				  human2[i].gameObject.SetActive(true);

				 human2[i].GetComponent<Image>().sprite = gameManager.avatarImage[int.Parse(GameManager.iconSave)];
					human2[i].gameObject.GetComponentInChildren<Text>().text = id[i];
			}
			else
			{
				  human2[i].gameObject.SetActive(true);

					human2[i].GetComponent<Image>().sprite = gameManager.avatarImage[icon[i]];
					human2[i].gameObject.GetComponentInChildren<Text>().text = id[i];
			}
			

          
            int avatar = 0;
        }
    }
}
