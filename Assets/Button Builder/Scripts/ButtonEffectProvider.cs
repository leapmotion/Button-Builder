using System;
using UnityEngine;

public abstract class ButtonEffectProvider : MonoBehaviour {

  public abstract Vector3 baseColor { get; }
  public abstract Vector3 hoverColor { get; }
  public abstract Vector3 pressColor { get; }
  public abstract Vector3 toggleColor { get; }

  public abstract SoundPack soundPack { get; }

  [Serializable]
  public class SoundPack {
    [SerializeField]
    private AudioClip _hoverSound;

    [Range(0, 1)]
    [SerializeField]
    private float _hoverVolume = 1;

    [SerializeField]
    private AudioClip _touchSound;

    [Range(0, 1)]
    [SerializeField]
    private float _touchVolume = 1;

    [SerializeField]
    private AudioClip _pressSound;

    [Range(0, 1)]
    [SerializeField]
    private float _pressVolume = 1;

    [SerializeField]
    private AudioClip _releaseSound;

    [Range(0, 1)]
    [SerializeField]
    private float _releaseVolume = 1;

    public void PlayHoverSound(Vector3 position) {
      playSound(_hoverSound, _hoverVolume, position);
    }

    public void PlayTouchSound(Vector3 position) {
      playSound(_touchSound, _touchVolume, position);
    }

    public void PlayPressSound(Vector3 position) {
      playSound(_pressSound, _pressVolume, position);
    }

    public void PlayReleaseSound(Vector3 position) {
      playSound(_releaseSound, _releaseVolume, position);
    }

    private void playSound(AudioClip clip, float volume, Vector3 position) {
      if (clip != null) {
        AudioSource.PlayClipAtPoint(clip, position, volume);
      }
    }
  }
}
