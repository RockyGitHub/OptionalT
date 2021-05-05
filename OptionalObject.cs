using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OptionalObject<T>
{
    [SerializeField] private bool _enabled;
    [SerializeField] private T _value;

    public bool Enabled => _enabled; // came as "public bool Enabled => enabled"
    public T Value => _value;

    public OptionalObject(T initialValue)
    {
        _enabled = true;
        _value = initialValue;

        Initialize();
    }

    public void Initialize()
    {
        if (_value is GameObject go)
        {
            var destroyEvent = go.AddComponent<OnDestroyInvokeEvent>();
            destroyEvent.OnBeingDestroyed += () => _enabled = false;
        }
        else if (_value is Component co)
        {
            var destroyEvent = co.gameObject.AddComponent<OnDestroyInvokeEvent>();
            destroyEvent.OnBeingDestroyed += () => _enabled = false;
        }
    }
}
