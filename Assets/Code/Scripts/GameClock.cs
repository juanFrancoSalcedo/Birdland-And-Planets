using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    public float gameSpeed = 2f; // 2x velocidad: 1 hora real = 2 horas de juego
    private float currentTime = 0f;
    private int currentHour = 8; 
    private int currentMinute = 0;
    public event Action OnHourPass;

    void Start() => UpdateClockDisplay();

    void Update()
    {
        currentTime += Time.deltaTime * gameSpeed;

        if (currentTime >= 60f)
        {
            currentTime = 0f;
            currentMinute++;
            if (currentMinute >= 60)
            {
                currentMinute = 0;
                currentHour++;
                OnHourPass?.Invoke();
                if (currentHour >= 24)
                {
                    currentHour = 0; // Reiniciar a medianoche
                }
            }
            UpdateClockDisplay();
        }
    }

    void UpdateClockDisplay()
    {
        clockText.text = $"{currentHour:D2}:{currentMinute:D2}";
    }
}