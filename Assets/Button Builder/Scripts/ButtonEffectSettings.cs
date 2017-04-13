using UnityEngine;

public class ButtonEffectSettings : ButtonEffectProvider {

  [SerializeField]
  private Color _baseColor;

  [SerializeField]
  private Color _hoverColor;

  [SerializeField]
  private Color _pressColor;

  [SerializeField]
  private Color _toggleColor;

  [SerializeField]
  private SoundPack _soundPack;

  public override Vector3 baseColor {
    get {
      return _baseColor.ToHSV();
    }
  }

  public override Vector3 hoverColor {
    get {
      return _hoverColor.ToHSV();
    }
  }

  public override Vector3 pressColor {
    get {
      return _pressColor.ToHSV();
    }
  }

  public override Vector3 toggleColor {
    get {
      return _toggleColor.ToHSV();
    }
  }

  public override SoundPack soundPack {
    get {
      return _soundPack;
    }
  }
}
