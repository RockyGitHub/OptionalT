using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyInvokeEvent : MonoBehaviour
{
    public event Action OnBeingDestroyed;

    private void OnDestroy()
    {
        OnBeingDestroyed?.Invoke();
    }
}