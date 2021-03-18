using Interfaces;
using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestGiver : MonoBehaviour, IInteractable
    {
        public Quest quest;
        public QuestEvent questInteraction;

        public void Interaction()
        {
            if (quest != null && quest.ready) questInteraction.Broadcast(quest);
        }

        public void Setup() => quest.Setup(gameObject);

        public void Reset() => quest.Reset();
    }
}