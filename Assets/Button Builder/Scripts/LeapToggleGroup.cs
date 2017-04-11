using UnityEngine;
using Leap.Unity.UI.Interaction;
public class LeapToggleGroup : MonoBehaviour {
  InteractionToggle[] toggles;

  void Start() {
    toggles = GetComponentsInChildren<InteractionToggle>();
  }

  void Update() {
    int toggleIndex = -1;
    for (int i = 0; i < toggles.Length; i++) {
      if (toggles[i].depressedThisFrame) {
        toggleIndex = i;
        break;
      }
    }

    bool anyUntoggled = false;
    if (toggleIndex != -1) {
      for (int i = 0; i < toggles.Length; i++) {
        if (i != toggleIndex && toggles[i].toggled) {
          toggles[i].toggled = false;
          anyUntoggled = true;
        }
      }

      if (anyUntoggled == false) {
        toggles[toggleIndex].toggled = true;
      }
    }
  }
}