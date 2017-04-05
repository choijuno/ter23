using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class chatManager : MonoBehaviour {

	public string myName_sample;

	string myName;

	public string comName_sample;

	string comName;

	public string[] comChat_sample;

	public float comChat_delay_l;
	public float comChat_delay_h;

	string comInput;

	public Text myBoard_txt;
	public InputField myInput_txt;

	string myInput_s;



	public string[] output_s;


	public static int lineCount;
	public int lineLimit;

	public string channelNum;



	[Space]
	public bool botChatOn;



	void Start() {
		lineCount = 0;
		myName = myName_sample;

		if (botChatOn) {
			comName = comName_sample;
		}

		output_s = new string[lineLimit];

		if (botChatOn) {
			StartCoroutine ("testChat_bot");
		}
	}

	void Update() {
		//if (myInput_txt.text != "" && Input.GetKeyDown(KeyCode.)) {
			//send ();
		//}

	}


	public void send() {

		if (lineCount == 0) {
			output_s [lineCount] = myName + " : " + myInput_txt.text;
			myBoard_txt.text = output_s [lineCount] + "\n";
			myInput_txt.text = "";
			lineCount++;

		} else if (lineCount < lineLimit) {
			output_s [lineCount] = myName + " : " + myInput_txt.text;
			myBoard_txt.text = myBoard_txt.text + output_s [lineCount] + "\n";
			myInput_txt.text = "";
			lineCount++;			

		} else {
			myBoard_txt.text = "";
			for (int i = 0; i < lineLimit; i++){
				if (i != (lineLimit - 1)) {
					output_s [i] = output_s [i + 1];
					myBoard_txt.text = myBoard_txt.text + output_s [i] + "\n";
				} else {
					output_s [lineCount - 1] = myName + " : " + myInput_txt.text;
					myBoard_txt.text = myBoard_txt.text + output_s [lineCount - 1] + "\n";
				}
			}
			myInput_txt.text = "";
		}
	}

	public void getMessage(string inputName, string inputTxt) {

		comName = inputName;
		comInput = inputTxt;

		if (lineCount == 0) {
			output_s [lineCount] = comName + " : " + comInput;
			myBoard_txt.text = output_s [lineCount] + "\n";
			lineCount++;

		} else if (lineCount < lineLimit) {
			output_s [lineCount] = comName + " : " + comInput;
			myBoard_txt.text = myBoard_txt.text + output_s [lineCount] + "\n";
			lineCount++;			

		} else {
			myBoard_txt.text = "";
			for (int i = 0; i < lineLimit; i++){
				if (i != (lineLimit - 1)) {
					output_s [i] = output_s [i + 1];
					myBoard_txt.text = myBoard_txt.text + output_s [i] + "\n";
				} else {
					output_s [lineCount - 1] = comName + " : " + comInput;
					myBoard_txt.text = myBoard_txt.text + output_s [lineCount - 1] + "\n";
				}
			}
		}
	}

	public void chatJoin() {
		chatManager.lineCount = 0;
		myBoard_txt.text = "";

		output_s [lineCount] = channelNum + "채널에 입장하셨습니다.";
		myBoard_txt.text = output_s [lineCount] + "\n";

		lineCount++;
	}




	IEnumerator testChat_bot() {
		float waitTime;

		waitTime = Random.Range (1f, 3f);

		while (true) {
			
			waitTime = waitTime - Time.deltaTime;


			if (waitTime <= 0) {

				//comInput = comChat_sample[Random.Range (0, comChat_sample.Length)];
				getMessage (comName_sample, comChat_sample[Random.Range (0, comChat_sample.Length)]);

				waitTime = Random.Range (comChat_delay_l, comChat_delay_h);
			}




			yield return null;
		}
	}

}
