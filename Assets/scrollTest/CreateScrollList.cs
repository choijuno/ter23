using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class item
{

    public string name;
    public string score;
    public Sprite face;
    public bool isChampion;
    public Button.ButtonClickedEvent thingToDo;

}




public class CreateScrollList : MonoBehaviour {

    public GameObject sampleButton;
    public Transform contentPanel;
    public List<item> itemList;

    void Start()
    {

        PopulateList();

    }
    

    void PopulateList()
    {

        foreach(var item in itemList)
        {

            GameObject newButton = Instantiate(sampleButton) as GameObject;

            SampleButtonScript buttonScript = newButton.GetComponent<SampleButtonScript>();

            buttonScript.nameLabel.text = item.name;
            buttonScript.scoreLabel.text = item.score;
            buttonScript.faceImage.sprite = item.face;
            buttonScript.starImage.SetActive(item.isChampion);

            buttonScript.button.onClick = item.thingToDo;

            newButton.transform.SetParent(contentPanel);

        }

    }


    public void DoSomething()
    {

        Debug.Log("Something");

    }

}
