using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoseAlphaThreshold : MonoBehaviour
{
  private Image _roseImage;

  private void Awake()
  {
    _roseImage = GetComponent<Image>();
    _roseImage.alphaHitTestMinimumThreshold = 0.001f;
  }
}
