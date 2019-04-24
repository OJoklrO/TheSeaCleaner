using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Center_Contral : MonoBehaviour {

    public GameObject Background_Start;
    public GameObject Title_MainTitle;
    public GameObject Title_Subtitle;
    public GameObject Button_Start;
    public GameObject Button_Shop;
    public GameObject Button_Exit;
    public GameObject Button_Tips;
    public GameObject Button_BG;
    public GameObject Tip;

    public Text titleFlash;

    public Canvas Canvas_Shop;

    public XDocument archive;                              // 脚本间共享存档

	// Use this for initialization
	void Start () {
        Archive.Init();

        {
            // 加载场景
            ComFunc.HiddenObject
                    (Button_Start, Button_BG, Button_Exit, Button_Tips, Title_Subtitle, Tip);
            Canvas_Shop.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
        {
            titleFlash.enabled = false;
            ComFunc.RecoveryObject
                (Button_Start, Button_BG, Button_Exit, Button_Tips);
        }
	}
}

public class ComFunc
{
    // 隐藏任意数量GameObject
    public static void HiddenObject(params GameObject[] gameObjects)
    {
        foreach (var gmObj in gameObjects)
            gmObj.gameObject.SetActive(false);
    }

    // 显示任意数量GameObject
    public static void RecoveryObject(params GameObject[] gameObjects)
    {
        foreach (var gmObj in gameObjects)
            gmObj.gameObject.SetActive(true);
    }
}

public class Archive
{
    /// 获取当前存档中的金币值，只读
    #region Money
    public static int Money
    {
        get
        {
            int money;
            XDocument archive = XDocument.Load(ArchiveName);
            XElement a = archive.Element("Archive");
            XElement MNum = a.Element("Money");

            money = Convert.ToInt32(MNum.Value);

            return money;
        }
    }
    #endregion

    /// 获取前十积分，只读
    #region BestTen
    public static int[] BestTen
    {
        get
        {
            int[] Ten = new int[10];
            int index = 0;

            XDocument archive = XDocument.Load(ArchiveName);

            XElement a = archive.Element("Archive");
            var b = a.Elements("BestTen");
            var bten = b.Elements();

            foreach (var x in bten)
            {
                Ten[index] = Convert.ToInt32(x.Value);
                index++;
            }

            return Ten;
        }
    }
    #endregion

    private static string ArchiveName = Directory.GetCurrentDirectory() + @"\archive";
    //private static string ArchiveName = @"C:\Users\sushuo\Desktop\Fish_1\archive.xml";



    /// 若为第一次打开，则为true，否则为false
    #region  IsFirst
    public static bool IsFirst
    {
        get
        {
            XDocument archive = XDocument.Load(ArchiveName);
            XElement a = archive.Element("Archive");
            XElement b = a.Element("IsFirst");

            if (Convert.ToInt32(b.Value) == 0)
                return false;
            else
                return true;
        }
    }

    #endregion

    /// 初始化存档
    /// 无参数
    /// 无返回值
    #region Init
    public static void Init()
    {
        if (File.Exists(ArchiveName)) { }
        else
        {
            XDocument archive = new XDocument(
                new XElement("Archive",
                    new XElement("Money", 0L),
                    new XElement("BestTen",
                        new XElement("_1", 0L),
                        new XElement("_2", 0L),
                        new XElement("_3", 0L),
                        new XElement("_4", 0L),
                        new XElement("_5", 0L),
                        new XElement("_6", 0L),
                        new XElement("_7", 0L),
                        new XElement("_8", 0L),
                        new XElement("_9", 0L),
                        new XElement("_10", 0L)
                        ),
                    new XElement("Shop",
                        new XElement("_1", 0L),
                        new XElement("_2", 0L),
                        new XElement("_3", 0L),
                        new XElement("_4", 0L)),
                    new XElement("IsFirst", 1L)));
            archive.Save(ArchiveName);
        }
    }
    #endregion

    /// 将金币增加量写入存档
    /// 接受任意数量int类型参数
    /// 无返回值

    #region AddMoney
    public static void AddMoney(params int[] dMoney)
    {
        int money;
        XDocument archive = XDocument.Load(ArchiveName);

        XElement a = archive.Element("Archive");
        XElement MNum = a.Element("Money");

        money = Convert.ToInt32(MNum.Value);

        foreach (var x in dMoney)
            money += x;

        MNum.SetValue(money);

        archive.Save(ArchiveName);
    }
    #endregion

    /// 将游戏结束后的得分与已有最高10次积分比较
    /// 接受一个 int 型参数
    /// 无返回值

    #region AddBestTen
    public static void AddBestTen(int goal)
    {
        int[] Ten = new int[10];
        int index = 0;

        XDocument archive = XDocument.Load(ArchiveName);

        XElement a = archive.Element("Archive");
        XElement b = a.Element("BestTen");
        var bten = b.Elements();

        foreach (var x in bten)
        {
            Ten[index] = Convert.ToInt32(x.Value);
            index++;
        }

        Ten = Archive.Inset(goal, Ten);

        index = 0;
        foreach (var x in bten)
        {
            x.SetValue(Ten[index]);
            index++;
        }


        archive.Save(ArchiveName);
    }
    #endregion



    /// 将商店物品设为已购买或未购买
    /// 接受一个 string 参数为物品名，一个 bool 参数为物品有无，true 为已购买，false为未购买
    /// 无返回值
    #region ShopChange
    public static void ShopChange(string Goods, bool Is_IsntHave)
    {
        XDocument archive = XDocument.Load(ArchiveName);
        XElement a = archive.Element("Archive");
        XElement b = a.Element("Shop");
        XElement good = b.Element(Goods);

        if (Is_IsntHave)
            good.SetValue(1);
        else
            good.SetValue(0);

        archive.Save(ArchiveName);
    }
    #endregion 


    /// 获取物品状态
    /// 接受一个 string 型参数为物品名
    /// 返回 bool 值，true为已拥有该物品，false为未拥有
    #region HaveOrNot
    public static bool HaveOrNot(string goods)
    {
        bool flag = true;
        XDocument archive = XDocument.Load(ArchiveName);
        XElement a = archive.Element("Archive");
        XElement b = a.Element("Shop");
        XElement g = a.Element(goods);

        if (Convert.ToInt32(g.Value) == 0)
            flag = false;

        return flag;
    }

    #endregion


    /// 将IsFirst设置为false
    /// 无接受参数，无返回值
    #region SetFirstNot
    public static void SetFirstNot()
    {
        XDocument archive = XDocument.Load(ArchiveName);
        XElement a = archive.Element("Archive");
        XElement b = a.Element("IsFirst");

        b.SetValue(0);
        archive.Save(ArchiveName);
    }

    #endregion


    #region Private Func
    /// 私有方法
    private static int[] Inset(int goal, int[] ten)
    {
        int index = -1;
        int aHead;
        int next;
        bool a = false;

        for (int i = 0; i < 10; i++)
        {
            if (goal > ten[i])
            {
                index = i;
                a = true;
                break;
            }
        }

        if (!a)
            return ten;
        aHead = ten[index];
        ten[index] = goal;


        for (int i = index + 1; i < 10; i++)
        {
            next = ten[i];
            ten[i] = aHead;
            aHead = next;
        }

        return ten;
    }
    #endregion
}