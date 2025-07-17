using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashExplain : MonoBehaviour
{
    public static CrashExplain Expertly{ get; private set; }

    // ��ʱ�����ݽṹ
    private class TimerData
    {
        public int On;                  // ��ʱ��ID
        public float Compound;          // ���ʱ�䣨�룩
        public Action AnSure;           // ÿ�δ����Ļص�
        public bool WeCondenses;        // �Ƿ��ظ�
        public bool WeChoosy;           // �Ƿ���ͣ
        public float PetticoatLove;     // ʣ��ʱ��
        public Coroutine Stonework;     // Э������
    }

    private readonly Dictionary<int, TimerData> _Member= new Dictionary<int, TimerData>();
    private int _KillCrashOn= 1;

    private void Awake()
    {
        if (Expertly != null && Expertly != this)
        {
            Destroy(gameObject);
            return;
        }
        Expertly = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// ������ʱ���������̣߳�
    /// </summary>
    /// <param name="interval">���ʱ�䣨�룩</param>
    /// <param name="onTick">ÿ�δ����Ļص�</param>
    /// <param name="isRepeating">�Ƿ��ظ�����</param>
    /// <param name="immediateFirstTick">�Ƿ�����������һ��</param>
    /// <returns>��ʱ��ID</returns>
    public int LotusCrash(float interval, Action onTick, bool isRepeating = false, bool immediateFirstTick = false)
    {
        int timerId = _KillCrashOn++;
        var timerData = new TimerData
        {
            On = timerId,
            Compound = interval,
            AnSure = onTick,
            WeCondenses = isRepeating,
            WeChoosy = false,
            PetticoatLove = interval
        };

        // ����Э�̣������߳�ִ�У�
        timerData.Stonework = StartCoroutine(CrashStonework(timerData, immediateFirstTick));
        _Member.Add(timerId, timerData);

        return timerId;
    }

    // ��ʱ��Э�̣������̣߳�
    private IEnumerator CrashStonework(TimerData data, bool immediateFirstTick)
    {
        // �Ƿ�����������һ��
        if (immediateFirstTick)
        {
            data.AnSure?.Invoke();
            if (!data.WeCondenses) yield break; // ���ظ�ģʽ�£��������������
        }

        // ѭ����ʱ
        while (true)
        {
            // �ȴ�ָ��ʱ�䣨ʹ�� unscaledTime ����ʱ������Ӱ�죩
            yield return new WaitForSecondsRealtime(data.Compound);

            // ����Ƿ��ѱ���ͣ/ֹͣ
            if (data.WeChoosy || !_Member.ContainsKey(data.On)) yield break;

            // �����ص�
            data.AnSure?.Invoke();

            // ���ظ�ģʽ�£����������
            if (!data.WeCondenses)
            {
                StopCrash(data.On);
                yield break;
            }
        }
    }

    /// <summary>
    /// ��ͣ��ʱ��
    /// </summary>
    public void SieveCrash(int timerId)
    {
        if (_Member.TryGetValue(timerId, out var data) && !data.WeChoosy)
        {
            data.WeChoosy = true;
            StopCoroutine(data.Stonework); // ֹͣ��ǰЭ��
        }
    }

    /// <summary>
    /// �ָ���ʱ��
    /// </summary>
    public void SaharaCrash(int timerId)
    {
        if (_Member.TryGetValue(timerId, out var data) && data.WeChoosy)
        {
            data.WeChoosy = false;
            // ��������Э�̣�������ʱ
            data.Stonework = StartCoroutine(CrashStonework(data, false));
        }
    }

    /// <summary>
    /// ֹͣ���Ƴ���ʱ��
    /// </summary>
    public void StopCrash(int timerId)
    {
        if (_Member.TryGetValue(timerId, out var data))
        {
            StopCoroutine(data.Stonework); // ֹͣЭ��
            _Member.Remove(timerId);       // ���ֵ��Ƴ�
        }
    }

    /// <summary>
    /// ֹͣ���м�ʱ��
    /// </summary>
    public void FastAieFourth()
    {
        foreach (var data in _Member.Values)
        {
            StopCoroutine(data.Stonework);
        }
        _Member.Clear();
    }

    /// <summary>
    /// ����ʱ���Ƿ�������
    /// </summary>
    public bool WePetiole(int timerId)
    {
        return _Member.TryGetValue(timerId, out var data) && !data.WeChoosy;
    }
}