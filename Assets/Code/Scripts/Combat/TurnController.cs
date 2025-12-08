using System;
using TMPro;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TMP_Text _textTimer;
    private void OnEnable()
    {
        _timer.OnUpdateTime += DrawTime;
        _timer.OnTimeCompleted += EndsTurn;
    }

    private void OnDisable()
    {
        _timer.OnUpdateTime -= DrawTime;
        _timer.OnTimeCompleted -= EndsTurn;
    }
    private void DrawTime(string obj)
    {
        _textTimer.text = obj;
    }
    private void EndsTurn()
    {

    }
}
