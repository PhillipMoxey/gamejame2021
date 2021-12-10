using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image image;
    public RectTransform button;

    public float healthValue = 0;

    private void Update()
    {
        HealthChange(healthValue);
    }

    void HealthChange(float healthValue)
    {
        float amount = (healthValue / 100.0f) * 180.0f / 360;
        image.fillAmount = amount;
        float buttonAngle = amount * 360;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
    }
}
