/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2017.                                 *
 * Leap Motion proprietary and  confidential.                                 *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class HSVTextureGen : MonoBehaviour {

  public int resolution;

  [ContextMenu("Generate Texture")]
  public void doTheTex() {
    Texture2D tex = new Texture2D(resolution, resolution, TextureFormat.ARGB32, mipmap: false, linear: true);
    for (int x = 0; x < resolution; x++) {
      for (int y = 0; y < resolution; y++) {
        Color c = Color.HSVToRGB(x / (resolution - 1.0f), 1, 1);
        tex.SetPixel(x, y, c);
      }
    }
    tex.Apply();
    File.WriteAllBytes("Texture.png", tex.EncodeToPNG());
  }


}
