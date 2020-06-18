using UnityEngine;
//using Mirror;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite; // from https://github.com/praeclarum/sqlite-net
using UnityEngine.AI;
public partial class Database : MonoBehaviour
{
    ///  ДЛЯ РАБОТЫ С Webom Testovya

    public void CreatTable()
    {
        connection.CreateTable<testTable>();
    }


    class testTable    /// orcan
    {
        [PrimaryKey] // // важно для производительности: O (log n) вместо O (n)
        [Collation("NOCASE")] //// [COLLATE NOCASE для сравнения без учета регистра. таким образом, мы не можем одновременно создавать "Арчер" и "Арчер" как символы]
        public string name { get; set; }  // имя в названия в Ячейки тлько 1 может быть
        public string test1 { get; set; }
        public string test2 { get; set; }
    }
     

    public void PushTest(string valueName, GameObject itemManagerGO)
    {
        SQLbutn itemManager = itemManagerGO.GetComponent<SQLbutn>();
        // Debug.Log("????Data PushValuesItem????" + valueName + "    " + itemManagerGO.name); 
        connection.Execute("DELETE FROM testTable WHERE name=?", valueName); 
        connection.InsertOrReplace(new testTable
        {
            //  ID = itemManager.ID,
            name =      valueName,
            test1 =     itemManager.test1 ,
            test2 =     itemManager.test2 

    });


    }
    public void PullTest(string valueName, GameObject itemManagerGO)
    {


        SQLbutn itemManager = itemManagerGO.GetComponent<SQLbutn>();

        foreach (testTable row in connection.Query<testTable>("SELECT * FROM testTable  WHERE name=?", valueName))
        {


            //   itemManager.ID = row.ID; 
            itemManager.test1 = row.test1;
            itemManager.test2 = row.test2;

        }

    }





    /// //////  КОНЕЦ   Webom Testovya    ////   //// /  // 
    ///


     
}