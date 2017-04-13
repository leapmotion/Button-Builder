using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using Leap.Unity.UI.Interaction;
using Leap.Unity.GraphicalRenderer;

public class ButtonEffects : MonoBehaviour {

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

  void OnEnable() {
    if (_button != null) {
      _button.OnPress.AddListener(onPress);
    }

    if (_ieBehaviour != null) {
      _ieBehaviour.OnPrimaryHoverBegin += onPrimaryHover;
      _ieBehaviour.OnObjectContactBegin += onObjectTouchBegin;
      _ieBehaviour.OnObjectContactEnd += onObjectTouchEnd;
    }
  }

  void OnDisable() {
    if (_button != null) {
      _button.OnPress.RemoveListener(onPress);
    }

    if (_ieBehaviour != null) {
      _ieBehaviour.OnPrimaryHoverBegin -= onPrimaryHover;
      _ieBehaviour.OnObjectContactBegin -= onObjectTouchBegin;
      _ieBehaviour.OnObjectContactEnd -= onObjectTouchEnd;
    }
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

  private void onPress() {
    _controller.soundPack.PlayPressSound(transform.position);
  }

  private void onPrimaryHover(List<InteractionHand> hands) {
    _controller.soundPack.PlayHoverSound(transform.position);
  }

  private void onObjectTouchBegin(List<InteractionHand> hands) {
    _controller.soundPack.PlayTouchSound(transform.position);
  }

  private void onObjectTouchEnd(List<InteractionHand> hands) {
    _controller.soundPack.PlayReleaseSound(transform.position);
  }

}
