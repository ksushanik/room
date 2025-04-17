using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light lightComponent;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 1.5f;
    [SerializeField] private float flickerSpeed = 0.1f;
    [SerializeField] private bool isFlickering = false;
    [SerializeField] private Color lightColor = Color.yellow;

    private float baseIntensity;
    private float randomValue;

    private void Start()
    {
        // Получаем компонент Light, если он не был задан в инспекторе
        if (lightComponent == null)
        {
            lightComponent = GetComponent<Light>();
            if (lightComponent == null)
            {
                lightComponent = gameObject.AddComponent<Light>();
                lightComponent.type = LightType.Point;
            }
        }

        // Настраиваем свет
        baseIntensity = (minIntensity + maxIntensity) / 2;
        lightComponent.color = lightColor;
        lightComponent.intensity = baseIntensity;

        if (isFlickering)
        {
            InvokeRepeating("Flicker", 0, flickerSpeed);
        }
    }

    private void Flicker()
    {
        randomValue = Random.Range(minIntensity, maxIntensity);
        lightComponent.intensity = randomValue;
    }

    // Методы для управления светом из других скриптов
    public void TurnOn()
    {
        lightComponent.enabled = true;
    }

    public void TurnOff()
    {
        lightComponent.enabled = false;
    }

    public void SetIntensity(float intensity)
    {
        lightComponent.intensity = intensity;
    }

    public void SetColor(Color color)
    {
        lightComponent.color = color;
    }
} 