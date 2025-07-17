using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorporTramUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Icon")]    public Image Fuse;
[UnityEngine.Serialization.FormerlySerializedAs("NumText")]    public Text WanExam;

    public void Cobble(Sprite icon, int num = 0)
    {
        Fuse.sprite = icon;
        if (num == 0) {
            WanExam.gameObject.SetActive(false);
        }
        else
        {
            WanExam.text = "+" + num.ToString();
            WanExam.gameObject.SetActive(true);
        }
    }
}
