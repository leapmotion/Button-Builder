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
public class ButtonColors : MonoBehaviour {
  public enum ButtonState { Base, Pressed, Hovering, Toggled };
  public ButtonState _currentState = ButtonState.Base;
  public ButtonState currentState {
    get { return _currentState; }
    set { _currentState = value; }
  }

  public void setState(int state) {
    currentState = (ButtonState)state;
    resetColor();
  }

  LeapGraphic graphic;
  CustomVectorChannelData graphicColor;

  public Color baseColor;
  public Color pressedColor;
  public Color hoveringColor;
  public Color toggledColor;

  public void setGraphicColor(Color color) {
    if(graphic == null) {
      graphic = GetComponent<LeapGraphic>();
      if (graphic == null) {
        graphic = GetComponentInParent<LeapGraphic>();
      }
    }

    if (graphicColor == null) {
      graphicColor = graphic.GetFeatureData<CustomVectorChannelData>();
    }

    graphicColor.value = color.ToHSV();
  }

  public void resetColor() {
    setGraphicColor(getCurrentModeColor());
  }

  public Color getCurrentModeColor() {
    switch (_currentState) {
      case ButtonState.Base:
        return baseColor;
      case ButtonState.Pressed:
        return pressedColor;
      case ButtonState.Hovering:
        return hoveringColor;
      case ButtonState.Toggled:
        return toggledColor;
      default:
        return baseColor;
    }
  }
}
