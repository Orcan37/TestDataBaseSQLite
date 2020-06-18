using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQLbutn : MonoBehaviour
{ 
    public string nameB = "NEW";
    public string test1 = "0";
    public string test2 = "0";
    public Text text1txt;
    public Text text2txt;
    public InputField inputFieldtext1;
    public InputField inputFieldtext2;


    void Start()
    {
        MS.sqlButn = this;
        MS.DB.CreatTable();
    }


    public void Pulltest() // loadBtn
    {
    
        MS.DB.PullTest(nameB, this.gameObject);
         

        text1txt.text = test1;
        text2txt.text = test2;

    }


    public void Pushtest()  // saveBtn
    {
        test1 = inputFieldtext1.text;
        test2 = inputFieldtext2.text;

        MS.DB.PushTest(nameB, this.gameObject);

     
    }

}
