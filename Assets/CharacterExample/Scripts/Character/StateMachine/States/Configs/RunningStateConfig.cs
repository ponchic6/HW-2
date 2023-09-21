using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 10)] private float _slowRunSpeed;
    [SerializeField, Range(0, 10)] private float _fastRunSpeed;

    public float SlowRunSpeed => _slowRunSpeed;
    public float FastRunSpeed => _fastRunSpeed;
}
