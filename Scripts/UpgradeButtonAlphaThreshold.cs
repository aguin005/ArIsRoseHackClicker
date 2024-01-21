using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonAlphaThreshold : MonoBehaviour
{
    private Image _buttonImage;

  private void Awake()
  {
    _buttonImage = GetComponent<Image>();
    _buttonImage.alphaHitTestMinimumThreshold = 0.001f;
  }
}
