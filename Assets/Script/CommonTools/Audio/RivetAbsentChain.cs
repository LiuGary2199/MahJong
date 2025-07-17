/***
 * 
 * AudioSource组件管理(音效，背景音乐除外)
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RivetAbsentChain 
{
    //音乐的管理者
    private GameObject RivetEka;
    //音乐组件管理队列
    private List<AudioSource> RivetEnclosureChain;
    //音乐组件默认容器最大值  
    private int RotCrack= 25;
    public RivetAbsentChain(ExertEka audioMgr)
    {
        RivetEka = audioMgr.gameObject;
        UserRivetAbsentChain();
    }
  
    /// <summary>
    /// 初始化队列
    /// </summary>
    private void UserRivetAbsentChain()
    {
        RivetEnclosureChain = new List<AudioSource>();
        for(int i = 0; i < RotCrack; i++)
        {
            MayRivetAbsentRubPuttEka();
        }
    }
    /// <summary>
    /// 给音乐的管理者添加音频组件，同时组件加入队列
    /// </summary>
    private AudioSource MayRivetAbsentRubPuttEka()
    {
        AudioSource audio = RivetEka.AddComponent<AudioSource>();
        RivetEnclosureChain.Add(audio);
        return audio;
    }
    /// <summary>
    /// 获取一个音频组件
    /// </summary>
    /// <param name="audioMgr"></param>
    /// <returns></returns>
    public AudioSource AirRivetEnclosure()
    {
        if (RivetEnclosureChain.Count > 0)
        {
            AudioSource audio = RivetEnclosureChain.Find(t => !t.isPlaying);
            if (audio)
            {
                RivetEnclosureChain.Remove(audio);
                return audio;
            }
            //队列中没有了，需额外添加
            return MayRivetAbsentRubPuttEka();
            //直接返回队列中存在的组件
            //return AudioComponentQueue.Dequeue();
        }
        else
        {
            //队列中没有了，需额外添加
            return  MayRivetAbsentRubPuttEka();
        }
    }
    /// <summary>
    /// 没有被使用的音频组件返回给队列
    /// </summary>
    /// <param name="audio"></param>
    public void UnFogRivetEnclosure(AudioSource audio)
    {
        if (RivetEnclosureChain.Contains(audio)) return;
        if (RivetEnclosureChain.Count >= RotCrack)
        {
            GameObject.Destroy(audio);
            //Debug.Log("删除组件");
        }
        else
        {
            audio.clip = null;
            RivetEnclosureChain.Add(audio);
        }

        //Debug.Log("队列长度是" + AudioComponentQueue.Count);
    }
    
}
