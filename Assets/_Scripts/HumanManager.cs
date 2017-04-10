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
            human2[i].gameObject.SetActive(true);

            human2[i].GetComponent<Image>().sprite = gameManager.avatarImage[icon[i]];
            human2[i].gameObject.GetComponentInChildren<Text>().text = id[i];
            int avatar = 0;
        }
    }
}
