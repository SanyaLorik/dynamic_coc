using System;
using System.Collections.Generic;

namespace _KotletaGames.Additional_M
{
    public class PushingArray<T>
    {
        private T[] _array;
        private int _capacity;
        private int _original;

        public PushingArray(int capacity)
        {
            _capacity = capacity;
            _original = 0;

            _array = new T[_capacity];
        }

        public T this[int index]
        {
            get
            {
                //Assert.IsFalse(index >= _original, "This is not valid index!");
                return _array[index]; 
            }
            set
            {
                //Assert.IsFalse(index >= _original, "This is not valid index!");
                _array[index] = value;
            }
        }

        public int Lenght => _original;

        public void Add(T value)
        {
           // Assert.IsFalse(_capacity <= _original, "Overhead!");

            _array[_original] = value;
            _original++;
        }

        public void Add(IEnumerable<T> values)
        {
            foreach (var value in values)
                Add(value);
        }

        public void Reset()
        {
            _original = 0;
        }

        public T[] GetArray()
        {
            if (_original == 0)
                return Array.Empty<T>();

            return _array[0.._original];
        }
    }
}