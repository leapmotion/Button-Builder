using UnityEngine;

public class ButtonColorsConfiguration : MonoBehaviour {
  public enum ButtonState { Base, Pressed, Hovering, Toggled };

  public ButtonColors buttonColors;

  public ButtonState _currentMode = 0;
  public ButtonState currentMode {
    get { return _currentMode; }
    set { _currentMode = value; }
  }

  public void setMode(int state) {
    currentMode = (ButtonState)state;
  }

  public void setModeColor(Color color) {
    switch (currentMode) {
      case ButtonState.Base:
        buttonColors.baseColor = color;
        break;
      case ButtonState.Pressed:
        buttonColors.pressedColor = color;
        break;
      case ButtonState.Hovering:
        buttonColors.hoveringColor = color;
        break;
      case ButtonState.Toggled:
        buttonColors.toggledColor = color;
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
