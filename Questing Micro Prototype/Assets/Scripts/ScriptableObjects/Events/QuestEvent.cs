using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New quest event", menuName = "QST/QuestEvent", order = 0)]
    public class QuestEvent : ScriptableObject
    {
        private readonly List<IOneObjectEventListener<Quest>> _listeners = new List<IOneObjectEventListener<Quest>>();

        public void Broadcast(Quest quest)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast(quest);
        }

        public void RegisterListener(IOneObjectEventListener<Quest> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IOneObjectEventListener<Quest> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}