using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 基础UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class CoaxUIProwl : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("_CurrentUIType")]    //当前（基类）窗口的类型
    public UIMold _ZealandUIMold= new UIMold();
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("close_button")]    public Button Drain_Feeble;
    //属性，当前ui窗体类型
    internal UIMold ZealandUIMold    {
        set
        {
            _ZealandUIMold = value;
        }
        get
        {
            return _ZealandUIMold;
        }
    }
    protected virtual void Awake()
    {
        PealMinorMayEnclosure(gameObject);
        if (transform.Find("Window/Content/CloseBtn"))
        {
            Drain_Feeble = transform.Find("Window/Content/CloseBtn").GetComponent<Button>();
            Drain_Feeble.onClick.AddListener(() => {
                UIExplain.AirExpertly().DelayUpDorsalUIProwl(this.GetType().Name);
            });
        }
        if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.name = GetType().Name;
    }


    public static void PealMinorMayEnclosure(GameObject goParent)
    {
        Transform parent = goParent.transform;
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform chile = parent.GetChild(i);
            if (chile.GetComponent<Button>())
            {
                chile.GetComponent<Button>().onClick.AddListener(() => {

                    ExertEka.AirExpertly().EpicPurify(ExertMold.UIMusic.Sound_UIButton);
                });
            }
            
            if (chile.childCount > 0)
            {
                PealMinorMayEnclosure(chile.gameObject);
            }
        }
    }

    //页面显示
    public virtual void Display(object uiFormParams)
    {
        //Debug.Log(this.GetType().Name);
        this.gameObject.SetActive(true);
        // 设置模态窗体调用(必须是弹出窗体)
        if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp && _ZealandUIMold.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UIToolEka.AirExpertly().BisToolMarvel(this.gameObject, _ZealandUIMold.UIForm_LucencyType);
        }
        if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp)
        {

            //动画添加
            switch (_ZealandUIMold.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    InfantileMercantile.LadHale(gameObject, () =>
                    {

                    });
                    break;

            }
            
        }
        //NewUserManager.GetInstance().TriggerEvent(TriggerType.panel_display);
    }
    //页面隐藏（不在栈集合中）
    public virtual void Hidding(System.Action finish = null)
    {
        //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
        //{
        //    UIToolEka.GetInstance().HideMaskWindow();
        //}

        //取消模态窗体调用

        if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp)
        {
            switch (_ZealandUIMold.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    InfantileMercantile.LadTail(gameObject, () =>
                    {
                        this.gameObject.SetActive(false);
                        if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp && _ZealandUIMold.UIForm_LucencyType != UIFormLucenyType.NoMask)
                        {
                            UIToolEka.AirExpertly().MelodyToolMarvel();
                        }
                        UIExplain.AirExpertly().HaleHandLadAx();
                        finish?.Invoke();
                    });
                    break;
                case UIFormShowAnimationType.none:
                    this.gameObject.SetActive(false);
                    if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp && _ZealandUIMold.UIForm_LucencyType != UIFormLucenyType.NoMask)
                    {
                        UIToolEka.AirExpertly().MelodyToolMarvel();
                    }
                    UIExplain.AirExpertly().HaleHandLadAx();
                    finish?.Invoke();
                    break;

            }

        }
        else
        {
            this.gameObject.SetActive(false);
            //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
            //{
            //    UIToolEka.GetInstance().CancelMaskWindow();
            //}
            finish?.Invoke();
        }
    }

    public virtual void Hidding()
    {
        Hidding(null);
    }

    //页面重新显示
    public virtual void Redisplay()
    {
        this.gameObject.SetActive(true);
        if (_ZealandUIMold.UIForms_Type == UIFormType.PopUp)
        {
            UIToolEka.AirExpertly().BisToolMarvel(this.gameObject, _ZealandUIMold.UIForm_LucencyType); 
        }
    }
    //页面冻结（还在栈集合中）
    public virtual void Aspect()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    /// <param name="buttonName">按钮节点名称</param>
    /// <param name="delHandle">委托，需要注册的方法</param>
    protected void SuccinctSenateLichenTruck(string buttonName,TruckFoliagePrestige.VoidDelegate delHandle)
    {
        GameObject goButton = VagueSludge.PealTheMinorCoil(this.gameObject, buttonName).gameObject;
        //给按钮注册事件方法
        if (goButton != null)
        {
            TruckFoliagePrestige.Air(goButton).onAloud = delHandle;
        }
    }

    /// <summary>
    /// 打开ui窗体
    /// </summary>
    /// <param name="uiFormName"></param>
    protected void LiftUIFine(string uiFormName)
    {
        UIExplain.AirExpertly().HaleUIProwl(uiFormName);
    }

    /// <summary>
    /// 关闭当前ui窗体
    /// </summary>
    protected void DelayUIFine(string uiFormName)
    {
        //处理后的uiform名称
        UIExplain.AirExpertly().DelayUpDorsalUIProwl(uiFormName);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgType">消息的类型</param>
    /// <param name="msgName">消息名称</param>
    /// <param name="msgContent">消息内容</param>
    protected void FastSeepage(string msgType,string msgName,object msgContent)
    {
        KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
        SeepageGrassy.FastSeepage(msgType, kvs);
    }

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public void CheapenSeepage(string messageType,SeepageGrassy.DelMessageDelivery handler)
    {
        SeepageGrassy.MayMsgPrestige(messageType, handler);
    }

    /// <summary>
    /// 显示语言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string Hale(string id)
    {
        string strResult = string.Empty;
        strResult = ApparentEka.AirExpertly().HaleExam(id);
        return strResult;
    }
}
