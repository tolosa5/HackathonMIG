using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.EventSystem.Channels
{
    public abstract class EventChannel<T> : ScriptableObject
    {
        private readonly HashSet<Action<T>> observers = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Notify(T value = default)
        {
            foreach (var observer in observers)
            {
                observer?.Invoke(value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Register(Action<T> observer)
        {
            observers.Add(observer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Unregister(Action<T> observer)
        {
            observers.Remove(observer);
        }
    }
}