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




    //public void StartNewTable() // тут нужно показать образец создания в таблице новой строчки и  заполнить ее столбцы
    //{
    //    connection.CreateTable<testTable>();


    //    connection.InsertOrReplace(new testTable
    //    {

    //     name = "NEW",
    //     test1 = "NewNew",
    //     test2 = "BigNew"
    //        // lastsaved = DateTime.UtcNow, 
    //    });;


    //}


    //public void StartNewDATA() // тут нужно показать образец создания в таблице новой строчки и  заполнить ее столбцы
    //{
    // //   connection.CreateTable<testTable>();


    //    connection.InsertOrReplace(new testTable
    //    {

    //        name = "NEW",
    //        test1 = "WORD",
    //        test2 = "AHAHAH"
    //        // lastsaved = DateTime.UtcNow, 
    //    }); ;


    //}

    public void PushValuesItem(string valueName, GameObject itemManagerGO)
    {
        ItemManager itemManager = itemManagerGO.GetComponent<ItemManager>();
        // Debug.Log("????Data PushValuesItem????" + valueName + "    " + itemManagerGO.name);


        connection.Execute("DELETE FROM itemsBattle WHERE name=?", valueName);
        if (valueName != "CurrentItem")
        {
            connection.InsertOrReplace(new itemsBattle
            {
                //  ID = itemManager.ID,
                name = itemManager.Name,
                nameEdit = itemManager.NameEdit,
                myNameEdit = itemManager.MyNameEdit,
                description = itemManager.Discription,
                status = itemManager.Status,

                Event1 = itemManager.Events[0],
                Event2 = itemManager.Events[1],
                Event3 = itemManager.Events[2],
                Event4 = itemManager.Events[3],
                Event5 = itemManager.Events[4],

            });
        }
        else
        {

            connection.InsertOrReplace(new itemsBattle
            {
                //  ID = itemManager.ID,
                name = itemManager.CurrentEvent,
                nameEdit = itemManager.NameEdit,
                myNameEdit = itemManager.MyNameEdit,
                description = itemManager.Discription,
                status = itemManager.Status,

                Event1 = itemManager.curEvents[0],
                Event2 = itemManager.curEvents[1],
                Event3 = itemManager.curEvents[2],
                Event4 = itemManager.curEvents[3],
                Event5 = itemManager.curEvents[4],

            });

        }

    }

    public void PullValuesItem(string valueName, GameObject itemManagerGO)
    {


        ItemManager itemManager = itemManagerGO.GetComponent<ItemManager>();

        foreach (itemsBattle row in connection.Query<itemsBattle>("SELECT * FROM itemsBattle  WHERE name=?", valueName))
        {
            if (valueName != "CurrentItem")
            {
                //   itemManager.ID = row.ID;
                //   itemManager.Name = row.name;
                itemManager.NameEdit = row.nameEdit;
                itemManager.MyNameEdit = row.myNameEdit;
                itemManager.Discription = row.description;
                itemManager.Status = row.status;

                itemManager.Events[0] = row.Event1;
                itemManager.Events[1] = row.Event2;
                itemManager.Events[2] = row.Event3;
                itemManager.Events[3] = row.Event4;
                itemManager.Events[4] = row.Event5;
            }
            else
            {
                //   itemManager.ID = row.ID;
                //   itemManager.Name = row.name;
                itemManager.NameEdit = row.nameEdit;
                itemManager.MyNameEdit = row.myNameEdit;
                itemManager.Discription = row.description;
                itemManager.Status = row.status;

                itemManager.curEvents[0] = row.Event1;
                itemManager.curEvents[1] = row.Event2;
                itemManager.curEvents[2] = row.Event3;
                itemManager.curEvents[3] = row.Event4;
                itemManager.curEvents[4] = row.Event5;
            }
        }
    }

    //    public void rewriteALL() // тут нужно показать образец создания в таблице новой строчки и  заполнить ее столбцы
    //    {
    //        connection.CreateTable<monsters>();
    //        connection.CreateTable<itemsBattle>();
    //        connection.CreateTable<history>();

    //        //connection.InsertOrReplace(new history
    //        //{
    //        //   account  = "vasya",
    //        //  nameMonster = "GLAZ", 
    //        //   levelMonster = "3",
    //        //   locationColor = "Red",

    //        //   result = "1",
    //        //   nameWeapon = "AXE",
    //        //   startTime   = DateTime.UtcNow

    //        //});
    //        //connection.InsertOrReplace(new history
    //        //{
    //        //    account = "vasya",
    //        //    nameMonster = "GLAZ",
    //        //    levelMonster = "2",
    //        //    locationColor = "Green",

    //        //    result = "2",
    //        //    nameWeapon = "BOW",
    //        //    startTime = DateTime.UtcNow

    //        //});
    //        //connection.InsertOrReplace(new history
    //        //{
    //        //    account = "vasya",
    //        //    nameMonster = "SHARK",
    //        //    levelMonster = "2",
    //        //    locationColor = "Red",

    //        //    result = "1",
    //        //    nameWeapon = "SHIELD",
    //        //    startTime = DateTime.UtcNow

    //        //});
    //        //connection.InsertOrReplace(new history
    //        //{
    //        //    account = "vasya",
    //        //    nameMonster = "MINIDRAGON",
    //        //    levelMonster = "1",
    //        //    locationColor = "Blue",

    //        //    result = "2",
    //        //    nameWeapon = "BOW",
    //        //    startTime = DateTime.UtcNow

    //        //});

    //        // only use a transaction if not called within SaveMany transaction
    //        //    if (useTransaction) connection.BeginTransaction();
    //        /// создаем новую строку и заполняем ячейки

    //// 


    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "GLAZ",
    //            nameEdit = "Fear Monster",
    //            myNameEdit = "Страх Монстр",
    //            description = "Перед вами огромное существо с отвратительно раздутым телом .",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Организим боится Сильно что будет не удачи и будет очень трудно. Начинает прокастинировать говорить делай что угодно только не это",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });

    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "SHARK",
    //            nameEdit = "SHARK",
    //            myNameEdit = "Акула",
    //            description = "Перед вами мерзкое существо имеющее акулье тело.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Вы испытываете слабость и неохото ничего делать",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });
    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "MINIDRAGON",
    //            nameEdit = "Mini Dragon",
    //            myNameEdit = "ВидеоТоксичный",
    //            description = "Перед вами чудовищное существо имеющее драконоподобное тело.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Постоянно захожу на сайты Ютуб или игры Не могу остановиться",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });
    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "DRAGON",
    //            nameEdit = "Fear Monster",
    //            myNameEdit = "Страх Монстр",
    //            description = "Перед вами  огромное чудовищное существо имеющее драконоподобное тело, заканчивающееся гибким хвостом.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Ты чувствуешь стощение от вчерашнего дня, слабость и жуткое не прияхнь к работе",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });


    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "ALON",
    //            nameEdit = "Alon",
    //            myNameEdit = "Инопланетянин",
    //            description = "Перед вами существо с одним большим глазом.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Организим боится Сильно, что будет не удачи, долго и будет очень трудно. Начинает прокастинировать говорить делай что угодно только не это",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });

    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "FISH",
    //            nameEdit = "Fish",
    //            myNameEdit = "Рыбка",
    //            description = "На вас напало агресивное существо имеющее крепкие плавники. Его хребет украшает высокий костяной гребень.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Вы испытываете слабость и неохото ничего делать",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });
    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "MINIENTE",
    //            nameEdit = "Mini Ente",
    //            myNameEdit = "Маленький Энт",
    //            description = "Маленьки Злобный Энтик не ожидал ничего плохого, но наш герой решил показать кто тут главный.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Постоянно захожу на сайты Ютуб или игры Не могу остановиться",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });
    //        connection.InsertOrReplace(new monsters
    //        {
    //            account = "vasya",
    //            name = "FIREEGG",
    //            nameEdit = "Fire egg",
    //            myNameEdit = "Огненое Яйцо",
    //            description = "Перед вами злобное существо сбежавшие из лаборатории алхимиков.",
    //            level = "1",
    //            status = "2",

    //            discriptionHide = "Ты чувствуешь истощение от вчерашнего дня, слабость и жуткое не приязнь к работе",
    //            recomendation = "",
    //            element = "1",
    //            // lastsaved = DateTime.UtcNow, 
    //        });

    //        /////////         itemsBattle    ///////    itemsBattle       ////////


    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 1,
    //            account = "vasya",
    //            name = "AXE",
    //            nameEdit = "Axe",
    //            myNameEdit = "Топор",
    //            description = "Рубящее орудие, чаще короткодревковое и имеющее рабочее лезвие",
    //            level = "1",
    //            status = "2",

    //            Event1 = "Удар с Верху",
    //            Event2 = "Ударить со всей силой",
    //            Event3 = "Разящий удар",
    //            Event4 = "Со всей силы",
    //            Event5 = "Ошеломительный",
    //            // lastsaved = DateTime.UtcNow,
    //        });

    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 2,
    //            account = "vasya",
    //            name = "BOW",
    //            nameEdit = "Bow",
    //            myNameEdit = "Лук",
    //            description = "Метательное оружие, предназначенное для стрельбы стрелами.",
    //            level = "1",
    //            status = "1",

    //            Event1 = "выстрел в Верх",
    //            Event2 = "Прицельный выстрел",
    //            Event3 = "Разящий выстрел",
    //            Event4 = "Со всей силы",
    //            Event5 = "Ошеломительный выстрел",
    //        });
    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 3,
    //            account = "vasya",
    //            name = "SWORD",
    //            nameEdit = "Sword",
    //            myNameEdit = "Меч",
    //            description = "loloDescription1",
    //            level = "1",
    //            status = "3",

    //            Event1 = "Удар с Верху",
    //            Event2 = "Ударить со всей силой",
    //            Event3 = "Разящий удар",
    //            Event4 = "Со всей силы",
    //            Event5 = "Ошеломительный",
    //        });
    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 3,
    //            account = "vasya",
    //            name = "SHIELD",
    //            nameEdit = "Shield",
    //            myNameEdit = "Щит",
    //            description = "средство индивидуальной защиты иногда можно и атаковать",
    //            level = "1",
    //            status = "3",

    //            Event1 = "Удар с Верху Щитом",
    //            Event2 = "Ударить со всей силы Щитом ",
    //            Event3 = "Разящий удар Щитом",
    //            Event4 = "Толкнуть щитом",
    //            Event5 = "Разогнавшись ударить щитом",
    //        });

    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 3,
    //            account = "vasya",
    //            name = "FIRE",
    //            nameEdit = "Fire",
    //            myNameEdit = "GoooLLL",
    //            description = "loloDescription1",
    //            level = "1",
    //            status = "3",

    //            Event1 = "none",
    //            Event2 = "none",
    //            Event3 = "none",
    //            Event4 = "none",
    //            Event5 = "none",
    //        });
    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 3,
    //            account = "vasya",
    //            name = "BOLT",
    //            nameEdit = "Bolt",
    //            myNameEdit = "GoooLLL",
    //            description = "loloDescription1",
    //            level = "1",
    //            status = "3",

    //            Event1 = "Edit",
    //            Event2 = "Edit",
    //            Event3 = "Edit",
    //            Event4 = "Edit",
    //            Event5 = "Edit",
    //        });
    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 3,
    //            account = "vasya",
    //            name = "BLOOD",
    //            nameEdit = "Blood",
    //            myNameEdit = "GoooLLL",
    //            description = "loloDescription1",
    //            level = "1",
    //            status = "3",

    //            Event1 = "Edit",
    //            Event2 = "Edit",
    //            Event3 = "Edit",
    //            Event4 = "Edit",
    //            Event5 = "Edit",
    //        });
    //        connection.InsertOrReplace(new itemsBattle
    //        {
    //            //  ID = 3,
    //            account = "vasya",
    //            name = "LIGHT",
    //            nameEdit = "Light",
    //            myNameEdit = "GoooLLL",
    //            description = "loloDescription1",
    //            level = "1",
    //            status = "3",

    //            Event1 = "write",
    //            Event2 = "write",
    //            Event3 = "write",
    //            Event4 = "write",
    //            Event5 = "write",
    //        });
    //    }


}