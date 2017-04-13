using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorUtil {

  public static Vector3 ToHSV(this Color color) {
    float h, s, v;
    Color.RGBToHSV(color, out h, out s, out v);
    return new Vector3(h, s, v);
  }

  public static Color HSVtoRGB(this Vector3 hsv) {
    return Color.HSVToRGB(hsv.x, hsv.y, hsv.z);
  }




}
