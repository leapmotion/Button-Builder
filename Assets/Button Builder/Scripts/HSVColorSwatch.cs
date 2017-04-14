using UnityEngine;
using UnityEngine.Events;
using Leap.Unity.UI.Interaction;
using Leap.Unity.GraphicalRenderer;
[RequireComponent(typeof(CustomVectorChannelData))]
public class HSVColorSwatch : MonoBehaviour {

  public ButtonColorsConfiguration colors;

  public InteractionSlider hSlider;
  public InteractionSlider sVSlider;

  [System.Serializable]
  public class ColorEvent : UnityEvent<Color> { }
  ///<summary> Converts slider values to a Vector3 for color setting. </summary>
  public ColorEvent GraphicColorEvent = new ColorEvent();

  private CustomVectorChannelData swatchColor;

  public void Start() {
    swatchColor = GetComponent<CustomVectorChannelData>();
    resetColor();
  }

  public void UpdateColor() {
    swatchColor.value = new Vector3(hSlider.VerticalSliderValue, 1f, 1f);
    Color color = new Vector3(hSlider.VerticalSliderValue, sVSlider.HorizontalSliderValue, sVSlider.VerticalSliderValue).HSVtoRGB();
    GraphicColorEvent.Invoke(color);
  }

  public void resetColor() {
    Vector3 HSV = colors.getCurrentModeColor().ToHSV();
    hSlider.VerticalSliderValue = HSV.x;
    sVSlider.HorizontalSliderValue = HSV.y;
    sVSlider.VerticalSliderValue = HSV.z;

    swatchColor.value = new Vector3(hSlider.VerticalSliderValue, 1f, 1f);
  }
}
