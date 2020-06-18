using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemManager : ManagerSQLitem
{   // все сценария и загрузками манипулирует фунгус
    [Header("ItemManager")]
    //public Image NoneItem; // какой будет иконка если не будет поставлено оружие
    public TMP_InputField nameTask;
    public string[] Events = { "sleep", "cofee", "run", "music", "say", };
    public string[] curEvents = { "sleepCur", "cofeeCur", "runCur", "musicCur", "sayCur", };
    public GameObject SpawnerTask;
    public GameObject TaskPref;
    Vector3 ScalePrefabTask = new Vector3(1.5f, 1.5f, 1.5f);
    public string TaskCurentEdit;
    public GameObject WinLoseTask;

    [Header("CurrentItemGenerator")]
    public GameObject SpawnerCurTask;
    
    //public override void inStart() // тут должен быть полностью контролироваться из Фунгус
    //{


    //    MS.itemManager = this;
    //    //   MM.Instance.itemManager = this;
    //    //  OpenItem(); //  
    //    //  UseSaveItem(); // 
    //}

    //public void RewriteItem() // перезаписываем в Куррент всю что у нас есть 
    //{
    //    MS.DB.PushValuesItem(Name, GO);
    //}
    //public void RewriteCurItem() // перезаписываем в Куррент всю что у нас есть 
    //{

    //    for (int i = 0; i < curEvents.Length; i++)
    //    {
    //        curEvents[i] = Events[i];
    //    }
    //    MS.DB.PushValuesItem(CurrentEvent, GO);
    //}


    //public void DestoyAllCurent()
    //{
    //    for (int i = 0; i < curEvents.Length; i++)
    //    {
    //        curEvents[i] = "-2000";
    //    }
    //    MS.DB.PushValuesItem(CurrentEvent, GO);
    //    // LoadCurrentItem();
    //    foreach (Transform child in SpawnerCurTask.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //}


    //public override void MyItemNameEndField() /// когда изменил поле МАЙНЕЙМ
    //{

    //    if (MyNameEdit != myNameItem.text)
    //    {
    //        MyNameEdit = myNameItem.text;
    //        MS.DB.PushValuesItem(Name, GO);
    //    }

    //}



    //public void EditClickFieldEnd() /// когда изменил поле ТАСК
    //{

    //    int ID = int.Parse(TaskCurentEdit);

    //    if (Events[ID] != nameTask.text) // если поля не равны друг друга то ничего менять не надо
    //    {
    //        Events[ID] = nameTask.text;

    //        MS.DB.PushValuesItem(Name, GO);
    //        SpawnAllTask();
    //    }

    //}



    //public void cancelPanelItembut()
    //{
    //    // откатить все настройки к старому  
    //    MS.DB.PullValuesItem(CurrentEvent, GO);  // откатить все 

    //}
    //public void ChangeItem()
    //{
    //    string s = MS.flowchartMain.GetStringVariable("UseItem");
    //    if (s != "none" && s != "") { ItemCurentUse = s; }
    //    OpenItem();
    //}

    //// Тут чисто переключается БИГ Иконка и вызывает потом СОздания ШАБЛОНОВ этого оружия
    //public void OpenItem()
    //{
    //    // какую либо кнопку нажать из 
    //    for (int i = 0; i < but.Length; i++)
    //    {
    //        if (but[i].GetComponent<InfoItemBut>().InfoName == ItemCurentUse)
    //        {
    //            but[i].GetComponent<InfoItemBut>().TaskOnClick(); // PullValuesItem() метод вызывает в конце

    //        }
    //    }

    //}

    ///// <summary>
    ///// Ставим нужные Иконки без вызовов метода 
    ///// </summary>
    //// 
    //public void LoadCurentItemBut() // тоесть просто должно поменяться в зависимости Названия Переменной 
    //{
    //    // какую либо кнопку нажать из 
    //    for (int i = 0; i < but.Length; i++)
    //    {
    //        if (but[i].GetComponent<InfoItemBut>().InfoName == ItemCurentUse)
    //        {
    //            but[i].GetComponent<InfoItemBut>().LoadCurentItemBut(); // отображает чисто Иконки методы не вызывает
    //            MS.flowchartMain.SetStringVariable("UseItem", ItemCurentUse);  // ставим из Нашего в Фунгус Скрипта Текущий Итем 
    //        }
    //    }

    //}


    //public override void SaveButMassage(string nameInfo, Sprite sprite = null) // иземенения иконки 
    //{
    //    MS.DB.PullValuesItem(nameInfo, GO); // вот это при --лоад Не должно-- срабатывать  но при --useItemBut--- должен
    //    Name = nameInfo;  /// тоесть имя иконки он должен брать из фунгус Потом проверять SaveButMassage

    //    base.SaveButMassage(nameInfo, sprite);
    //    //    UseSaveItemBut();  // срабатывает
    //}

    ////public void UseLoadItemFungus()
    ////{
    ////    ItemCurentUse =  MS.flowchartMain.GetStringVariable("UseItem");

    ////}

    //public void LoadCurrentItem()// отобразить CurrentItem лтличается тем что когда фунгус Отображает сразу Из базы данных Итем Курент
    //{
    //    // поставить Сурент в 
    //    // if (Name != "CurrentItem") { ItemCurentUse = Name; MS.flowchartMain.SetStringVariable("UseItem", ItemCurentUse); } // ставим из Нашего в Фунгус Скрипта Текущий Итем 
    //    // Debug.Log("LoadCurrentItem");

    //    //   MS.DB.PushValuesItem(Name, GO);
    //    MS.DB.PullValuesItem(CurrentEvent, GO);
    //    bool bWinLoseTask = false; // когда больше 1 таска есть Появится ТАСк ВИН 
    //    foreach (Transform child in SpawnerCurTask.transform)
    //    {
    //        if (child.gameObject.GetComponent<WinLoseKMM>() != null)
    //        {
    //            bWinLoseTask = true;
    //            //  Debug.Log("LoadCurrentItemLoadCurrentItemLoadCurrentItemLoadCurrentItem");
    //        }
    //        Destroy(child.gameObject);
    //    } 

    //    for (int i = 0; i < Events.Length; i++)
    //    {
    //        if (curEvents[i] != "-2000" && curEvents[i] != "-1000")
    //        {  // -2000 сделано или нету  -1000 = нету не куплино
               
    //            GameObject clone = Instantiate(TaskPref, transform.position, transform.rotation);
    //            clone.transform.SetParent(SpawnerCurTask.transform);
    //            TaskSQLKMM taksClone = clone.GetComponent<TaskSQLKMM>();
    //            taksClone.txtID.text = (i).ToString();
    //            taksClone.txtTitle.text = curEvents[i];
    //            taksClone.panelItem = this;
    //            taksClone.thisButComplate.interactable = true;

    //            clone.transform.localScale = new Vector3(ScalePrefabTask.x, ScalePrefabTask.y, ScalePrefabTask.z);
    //            // Invoke("SizeCLon", 0.1f);
    //            bWinLoseTask = true;
    //        }

    //        nameTask.interactable = false;
    //    }

    //    if (bWinLoseTask)
    //    {
    //        GameObject clone = Instantiate(WinLoseTask, transform.position, transform.rotation);
    //        clone.transform.SetParent(SpawnerCurTask.transform);
    //        clone.transform.localScale = new Vector3(ScalePrefabTask.x, ScalePrefabTask.y, ScalePrefabTask.z);
    //    }

    //    ItemCurentUse = MS.flowchartMain.GetStringVariable("UseItem");

    

    //    LoadCurentItemBut();// ставим нужные иконки

    //}


    //public void PushValuesItemComplate() // пользуется когда нужно закинуть результат в SQL после того как Миссию выполнили
    //{

    //    MS.DB.PushValuesItem(Name, GO);

    //}


    //public override void UseSaveItemBut()  //
    //{
    //    // поставить Сурент в 
    //    ItemCurentUse = Name;
    //    MS.flowchartMain.SetStringVariable("UseItem", ItemCurentUse);  // ставим из Нашего в Фунгус Скрипта Текущий Итем 

    //    MS.DB.PushValuesItem(CurrentEvent, GO);  // перезаписываем в CurrentEvent все текущего шаблона Штучки
    //    bool bWinLoseTask = false; // когда больше 1 таска есть Появится ТАСк ВИН 
    //    foreach (Transform child in SpawnerCurTask.transform)
    //    {
    //        if (child.gameObject.GetComponent<WinLoseKMM>() != null) { bWinLoseTask = true; } // оставить WIn LOse если его не использовали
    //        Destroy(child.gameObject);
    //    }

    //    for (int i = 0; i < Events.Length; i++)   /// вызываем все из CurrentEvent
    //    {
    //        if (Events[i] != "-2000" && Events[i] != "-1000")
    //        {  // -2000 сделано или нету  -1000 = нету не куплино
    //            GameObject clone = Instantiate(TaskPref, transform.position, transform.rotation);
    //            clone.transform.SetParent(SpawnerCurTask.transform);
    //            TaskSQLKMM taksClone = clone.GetComponent<TaskSQLKMM>();
    //            taksClone.txtID.text = (i).ToString();
    //            taksClone.txtTitle.text = Events[i];
    //            taksClone.panelItem = this;
    //            taksClone.thisButComplate.interactable = true;

    //            clone.transform.localScale = new Vector3(ScalePrefabTask.x, ScalePrefabTask.y, ScalePrefabTask.z);
    //            // Invoke("SizeCLon", 0.1f);
    //            bWinLoseTask = true;
    //        }
    //        nameTask.interactable = false;
    //    }

    //    if (bWinLoseTask)
    //    {
    //        GameObject clone = Instantiate(WinLoseTask, transform.position, transform.rotation);
    //        clone.transform.SetParent(SpawnerCurTask.transform);
    //        clone.transform.localScale = new Vector3(ScalePrefabTask.x, ScalePrefabTask.y, ScalePrefabTask.z);
    //    }

    //}







    //public override void PullValuesItem()   // чисто заполнение полей которые зависят от Инвентаря
    //{
    //    TitleItemName.text = NameEdit;
    //    // public TMP_Text myNameItem;
    //    myNameItem.text = MyNameEdit;
    //    nameTask.text = Events[1];
    //    ItemCurentUse = Name;
    //    SpawnAllTask();
    //    //  LoadCurrentItem();
    //}



    //public void SpawnAllTask() /// сдесь чисто показывают шаблоны 
    //{
    //    // clear  все предыдущие таски
    //    foreach (Transform child in SpawnerTask.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //    bool bWinLoseTask = false; // когда больше 1 таска есть Появится ТАСк ВИН 
    //    for (int i = 0; i < Events.Length; i++)
    //    {
    //        if (Events[i] != "-1000")
    //        {  // -2000 сделано или нету  -1000 = нету не куплино
    //            GameObject clone = Instantiate(TaskPref, transform.position, transform.rotation);
    //            clone.transform.SetParent(SpawnerTask.transform);
    //            TaskSQLKMM taksClone = clone.GetComponent<TaskSQLKMM>();
    //            taksClone.txtID.text = (i).ToString();
    //            taksClone.txtTitle.text = Events[i];
    //            taksClone.panelItem = this;
    //            taksClone.thisButComplate.interactable = false;
    //            bWinLoseTask = true;

    //            clone.transform.localScale = new Vector3(ScalePrefabTask.x, ScalePrefabTask.y, ScalePrefabTask.z);
    //            // Invoke("SizeCLon", 0.1f);
    //        }
    //        nameTask.interactable = false;
    //    }
    //  //  Debug.Log("bWinLoseTask" + bWinLoseTask);
    //}



}
