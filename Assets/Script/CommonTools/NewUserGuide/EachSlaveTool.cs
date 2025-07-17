using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 矩形遮罩镂空
/// </summary>
public class EachSlaveTool : MonoBehaviour
{
    public static EachSlaveTool instance;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    public GameObject Tape;

    /// <summary>
    /// 高亮显示目标
    /// </summary>
    private GameObject Master;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]
    public Text Exam;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Holland= new Vector3[4];
    /// <summary>
    /// 镂空区域中心
    /// </summary>
    private Vector4 Second;
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float MasterCandidX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float MasterCandidY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Instinct;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float OrderlyCandidX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float OrderlyCandidY= 0f;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float FlightLove= 0.1f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private EloquentTruckDeprecate PatchDeprecate;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    /// <summary>
    /// 显示引导遮罩
    /// </summary>
    /// <param name="_target">要引导到的目标对象</param>
    /// <param name="text">引导说明文案</param>

    public void HaleGuide(GameObject _target, string text)
    {
        gameObject.SetActive(true);

        if (_target == null)
        {
            Tape.SetActive(false);
            if (Instinct == null)
            {
                Instinct = GetComponent<Image>().material;
            }
            Instinct.SetVector("_Center", new Vector4(0, 0, 0, 0));
            Instinct.SetFloat("_SliderX", 0);
            Instinct.SetFloat("_SliderY", 0);
            // 如果没有target，点击任意区域关闭引导
            GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            });
        }
        else
        {
            DOTween.Kill("NewUserHandAnimation");
            User(_target);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (!string.IsNullOrEmpty(text))
        {
            Exam.text = text;
            Exam.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Exam.transform.parent.gameObject.SetActive(false);
        }
    }


    public void User(GameObject _target)
    {
        this.Master = _target;
        
        PatchDeprecate = GetComponent<EloquentTruckDeprecate>();
        if (PatchDeprecate != null)
        {
            // 删除 eventPenetrate.SetTargetImage(_target.GetComponent<Image>()); 相关调用
        }

        Canvas canvas = UIExplain.AirExpertly().LoneQuartz.GetComponent<Canvas>();

        //获取高亮区域的四个顶点的世界坐标
        if (Master.GetComponent<RectTransform>() != null)
        {
            Master.GetComponent<RectTransform>().GetWorldCorners(Holland);
        }
        else
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(_target.transform.position);
            pos = UIExplain.AirExpertly()._DewUICoerce.GetComponent<Camera>().ScreenToWorldPoint(pos);
            float width = 1;
            float height = 1;
            Holland[0] = new Vector3(pos.x - width, pos.y - height);
            Holland[1] = new Vector3(pos.x - width, pos.y + height);
            Holland[2] = new Vector3(pos.x + width, pos.y + height);
            Holland[3] = new Vector3(pos.x + width, pos.y - height);
        }
        //计算高亮显示区域在画布中的范围
        MasterCandidX = Vector2.Distance(WriteUpQuartzLap(canvas, Holland[0]), WriteUpQuartzLap(canvas, Holland[3])) / 2f;
        MasterCandidY = Vector2.Distance(WriteUpQuartzLap(canvas, Holland[0]), WriteUpQuartzLap(canvas, Holland[1])) / 2f;
        //计算高亮显示区域的中心
        float x = Holland[0].x + ((Holland[3].x - Holland[0].x) / 2);
        float y = Holland[0].y + ((Holland[1].y - Holland[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Second= WriteUpQuartzLap(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Second.x, Second.y, 0, 0);
        Instinct = GetComponent<Image>().material;
        Instinct.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Holland);
            //计算偏移初始值
            for (int i = 0; i < Holland.Length; i++)
            {
                if (i % 2 == 0)
                {
                    OrderlyCandidX = Mathf.Max(Vector3.Distance(WriteUpQuartzLap(canvas, Holland[i]), Second), OrderlyCandidX);
                }
                else
                {
                    OrderlyCandidY = Mathf.Max(Vector3.Distance(WriteUpQuartzLap(canvas, Holland[i]), Second), OrderlyCandidY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Instinct.SetFloat("_SliderX", OrderlyCandidX);
        Instinct.SetFloat("_SliderY", OrderlyCandidY);
        Tape.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(HaleTape(Second));
    }

    private IEnumerator HaleTape(Vector2 center)
    {
        Tape.SetActive(false);
        yield return new WaitForSeconds(FlightLove);
        
        Tape.transform.localPosition = center;
        TapeInfantile();
        
        Tape.SetActive(true);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float FlightVolcanicX= 0f;
    private float FlightVolcanicY= 0f;
    private void Update()
    {
        if (Instinct == null) return;

        OrderlyCandidX = MasterCandidX;
        Instinct.SetFloat("_SliderX", OrderlyCandidX);
        OrderlyCandidY = MasterCandidY;
        Instinct.SetFloat("_SliderY", OrderlyCandidY);
        //从当前偏移量到目标偏移量差值显示收缩动画
        //float valueX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref shrinkVelocityX, shrinkTime);
        //float valueY = Mathf.SmoothDamp(currentOffsetY, targetOffsetY, ref shrinkVelocityY, shrinkTime);
        //if (!Mathf.Approximately(valueX, currentOffsetX))
        //{
        //    currentOffsetX = valueX;
        //    material.SetFloat("_SliderX", currentOffsetX);
        //}
        //if (!Mathf.Approximately(valueY, currentOffsetY))
        //{
        //    currentOffsetY = valueY;
        //    material.SetFloat("_SliderY", currentOffsetY);
        //}


    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 WriteUpQuartzLap(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }

    public void TapeInfantile() 
    {
        
        var s = DOTween.Sequence();
        s.Append(Tape.transform.DOLocalMoveY(Tape.transform.localPosition.y + 10f, 0.5f));
        s.Append(Tape.transform.DOLocalMoveY(Tape.transform.localPosition.y, 0.5f));
        s.Join(Tape.transform.DOScaleY(1.1f, 0.125f));
        s.Join(Tape.transform.DOScaleX(0.9f, 0.125f).OnComplete(()=> 
        {
            Tape.transform.DOScaleY(0.9f, 0.125f);
            Tape.transform.DOScaleX(1.1f, 0.125f).OnComplete(()=> 
            {
                Tape.transform.DOScale(1f, 0.125f);
            });
        }));
        s.SetLoops(-1);
        s.SetId("NewUserHandAnimation");
    }

    public void OnDisable()
    {
        DOTween.Kill("NewUserHandAnimation");
    }
}
