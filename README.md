A class inspired by aarthificial's video on the Optional pattern in struct form: https://www.youtube.com/watch?v=uZmWgQ7cLNI

With this class, you can check for `Enabled` in an `Update()` loop or whatever you want to effectively test for `GameObject == null`, because Enabled will be set to false when the GameObject is destroyed

This relies on calling `Initialize()` on the Optional object to setup the OnDestroy callback..

```cs
    public class OnDestroyInvokeEvent : MonoBehaviour
    {
        public event Action OnBeingDestroyed;

        private void OnDestroy()
        {
            OnBeingDestroyed?.Invoke();
        }
    }
```

Otherwise, this is what the `OptionalObject` Looks like.

```
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
```

