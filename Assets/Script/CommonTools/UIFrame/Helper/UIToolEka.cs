/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIToolEka : MonoBehaviour
{
    private static UIToolEka _Expertly= null;
    //ui根节点对象
    private GameObject _GoQuartzPick= null;
    //ui脚本节点对象
    private Transform _TraUIJustifyCoil= null;
    //顶层面板
    private GameObject _BeToBelle;
    //遮罩面板
    private GameObject _BeToolBelle;
    //ui摄像机
    private Camera _UICoerce;
    //ui摄像机原始的层深
    private float _EvaluateUICoercePluck;
    //获取实例
    public static UIToolEka AirExpertly()
    {
        if (_Expertly == null)
        {
            _Expertly = new GameObject("_UIMaskMgr").AddComponent<UIToolEka>();
        }
        return _Expertly;
    }
    private void Awake()
    {
        _GoQuartzPick = GameObject.FindGameObjectWithTag(SysVessel.SYS_TAG_CANVAS);
        _TraUIJustifyCoil = VagueSludge.PealTheMinorCoil(_GoQuartzPick, SysVessel.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        VagueSludge.MayMinorCoilUpSlightCoil(_TraUIJustifyCoil, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _BeToBelle = _GoQuartzPick;
        _BeToolBelle = VagueSludge.PealTheMinorCoil(_GoQuartzPick, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UICoerce = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UICoerce != null)
        {
            //得到ui相机原始的层深
            _EvaluateUICoercePluck = _UICoerce.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void BisToolMarvel(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _BeToBelle.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _BeToolBelle.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _BeToolBelle.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _BeToolBelle.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _BeToolBelle.GetComponent<Image>().color = newColor2;
                SeepageCenterBrine.AirExpertly().Fast(CStatus.So_WindowLift);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _BeToolBelle.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _BeToolBelle.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_BeToolBelle.activeInHierarchy)
                {
                    _BeToolBelle.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _BeToolBelle.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UICoerce != null)
        {
            _UICoerce.depth = _UICoerce.depth + 100;
        }
    }
    public void TailToolMarvel()
    {
        if (UIExplain.AirExpertly().CageUIProwl.Count > 0 || UIExplain.AirExpertly().AirZealandFineChunk().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_BeToolBelle.GetComponent<Image>().color.r, _BeToolBelle.GetComponent<Image>().color.g, _BeToolBelle.GetComponent<Image>().color.b,0);
        _BeToolBelle.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void MelodyToolMarvel()
    {
        if (UIExplain.AirExpertly().CageUIProwl.Count > 0 || UIExplain.AirExpertly().AirZealandFineChunk().Count > 0)
        {
            return;
        }
        // 检查是否有其他 PopUp 窗口正在显示
        bool hasOtherPopUp = false;
        var openingPanels = UIExplain.AirExpertly().AirGrandmaUnload(true);
        foreach (var panel in openingPanels)
        {
            var baseUIForm = panel.GetComponent<CoaxUIProwl>();
            if (baseUIForm != null && baseUIForm.ZealandUIMold.UIForms_Type == UIFormType.PopUp)
            {
                hasOtherPopUp = true;
                // 将遮罩放在最后一个 PopUp 窗口下面
                _BeToolBelle.transform.SetAsLastSibling();
                panel.transform.SetAsLastSibling();
                break;
            }
        }

        // 只有在没有其他 PopUp 窗口时才关闭遮罩
        if (!hasOtherPopUp)
        {
            //顶层窗体上移
            _BeToBelle.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            if (_BeToolBelle.activeInHierarchy)
            {
                _BeToolBelle.SetActive(false);
                SeepageCenterBrine.AirExpertly().Fast(CStatus.So_MarvelDelay);
            }
            //恢复当前ui摄像机的层深
            if (_UICoerce != null)
            {
                _UICoerce.depth = _EvaluateUICoercePluck;
            }
        }
    }
}
