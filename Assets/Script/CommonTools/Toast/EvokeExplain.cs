using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvokeExplain : SomeReykjavik<EvokeExplain>
{

    public void HaleEvoke(string info)
    {
        UIExplain.AirExpertly().HaleUIProwl(nameof(Evoke), info);
    }
}
