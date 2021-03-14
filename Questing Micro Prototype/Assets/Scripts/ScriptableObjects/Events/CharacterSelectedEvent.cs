using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New character selected event", menuName = "CSS/CharacterSelectedEvent", order = 0)]
    public class CharacterSelectedEvent : ScriptableObject
    {
        private readonly List<IOneObjectEventListener<SelectableCharacter.SelectableCharacter>> _listeners =
            new List<IOneObjectEventListener<SelectableCharacter.SelectableCharacter>>();

        public void Broadcast(SelectableCharacter.SelectableCharacter character)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast(character);
        }

        public void RegisterListener(IOneObjectEventListener<SelectableCharacter.SelectableCharacter> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IOneObjectEventListener<SelectableCharacter.SelectableCharacter> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}