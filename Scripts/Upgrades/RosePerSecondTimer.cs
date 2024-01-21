using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosePerSecondTimer : MonoBehaviour
{
    public float TimerDuration = 1f;

    public double RosePerSecond { get; set;}

    private float _counter;

    private void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= TimerDuration)
        {
            RoseManager.instance.SimpleRoseIncrease(RosePerSecond);

            _counter = 0;
        }
    }
}
