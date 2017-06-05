/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2017.                                 *
 * Leap Motion proprietary and  confidential.                                 *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using Leap.Unity.Interaction;
using Leap.Unity.GraphicalRenderer;

public class HSVColorSwatch : MonoBehaviour {

  public ButtonColorsConfiguration colors;

  public InteractionSlider hSlider;
  public InteractionSlider sVSlider;

  [System.Serializable]
  public class ColorEvent : UnityEvent<Color> { }
  ///<summary> Converts slider values to a Vector3 for color setting. </summary>
  public ColorEvent GraphicColorEvent = new ColorEvent();

  private CustomVectorChannelData _cachedSwatchColor;
  private CustomVectorChannelData swatchColor {
    get {
      if (_cachedSwatchColor == null) {
        _cachedSwatchColor = GetComponent<LeapGraphic>().GetFeatureData<CustomVectorChannelData>();
      }
      return _cachedSwatchColor;
    }
  }

  public void Start() {
    resetColor();
  }

  public void UpdateColor() {
    swatchColor.value = new Vector3(hSlider.VerticalSliderValue, 1f, 1f);
    Color color = new Vector3(hSlider.VerticalSliderValue, sVSlider.HorizontalSliderValue, sVSlider.VerticalSliderValue).HSVtoRGB();
    GraphicColorEvent.Invoke(color);
  }

  public void resetColor() {
    if (swatchColor == null) { GetComponent<LeapGraphic>().GetFeatureData<CustomVectorChannelData>(); }

    Vector3 HSV = colors.getCurrentModeColor().ToHSV();

    hSlider.VerticalSliderValue = HSV.x;
    sVSlider.HorizontalSliderValue = HSV.y;
    sVSlider.VerticalSliderValue = HSV.z;

    swatchColor.value = new Vector3(hSlider.VerticalSliderValue, 1f, 1f);
  }
}
