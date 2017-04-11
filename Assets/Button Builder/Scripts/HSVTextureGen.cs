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
        Color c = new Color(x / (resolution - 1.0f), y / (resolution - 1.0f), 1, 1);
        tex.SetPixel(x, y, c);
      }
    }
    tex.Apply();
    File.WriteAllBytes("Texture.png", tex.EncodeToPNG());
  }


}
