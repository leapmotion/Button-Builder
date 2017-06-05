/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2017.                                 *
 * Leap Motion proprietary and  confidential.                                 *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using Leap.Unity.Interaction;

public class ToggleConfigurer : MonoBehaviour {
  InteractionButton button;
  InteractionToggle toggle;

	void Start () {
    button = GetComponent<InteractionButton>();
    toggle = GetComponent<InteractionToggle>();
  }
	
	public void setToggleActive(InteractionSlider slider) {
    bool activateButton = slider.HorizontalSliderPercent < 0.5f;

    //Order is important here, don't try to be clever
    if (activateButton) {
      toggle.enabled = false;
      button.enabled = true;
    } else {
      button.enabled = false;
      toggle.enabled = true;
    }
  }
}
