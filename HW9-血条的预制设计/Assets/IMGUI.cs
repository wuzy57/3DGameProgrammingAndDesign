using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IMGUI : MonoBehaviour
{
    private float hSliderValue = 100f;
    private void OnGUI()
    {
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        hSliderValue = GUI.HorizontalSlider(new Rect(screenPos.x - 100, screenPos.y, 100, 100), hSliderValue, 0.0f, 100.0f);
    }
}