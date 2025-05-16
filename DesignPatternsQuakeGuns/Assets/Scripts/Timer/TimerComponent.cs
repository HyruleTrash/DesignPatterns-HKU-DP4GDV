using System;
using LucasCustomClasses;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TimerComponent : MonoBehaviour
{
    private double _currentTime = 0;
    public float maxTime = 0;
    public UnityEvent timerFinished = new UnityEvent();
    private System.Action _onEnd;
    private Timer _timer;

    private void OnEnable()
    {
        _onEnd = OnTimerFinished;
        _timer = new Timer(maxTime, _onEnd);
        _timer.onPlaying += UpdateCurrentTime;
    }

    public void Reset()
    {
        _timer.Reset();
    }

    private void OnTimerFinished()
    {
        timerFinished.Invoke();
        enabled = false;
    }

    private void Update()
    {
        if (enabled)
        {
            _timer.Update(Time.deltaTime);
        }
    }

    public void UpdateCurrentTime(double time)
    {
        _currentTime = time;
    }
    
    public double GetCurrentTime()
    {
        return _currentTime;
    }
        
    /// <summary>
    /// Gets the current time, as a value between 0 and 1
    /// </summary>
    /// <returns>a value between 0 and 1, a percentage along max time</returns>
    public float GetCurrentTimeAsPercentage()
    {
        float percentage = (maxTime / 100) * (float)_currentTime;
        return percentage;
    }
}
