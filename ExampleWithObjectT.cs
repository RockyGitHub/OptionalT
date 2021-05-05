using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleWithObjectT : MonoBehaviour
{
    public OptionalObject<GameObject> exampleObject;

    private void Awake()
    {
        if (exampleObject.Enabled)
            exampleObject.Initialize();
    }
}