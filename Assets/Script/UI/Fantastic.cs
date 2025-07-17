using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Text;
using DG.Tweening;
using Spine;


public class Fantastic : MonoBehaviour
{
    [SerializeField] private SkeletonGraphic m_DiscoverPercent;
[UnityEngine.Serialization.FormerlySerializedAs("textsObj")]    public GameObject textsYew;
[UnityEngine.Serialization.FormerlySerializedAs("numberText")]    public Text CitherExam;

    [Header("Ч������")]
    private Vector3 BuildingSpoil;
    private Tween OrderlySleep;
    [SerializeField] private float DissipateSpoil= 1.3f;   // ��������ֵ
    [SerializeField] private float Solidify= 0.6f;         // ������ʱ��
    [SerializeField] private Ease RideHe= Ease.OutQuad;    // ��0��overshoot�Ļ�������
    [SerializeField] private Ease RideFad= Ease.InQuad;    // ��overshoot��1�Ļ�������
    public void EpicDull(int number)
    {
        // 防止对象被隐藏或销毁时操作Tween
        if (!gameObject.activeInHierarchy || textsYew == null || m_DiscoverPercent == null) return;

        // Kill旧Tween（更健壮）
        if (OrderlySleep != null && OrderlySleep.IsActive())
            OrderlySleep.Kill();
        DG.Tweening.DOTween.Kill(this);

        m_DiscoverPercent.gameObject.SetActive(false);
        m_DiscoverPercent.gameObject.SetActive(true);
        m_DiscoverPercent.AnimationState.ClearTracks();
        m_DiscoverPercent.AnimationState.SetAnimation(0, "animation", false);
        BuildingSpoil = Vector3.one;
        textsYew.gameObject.SetActive(true);
        textsYew.transform.localScale = Vector3.zero;
        StringBuilder stringBuilder = new StringBuilder(); 
        stringBuilder.Append("x");
        stringBuilder.Append(number);
        CitherExam.text = stringBuilder.ToString();
        Sequence sequence = DOTween.Sequence().SetId(this);
        sequence.Append(textsYew.transform.DOScale(BuildingSpoil * DissipateSpoil, Solidify * 0.35f)
            .SetEase(RideHe));
        sequence.Append(textsYew.transform.DOScale(BuildingSpoil, 0.1f)
            .SetEase(RideFad));
        sequence.Insert(0.8f, DOVirtual.DelayedCall(0.1f, () => { }));
        sequence.OnComplete(() =>
        {
            if (textsYew != null)
                textsYew.transform.localScale = Vector3.zero;
        });
        OrderlySleep = sequence;
    }
    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            EpicDull(1);
        }
    }

    private void OnDestroy()
    {
        if (OrderlySleep != null && OrderlySleep.IsActive())
            OrderlySleep.Kill();
        DG.Tweening.DOTween.Kill(this);
    }
}
