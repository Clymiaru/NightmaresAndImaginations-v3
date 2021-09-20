using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TDS;

public class HealthBarBehavior : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    StatsComponent stats;
   


    // Start is called before the first frame update
    void Start()
    {
        stats = transform.parent.GetComponent<StatsComponent>();
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }


    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        SetHealth(stats.Health.Value, 10);
    }
}
