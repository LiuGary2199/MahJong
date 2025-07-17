using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolNeptune : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform Gold;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public DebtBook Tyrannical;
    private void Awake()
    {
        Tyrannical.AnDebtParent = Chondritic;
    }

    void Chondritic(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        Gold.GetComponent<RectTransform>().position = pos;
    }
}
