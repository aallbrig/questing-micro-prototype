using System;
using Interfaces;
using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{
    [Serializable] public class QuestEventUnityEvent : UnityEvent<Quest> {}

    public class QuestEventListener : MonoBehaviour, IOneObjectEventListener<Quest>
    {
        public QuestEvent soEvent;
        public QuestEventUnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);

        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast(Quest quest) => unityEvent.Invoke(quest);
    }
}