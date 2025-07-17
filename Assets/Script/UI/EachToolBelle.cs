using UnityEngine;
using UnityEngine.UI;

public class EachToolBelle : MonoBehaviour
{
    [Header("目标设置")]
[UnityEngine.Serialization.FormerlySerializedAs("targetObj")]    public GameObject MasterYew;
[UnityEngine.Serialization.FormerlySerializedAs("padding")]    public float Nurture= 10f; // 目标周围的边距

    [Header("动画设置")]
[UnityEngine.Serialization.FormerlySerializedAs("shrinkTime")]    public float FlightLove= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetX")]    public float MasterCandidX;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetY")]    public float MasterCandidY;

    private Material Instinct;
    private RectTransform MasterEach;
    private Canvas MasterQuartz;
    private RectTransform GoldEach;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetX")]
    public float OrderlyCandidX;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetY")]    public float OrderlyCandidY;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosX")]    public float MasterLapX;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosY")]    public float MasterLapY;

    private float FlightVolcanicX= 0f;
    private float FlightVolcanicY= 0f;
    private EloquentTruckDeprecate PatchDeprecate;
    private bool IceScreamYew= false;

    private void Start()
    {
        GoldEach = GetComponent<RectTransform>();
        Instinct = GetComponent<Image>().material;
        PatchDeprecate = GetComponent<EloquentTruckDeprecate>();

        // 检查是否有目标对象
        if (MasterYew != null)
        {
            MasterEach = MasterYew.GetComponent<RectTransform>();
            if (MasterEach != null)
            {
                MasterQuartz = MasterYew.GetComponentInParent<Canvas>();
                if (MasterQuartz != null)
                {
                    IceScreamYew = true;
                    SunlitScreamReputation();
                }
            }
        }

        if (!IceScreamYew)
        {
            // 原逻辑：使用Inspector中设置的参数
            Vector4 centerMat = new Vector4(MasterLapX, MasterLapY, 0, 0);
            Instinct.SetVector("_Center", centerMat);
        }

        if (PatchDeprecate != null && IceScreamYew)
        {
            PatchDeprecate.BisScreamEach(MasterEach);
        }
    }

    private void Update()
    {
        if (IceScreamYew)
        {
            SunlitScreamReputation();
        }

        // 原逻辑：平滑动画
        float valueX = Mathf.SmoothDamp(OrderlyCandidX, MasterCandidX, ref FlightVolcanicX, FlightLove);
        float valueY = Mathf.SmoothDamp(OrderlyCandidY, MasterCandidY, ref FlightVolcanicY, FlightLove);

        if (!Mathf.Approximately(valueX, OrderlyCandidX))
        {
            OrderlyCandidX = valueX;
            Instinct.SetFloat("_SliderX", OrderlyCandidX);
        }

        if (!Mathf.Approximately(valueY, OrderlyCandidY))
        {
            OrderlyCandidY = valueY;
            Instinct.SetFloat("_SliderY", OrderlyCandidY);
        }
    }

    private void SunlitScreamReputation()
    {
        // 获取目标在世界空间的中心点
        Vector3 worldCenter = MasterEach.TransformPoint(MasterEach.rect.center);
        // 转换为屏幕空间坐标
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(MasterQuartz.worldCamera, worldCenter);

        // 转换为遮罩面板的本地坐标
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GoldEach, screenPos, MasterQuartz.worldCamera, out localPos);

        // Debug输出详细信息
      //  Debug.Log($"[MaskPanel] 挖孔世界中心 worldCenter={worldCenter}, screenPos={screenPos}, localPos={localPos}, targetCanvas={targetCanvas}, worldCamera={targetCanvas.worldCamera}");
       // Debug.Log($"[MaskPanel] targetRect.position={targetRect.position}, sizeDelta={targetRect.sizeDelta}, rect={targetRect.rect}");

        // 设置遮罩中心为目标中心
        MasterLapX = localPos.x;
        MasterLapY = localPos.y;
        Instinct.SetVector("_Center", new Vector4(MasterLapX, MasterLapY, 0, 0));

        // 设置遮罩大小为目标大小加上边距
        MasterCandidX = (MasterEach.rect.width / 2) + Nurture;
        MasterCandidY = (MasterEach.rect.height / 2) + Nurture;
    }

    // 外部调用：设置新的目标对象
    public void BisScream(GameObject newTarget)
    {
        MasterYew = newTarget;

        if (MasterYew != null)
        {
            MasterEach = MasterYew.GetComponent<RectTransform>();
            if (MasterEach != null)
            {
                MasterQuartz = MasterYew.GetComponentInParent<Canvas>();
                if (MasterQuartz != null)
                {
                    IceScreamYew = true;
                    SunlitScreamReputation();

                    if (PatchDeprecate != null)
                    {
                        PatchDeprecate.BisScreamEach(MasterEach);
                    }
                }
            }
        }
        else
        {
            IceScreamYew = false;
        }
    }
}