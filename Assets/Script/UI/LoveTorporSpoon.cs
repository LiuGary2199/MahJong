using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LoveTorporSpoon : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("m_ItemIndex")]    public int m_TramElect;
[UnityEngine.Serialization.FormerlySerializedAs("m_RewardText")]    public Text m_TorporExam;
[UnityEngine.Serialization.FormerlySerializedAs("m_AdCountText")]    public Text m_AnCrackExam;
[UnityEngine.Serialization.FormerlySerializedAs("m_AdWatchBtn")]
    public Button m_AnPianoYam;
[UnityEngine.Serialization.FormerlySerializedAs("m_RewarededBtn")]    public GameObject m_BiologistYam;
[UnityEngine.Serialization.FormerlySerializedAs("m_TimeBtn")]    public GameObject m_LoveYam;
[UnityEngine.Serialization.FormerlySerializedAs("m_GetBtn")]    public Button m_AirYam;
[UnityEngine.Serialization.FormerlySerializedAs("OnAdFinish")]    public Action<int> AnAnStatus;
[UnityEngine.Serialization.FormerlySerializedAs("OnGetFinish")]    public Action<int> AnAirStatus;

    private DayRewardData m_GetTorporFive;
    public void User()
    {
        m_AnPianoYam.onClick.RemoveAllListeners();
        m_AirYam.onClick.RemoveAllListeners();
        m_AnPianoYam.onClick.AddListener(() =>
        {
            ADExplain.Expertly.FoilTorporWeary((success) =>
            {
                if (success)
                {
                    AnAnStatus?.Invoke(m_TramElect);
                }
            }, "7");
        });
        m_AirYam.onClick.AddListener(() =>
        {
            AideBelle.Instance.MayPace(m_GetTorporFive.reward_num);
            AnAirStatus?.Invoke(m_TramElect);
        });
    }
    public void PitTram(DayRewardData dayRewardData,bool beforget)
    {
        m_GetTorporFive = dayRewardData;
        
        m_AnPianoYam.gameObject.SetActive(false);
        m_AirYam.gameObject.SetActive(false);
        m_BiologistYam.SetActive(false);
        m_LoveYam.SetActive(false);
        long nowtime = GameUtil.GetNowTime();
        if (nowtime >= m_GetTorporFive.look_time && beforget)//������ȡʱ��
        {
            if (m_GetTorporFive.look_num >= m_GetTorporFive.ad_num)
            {
                if (m_GetTorporFive.getState == 0)
                {
                    m_AirYam.gameObject.SetActive(true);
                }
                else
                {
                    m_AirYam.gameObject.SetActive(false);
                    m_BiologistYam.SetActive(true);
                }
            }
            else
            {
                m_AnPianoYam.gameObject.SetActive(true);
            }
        }
        else
        {
            m_LoveYam.SetActive(true);
        }
        StringBuilder sb = new StringBuilder();
        string formatted = string.Format("({0}/{1})", m_GetTorporFive.look_num, m_GetTorporFive.ad_num);
        sb.Append(formatted);
        m_AnCrackExam.text = sb.ToString();
        m_TorporExam.text = m_GetTorporFive.reward_num.ToString();
    }
}
