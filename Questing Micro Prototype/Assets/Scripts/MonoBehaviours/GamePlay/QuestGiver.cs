using Interfaces;
using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestGiver : MonoBehaviour, IInteractable
    {
        public QuestEvent questInteraction;
        public Quest quest;

        public void Interaction() => questInteraction.Broadcast(quest);
    }
}