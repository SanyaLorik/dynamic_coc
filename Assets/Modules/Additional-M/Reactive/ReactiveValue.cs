using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public class ReactiveValue<T>
    {
        [SerializeField] private T _value;

        public event Action<T> OnChanged;

        public ReactiveValue(T value)
        {
            _value = value;
        }

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}
