using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class CardSeaway : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Scream_Mold;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Seaway_Mold;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Wad_Love;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Seaway_Ionize;
    private void Awake()
    {
        if (Wad_Love == RunTime.Awake)
        {
            PencilSoften();
        }
    }
    private void Start()
    {
        if (Wad_Love == RunTime.Start)
        {
            PencilSoften();
        }
    }

    public void PencilSoften()
    {
        if (Seaway_Mold == LayoutType.Sprite_First_Weight)
        {
            if (Scream_Mold == TargetType.UGUI)
            {

                float scale = Screen.width / Seaway_Ionize;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        if (Seaway_Mold == LayoutType.Screen_First_Weight)
        {
            if (Scream_Mold == TargetType.Scene)
            {
                float scale = AirWorthyFive.AirExpertly().getCoerceSolve() / Seaway_Ionize;
                transform.localScale = transform.localScale * scale;
            }
        }
        
        if (Seaway_Mold == LayoutType.Bottom)
        {
            if (Scream_Mold == TargetType.Scene)
            {
                float screen_bottom_y = AirWorthyFive.AirExpertly().WokCoerceWeight() / -2;
                screen_bottom_y += (Seaway_Ionize + (AirWorthyFive.AirExpertly().WokSubwayAtom(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
