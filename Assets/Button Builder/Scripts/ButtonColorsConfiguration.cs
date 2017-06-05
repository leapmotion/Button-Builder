/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2017.                                 *
 * Leap Motion proprietary and  confidential.                                 *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using Leap.Unity.GraphicalRenderer;

public class ButtonColorsConfiguration : MonoBehaviour {
  public enum ButtonState { Base, Pressed, Hovering, Toggled };

  public ButtonColors buttonColors;

  public ButtonState _currentMode = 0;
  public ButtonState currentMode {
    get { return _currentMode; }
    set { _currentMode = value; }
  }

  public LeapGraphic baseButtonGraphic;
  public LeapGraphic pressedButtonGraphic;
  public LeapGraphic hoveringButtonGraphic;
  public LeapGraphic toggledButtonGraphic;

  void Start() {
    baseButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = buttonColors.baseColor.ToHSV();
    pressedButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = buttonColors.pressedColor.ToHSV();
    hoveringButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = buttonColors.hoveringColor.ToHSV();
    toggledButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = buttonColors.toggledColor.ToHSV();
  }

  public void setMode(int state) {
    currentMode = (ButtonState)state;
  }

  public void setModeColor(Color color) {
    switch (currentMode) {
      case ButtonState.Base:
        buttonColors.baseColor = color;
        baseButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = color.ToHSV();
        break;
      case ButtonState.Pressed:
        buttonColors.pressedColor = color;
        pressedButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = color.ToHSV();
        break;
      case ButtonState.Hovering:
        buttonColors.hoveringColor = color;
        hoveringButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = color.ToHSV();
        break;
      case ButtonState.Toggled:
        buttonColors.toggledColor = color;
        toggledButtonGraphic.GetFeatureData<CustomVectorChannelData>().value = color.ToHSV();
        break;
    }
  }

  public Color getCurrentModeColor() {
    switch (currentMode) {
      case ButtonState.Base:
        return buttonColors.baseColor;
      case ButtonState.Pressed:
        return buttonColors.pressedColor;
      case ButtonState.Hovering:
        return buttonColors.hoveringColor;
      case ButtonState.Toggled:
        return buttonColors.toggledColor;
      default:
        return buttonColors.baseColor;
    }
  }
}
