using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class signCheckOn : MonoBehaviour {

    public https https;
    public Text t_age;
    public Text t_sex;

    
	
	void Update () {
        if (https.signCheck_r.mb_sex == "1")
        {
            t_sex.text = " 성별 : 남성";
        }
        else if (https.signCheck_r.mb_sex == "2")
        {
            t_sex.text = " 성별 : 여성";
        }
        else
        {
            t_sex.text = " 성별 ";
        }

        if (https.signCheck_r.mb_birth != "")
        {
            string tt = https.signCheck_r.mb_birth;

            string age = tt.Substring(0, 4);

            t_age.text = " 나이 : "+( System.DateTime.Now.Year - (int.Parse(age) +1));
        }
       
    }
}
