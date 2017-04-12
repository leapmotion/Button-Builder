using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using Leap.Unity.UI.Interaction;
using Leap.Unity.GraphicalRenderer;

public class ButtonColorResponse : MonoBehaviour {

  [AutoFind]
  [SerializeField]
  private MainButtonController _controller;

  private CustomVectorChannelData _colorData;
  private InteractionBehaviour _ieBehaviour;
  private InteractionButton _button;
  private InteractionToggle _toggle;

  void Awake() {
    _ieBehaviour = GetComponent<InteractionBehaviour>();
    _button = GetComponent<InteractionButton>();
    _toggle = _button as InteractionToggle;

    _colorData = GetComponent<LeapGraphic>().GetFirstFeatureData<CustomVectorChannelData>();
  }

  void Update() {
    Vector3 targetColor = _controller.baseColor;

    if (_button.isDepressed) {
      targetColor = _controller.pressColor;
    } else if (_toggle != null && _toggle.toggled) {
      targetColor = _controller.toggleColor;
    } else if (_ieBehaviour.isPrimaryHovered) {
      targetColor = _controller.hoverColor;
    }

    _colorData.value = targetColor;
  }

}
