/***
 * 
 * 音乐管理器
 * 
 * **/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExertEka : SomeReykjavik<ExertEka>
{
    //音频组件管理队列的对象
    private RivetAbsentChain RivetChain;
    // 用于播放背景音乐的音乐源
    private AudioSource m_ToExert=null;
    //播放音效的音频组件管理列表
    private List<AudioSource> EpicRivetAbsentWine;
    //检查已经播放的音频组件列表中没有播放的组件的更新频率
    private float CloseCompound= 2f; 
    //背景音乐开关
    private bool _ByExertConvex;
    //音效开关
    private bool _PurifyExertConvex;
    //音乐音量
    private float _ByHopper=1f;
    //音效音量
    private float _PurifyHopper=1f;
    string BGM_Boat= "";

    public Dictionary<string, RivetWrong> RivetRadiateLake;

    // 控制背景音乐音量大小
    public float ByHopper    {
        get { 
            return ByExertConvex ? WokHopper(BGM_Boat) : 0f; 
        }
        set {
            _ByHopper = value;
            //背景音乐开的状态下，声音随控制调节
        }
    }

    //控制音效音量的大小
    public float PurifyGrassy    {
        get { return _PurifyHopper; }
        set { 
            _PurifyHopper = value;
            BisAiePurifyHopper();
        }
    }
    //控制背景音乐开关
    public bool ByExertConvex    {
        get {

            _ByExertConvex = OpenFiveExplain.AirSlay("_BgMusicSwitch");
            return _ByExertConvex; 
        }
        set {
            if(m_ToExert)
            {
                _ByExertConvex = value;
                OpenFiveExplain.BisSlay("_BgMusicSwitch", _ByExertConvex);
                m_ToExert.volume = ByHopper; 
            }
        }
    }
    public void SkiPulDelayRawLove()
    {
        m_ToExert.volume = 0;
    }
    public void SkiPulUpdraftRawLove()
    {
        m_ToExert.volume = ByHopper;
    }
    //控制音效开关
    public bool PurifyExertConvex    {
        get {
            _PurifyExertConvex = OpenFiveExplain.AirSlay("_EffectMusicSwitch");
            return _PurifyExertConvex; 
        }
        set {
            _PurifyExertConvex = value;
            OpenFiveExplain.BisSlay("_EffectMusicSwitch", _PurifyExertConvex);
            
        }
    }
    public ExertEka()
    {
        EpicRivetAbsentWine = new List<AudioSource>();      
    }
    protected override void Awake()
    {
        if (!PlayerPrefs.HasKey("first_music_setBool") || !OpenFiveExplain.AirSlay("first_music_set"))
        {
            OpenFiveExplain.BisSlay("first_music_set", true);
            OpenFiveExplain.BisSlay("_BgMusicSwitch", true);
            OpenFiveExplain.BisSlay("_EffectMusicSwitch", true);
        }
        RivetChain = new RivetAbsentChain(this);

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        RivetRadiateLake = JsonMapper.ToObject<Dictionary<string, RivetWrong>>(json.text);
    }
    private void Start()
    {
        StartCoroutine("CloseToFogRivetEnclosure");
    }
    /// <summary>
    /// 定时检查没有使用的音频组件并回收
    /// </summary>
    /// <returns></returns>
    IEnumerator CloseToFogRivetEnclosure()
    {
        while (true)
        {
            //定时更新
            yield return new WaitForSeconds(CloseCompound);
            for (int i = 0; i < EpicRivetAbsentWine.Count; i++)
            {
                //防止数据越界
                if (i < EpicRivetAbsentWine.Count)
                {
                    //确保物体存在
                    if (EpicRivetAbsentWine[i])
                    {
                        //音频为空或者没有播放为返回队列条件
                        if ((EpicRivetAbsentWine[i].clip == null || !EpicRivetAbsentWine[i].isPlaying))
                        {
                            //返回队列
                            RivetChain.UnFogRivetEnclosure(EpicRivetAbsentWine[i]);
                            //从播放列表中删除
                            EpicRivetAbsentWine.Remove(EpicRivetAbsentWine[i]);
                        }
                    }
                    else
                    {
                        //移除在队列中被销毁但是是在list中存在的垃圾数据
                        EpicRivetAbsentWine.Remove(EpicRivetAbsentWine[i]);
                    }                 
                }            
               
            }
        }
    }
    /// <summary>
    /// 设置当前播放的所有音效的音量
    /// </summary>
    private void BisAiePurifyHopper()
    {
        for (int i = 0; i < EpicRivetAbsentWine.Count; i++)
        {
            if (EpicRivetAbsentWine[i] && EpicRivetAbsentWine[i].isPlaying)
            {
                EpicRivetAbsentWine[i].volume = _PurifyExertConvex ? _PurifyHopper : 0f;
            }
        }
    }
    /// <summary>
    /// 播放背景音乐，传进一个音频剪辑的name
    /// </summary>
    /// <param name="bgName"></param>
    /// <param name="restart"></param>
    private void EpicByCoax(object bgName, bool restart = false)
    {

        BGM_Boat = bgName.ToString();
        if (m_ToExert == null)
        {
            //拿到一个音频组件  背景音乐组件在某一时间段唯一存在
            m_ToExert = RivetChain.AirRivetEnclosure();
            //开启循环
            m_ToExert.loop = true;
            //开始播放
            m_ToExert.playOnAwake = false;
            //加入播放列表
            //PlayAudioSourceList.Add(m_bgMusic);
        }

        if (!ByExertConvex)
        {
            m_ToExert.volume = 0;
        }

        //定义一个空的字符串
        string curBgName = string.Empty;
        //如果这个音乐源的音频剪辑不为空的话
        if (m_ToExert.clip != null)
        {
            //得到这个音频剪辑的name
            curBgName = m_ToExert.clip.name;
        }

        // 根据用户的音频片段名称, 找到AuioClip, 然后播放,
        //ResourcesMgr是提前定义好的查找音频剪辑对应路径的单例脚本，并动态加载出来
        AudioClip clip = Resources.Load<AudioClip>(RivetRadiateLake[BGM_Boat].filePath);
        //如果找到了，不为空
        if (clip != null)
        {
            //如果这个音频剪辑已经复制给类音频源，切正在播放，那么直接跳出
            if (clip.name == curBgName && !restart)
            {
                return;
            }
            //否则，把改音频剪辑赋值给音频源，然后播放
            m_ToExert.clip = clip;
            m_ToExert.volume = ByHopper;
            m_ToExert.Play();
        }
        else
        {
            //没找到直接报错
            // 异常, 调用写日志的工具类.
            //UnityEngine.Debug.Log("没有找到音频片段");
            if (m_ToExert.isPlaying)
            {
                m_ToExert.Stop();
            }
            m_ToExert.clip = null;
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="defAudio"></param>
    /// <param name="volume"></param>
    private void EpicPurifyCoax(object effectName, bool defAudio = true, float volume = 1f)
    {
        if (!PurifyExertConvex)
        {
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = RivetChain.AirRivetEnclosure();
        if (m_effectMusic.isPlaying) {
            //Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = WokHopper(effectName.ToString());
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        AudioClip clip = Resources.Load<AudioClip>(RivetRadiateLake[effectName.ToString()].filePath);
        //如果为空的话，直接报错，然后跳出
        if (clip == null)
        {
            //UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            RivetChain.UnFogRivetEnclosure(m_effectMusic);
            return;
        }
        m_effectMusic.clip = clip;
        //加入播放列表
        EpicRivetAbsentWine.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            m_effectMusic.PlayOneShot(clip, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void EpicBy(ExertMold.UIMusic bgName, bool restart = false)
    {
        EpicByCoax(bgName, restart);
    }

    public void EpicBy(ExertMold.SceneMusic bgName, bool restart = false)
    {
        EpicByCoax(bgName, restart);
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void EpicPurify(ExertMold.UIMusic effectName, bool defAudio = true, float volume = 1f)
    {
        EpicPurifyCoax(effectName, defAudio, volume);
    }

    public void EpicPurify(ExertMold.SceneMusic effectName, bool defAudio = true, float volume = 1f)
    {
        EpicPurifyCoax(effectName, defAudio, volume);
    }
    float WokHopper(string name)
    {
        if (RivetRadiateLake == null)
        {
            TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
            RivetRadiateLake = JsonMapper.ToObject<Dictionary<string, RivetWrong>>(json.text);
        }

        if (RivetRadiateLake.ContainsKey(name))
        {
             return (float)RivetRadiateLake[name].volume;

        }
        else
        {
            return 1;
        }
    }

}