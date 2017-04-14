using UnityEngine;
using Leap.Unity.GraphicalRenderer;
public class ButtonColors : MonoBehaviour {
  public enum ButtonState { Base, Pressed, Hovering, Toggled};
  public ButtonState _currentState = ButtonState.Base;
  public ButtonState currentState {
    get { return _currentState; }
    set { _currentState = value; }
  }

  public void setState(int state) {
    currentState = (ButtonState)state;
    resetColor();
  }

  public CustomVectorChannelData graphicColor;

  public Color baseColor;
  public Color pressedColor;
  public Color hoveringColor;
  public Color toggledColor;

  public void setGraphicColor(Color color) {
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
