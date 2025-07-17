using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class SeepageFive
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool NightSlay;
    public bool NightSlay2;
    public int NightLag;
    public int NightLag2;
    public int NightLag3;
    public float NightHypha;
    public float NightHypha2;
    public double NightColumn;
    public double NightColumn2;
    public string NightRecoil;
    public string NightRecoil2;
    public GameObject NightScamLichen;
    public GameObject NightScamLichen2;
    public GameObject NightScamLichen3;
    public GameObject NightScamLichen4;
    public Transform NightPresident;
    public List<string> NightRecoilWine;
    public List<Vector2> NightAid2Wine;
    public List<int> NightLagWine;
    public System.Action GunfireReedWine;
    public Vector2 Rob2_1;
    public Vector2 Rob2_2;
    public SeepageFive()
    {
    }
    public SeepageFive(Vector2 v2_1)
    {
        Rob2_1 = v2_1;
    }
    public SeepageFive(Vector2 v2_1, Vector2 v2_2)
    {
        Rob2_1 = v2_1;
        Rob2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public SeepageFive(bool value)
    {
        NightSlay = value;
    }
    public SeepageFive(bool value, bool value2)
    {
        NightSlay = value;
        NightSlay2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public SeepageFive(int value)
    {
        NightLag = value;
    }
    public SeepageFive(int value, int value2)
    {
        NightLag = value;
        NightLag2 = value2;
    }
    public SeepageFive(int value, int value2, int value3)
    {
        NightLag = value;
        NightLag2 = value2;
        NightLag3 = value3;
    }
    public SeepageFive(List<int> value,List<Vector2> value2)
    {
        NightLagWine = value;
        NightAid2Wine = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public SeepageFive(float value)
    {
        NightHypha = value;
    }
    public SeepageFive(float value,float value2)
    {
        NightHypha = value;
        NightHypha = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public SeepageFive(double value)
    {
        NightColumn = value;
    }
    public SeepageFive(double value, double value2)
    {
        NightColumn = value;
        NightColumn = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public SeepageFive(string value)
    {
        NightRecoil = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public SeepageFive(string value1,string value2)
    {
        NightRecoil = value1;
        NightRecoil2 = value2;
    }
    public SeepageFive(GameObject value1)
    {
        NightScamLichen = value1;
    }

    public SeepageFive(Transform transform)
    {
        NightPresident = transform;
    }
}

