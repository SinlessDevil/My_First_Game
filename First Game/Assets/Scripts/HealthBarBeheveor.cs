using UnityEngine.UI;
using UnityEngine;

public class HealthBarBeheveor : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color Hight;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, Hight, Slider.normalizedValue);
    }

    void Update()
    {
       Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
