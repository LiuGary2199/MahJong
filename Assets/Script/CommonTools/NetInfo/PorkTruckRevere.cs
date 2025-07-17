using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class PorkTruckRevere : SomeReykjavik<PorkTruckRevere>
{
    public string Arsenic= "1.2";
    public string ScamCode= PinBeadEka.instance.ScamCode;
    //channel
#if UNITY_IOS
    private string Survive= "AppStore";
#elif UNITY_ANDROID
    private string Channel = "GooglePlay";
#else
    private string Channel = "GooglePlay";
#endif


    private void OnApplicationPause(bool pause)
    {
        PorkTruckRevere.AirExpertly().NickScamFumigate();
    }
    
    public Text June;

    protected override void Awake()
    {
        base.Awake();
        
        Arsenic = Application.version;
        StartCoroutine("LumpSeepage");
    }
    IEnumerator LumpSeepage()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            PorkTruckRevere.AirExpertly().NickScamFumigate();
        }
    }
    private void Start()
    {
        if (OpenFiveExplain.AirLag("event_day") != DateTime.Now.Day && OpenFiveExplain.AirRecoil("user_servers_id").Length != 0)
        {
            OpenFiveExplain.BisLag("event_day", DateTime.Now.Day);
        }
    }
    public void FastAxPoseTruck(string event_id)
    {
        FastTruck(event_id);
    }
    public void NickScamFumigate(List<string> valueList = null)
    {
        if (OpenFiveExplain.AirColumn(CStatus.Be_HandsomelyPoemFlee) == 0)
        {
            OpenFiveExplain.BisColumn(CStatus.Be_HandsomelyPoemFlee, OpenFiveExplain.AirColumn(CStatus.Be_PoemFlee));
        }
        if (OpenFiveExplain.AirColumn(CStatus.Be_HandsomelyEpoch) == 0)
        {
            OpenFiveExplain.BisColumn(CStatus.Be_HandsomelyEpoch, OpenFiveExplain.AirColumn(CStatus.Be_Epoch));
        }
        if (valueList == null)
        {
            valueList = new List<string>() { 
                OpenFiveExplain.AirLag(CStatus.Be_HandsomelyPoemFlee).ToString(),
                OpenFiveExplain.AirLag(CStatus.Be_ReverseErieMaiden).ToString(),
                OpenFiveExplain.AirRecoil(CStatus.Be_HandsomelyEpoch),
                OpenFiveExplain.AirHypha(CStatus.Be_SerumScamLove).ToString()
                //OpenFiveExplain.GetInt(SlotConfig.sv_SlotSpinCount).ToString()
            };
        }
        
        if (OpenFiveExplain.AirRecoil(CStatus.Be_CrossBreezeOn) == null)
        {
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", ScamCode);
        wwwForm.AddField("userId", OpenFiveExplain.AirRecoil(CStatus.Be_CrossBreezeOn));

        wwwForm.AddField("gameVersion", Arsenic);

        wwwForm.AddField("channel", Survive);

        for (int i = 0; i < valueList.Count; i++)
        {
            wwwForm.AddField("resource" + (i + 1), valueList[i]);
        }



        StartCoroutine(FastPork(PinBeadEka.instance.CoaxTug + "/api/client/game_progress", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    public void FastTruck(string event_id, string p1 = null, string p2 = null, string p3 = null)
    {
        if (June != null)
        {
            if (int.Parse(event_id) < 9100 && int.Parse(event_id) >= 9000)
            {
                if (p1 == null)
                {
                    p1 = "";
                }
                June.text += "\n" + DateTime.Now.ToString() + "id:" + event_id + "  p1:" + p1;
            }
        }
        if (OpenFiveExplain.AirRecoil(CStatus.Be_CrossBreezeOn) == null)
        {
            PinBeadEka.instance.Later();
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", ScamCode);
        wwwForm.AddField("userId", OpenFiveExplain.AirRecoil(CStatus.Be_CrossBreezeOn));
        //Debug.Log("userId:" + OpenFiveExplain.GetString(CStatus.sv_LocalServerId));
        wwwForm.AddField("version", Arsenic);
        //Debug.Log("version:" + version);
        wwwForm.AddField("channel", Survive);
        //Debug.Log("channel:" + channal);
        wwwForm.AddField("operateId", event_id);
        Debug.Log("operateId:" + event_id);


        if (p1 != null)
        {
            wwwForm.AddField("params1", p1);
        }
        if (p2 != null)
        {
            wwwForm.AddField("params2", p2);
        }
        if (p3 != null)
        {
            wwwForm.AddField("params3", p3);
        }
        StartCoroutine(FastPork(PinBeadEka.instance.CoaxTug + "/api/client/log", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    IEnumerator FastPork(string _url, WWWForm wwwForm, Action<string> fail, Action<string> success)
    {
        //Debug.Log(SerializeDictionaryToJsonString(dic));
        using UnityWebRequest request = UnityWebRequest.Post(_url, wwwForm);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            fail(request.error);
            OftAffront();
        }
        else
        {
            success(request.downloadHandler.text);
            OftAffront();
        }
    }
    private void OftAffront()
    {
        StopCoroutine("SendGet");
    }


}