/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2017.                                 *
 * Leap Motion proprietary and  confidential.                                 *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.GraphicalRenderer;

[ExecuteInEditMode]
public class ConvertAtlasToHSV : MonoBehaviour {

  private List<LeapMesherBase> _meshers = new List<LeapMesherBase>();

  private void OnEnable() {
    if (!Application.isPlaying) {
      foreach (var group in GetComponent<LeapGraphicRenderer>().groups) {
        if (group.renderingMethod is LeapMesherBase) {
          var mesher = group.renderingMethod as LeapMesherBase;
          _meshers.Add(mesher);

          mesher.OnPostProcessAtlas += convertToHSV;
        }
      }
    }
  }

  private void OnDisable() {
    foreach (var mesher in _meshers) {
      if (mesher == null) continue;

      mesher.OnPostProcessAtlas -= convertToHSV;
    }
  }

  private void convertToHSV(Texture2D atlas, AtlasUvs uvs) {
    float h, s, v;
    Color[] pixels = atlas.GetPixels();

    for (int i = 0; i < pixels.Length; i++) {
      Color rgba = pixels[i];
      Color.RGBToHSV(rgba, out h, out s, out v);
      pixels[i] = new Color(h, s, v, rgba.a);
    }

    atlas.SetPixels(pixels);
    atlas.Apply(updateMipmaps: true, makeNoLongerReadable: false);
  }
}
