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
public class LeapToggleGroup : MonoBehaviour {
  InteractionToggle[] toggles;

  void Start() {
    toggles = GetComponentsInChildren<InteractionToggle>();
  }

  void Update() {
    int toggleIndex = -1;
    for (int i = 0; i < toggles.Length; i++) {
      if (toggles[i].depressedThisFrame){
        if (toggles[i].toggled) {
          toggleIndex = i;
          for (int j = 0; j < toggles.Length; j++) {
            if (j != toggleIndex && toggles[j].toggled) {
              toggles[j].toggled = false;
            }
          }
          break;
        } else {
          toggles[i].toggled = true;
          break;
        }
      }
    }
  }
}
