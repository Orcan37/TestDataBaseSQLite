using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerSQLitem : MonoBehaviour
{
    [HideInInspector] public GameObject GO;
    public ManagerSQLitem managerSQLitem;
    public Button[] but;
    //public Button[] butALL;
    public GameObject bigItem;
    public GameObject[] AlliconItem;
    public TMP_Text TitleItemName;
    // public TMP_Text myNameItem;
    public TMP_InputField myNameItem;


    [Header("Database string")]
    // public string NameAccaunt;
    public string ID;
    public string Name; // имя индивидуальное 
    public string NameEdit;
    public string MyNameEdit;
    public string Discription;
    public string Level;
    public string Status;
    //  public string test;  // рабочий был
    //  public Dictionary<string, string> monstersD = new Dictionary<string, string>();
    [Header("Database TABLE")]
    public string nameTableSQL = "monsters";
    public string ItemCurentUse;

    public string CurrentEvent = "CurrentItem";
    public List<ItemСharacteristic> itemСharacteristic = new List<ItemСharacteristic>();

    void Start()
    {
        GO = this.gameObject;
        managerSQLitem = this;
        for (int i = 0; i < but.Length; i++)
        {
//            but[i].GetComponent<InfoItemBut>().managerSQLitem = this; /// иконки 
        }
        //inStart();
        Invoke("inStart", 1f); //  написать почему  1 секунда а не меньше 
    }


    public virtual void inStart()
    {

    }


    //public virtual void TEST()  // рабочий
    //{ //}



    public virtual void butMassage(string nameInfo, Sprite sprite = null) // иземенения иконки БИГ БУТОН
    {
        MS.DB.PullValuesItem(nameInfo, GO);
        Name = nameInfo;

        bigItem.transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprite;


        PullValuesItem();  // срабатывает только для  и вызывает Шаблон выбраного
    }


    public virtual void SaveButMassage(string nameInfo, Sprite sprite = null) // иземенения иконки 
    {
        //    MS.DB.PullValuesItem(nameInfo, GO); // вот это при --лоад Не должно-- срабатывать  но при --useItemBut--- должен
        //    Name = nameInfo;  /// тоесть имя иконки он должен брать из фунгус Потом проверять SaveButMassage
        for (int i = 0; i < AlliconItem.Length; i++)
        {
            AlliconItem[i].transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprite;
        }

        bigItem.transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprite;
        PullValuesItem();
        //    UseSaveItemBut();  // срабатывает
    }


    public virtual void UseSaveItemBut()  // когда меняешь имяСвое  в поле то должно оно передаться в таблицу  и не нужно в дочернем ничего делать 
    {
    }

    public virtual void PullValuesItem()   // когда меняешь имяСвое  в поле то должно оно передаться в таблицу  и не нужно в дочернем ничего делать 
    {
    }




    public virtual void MyItemNameEndField()   // когда меняешь имяСвое  в поле то должно оно передаться в таблицу  и не нужно в дочернем ничего делать 
    {
    }



}
[System.Serializable]
public class ItemСharacteristic
{
    [SerializeField] public string InfoName;
    [SerializeField] public Sprite spriteBut;

}