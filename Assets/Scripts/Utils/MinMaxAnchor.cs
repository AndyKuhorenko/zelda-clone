using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MinMaxAnchor
{
    public static void SetMinMaxAnchor(this RectTransform rt, float x, float y)
    {
        rt.anchorMin = new Vector2(x, y);
        rt.anchorMax = new Vector2(x, y);
    }
}
