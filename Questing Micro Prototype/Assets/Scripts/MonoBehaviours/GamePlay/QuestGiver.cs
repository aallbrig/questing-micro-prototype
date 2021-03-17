using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestGiver : MonoBehaviour
    {
        public QuestEvent addQuestEvent;
        public QuestEvent completeQuestEvent;
        public Quest quest;

        public void AddQuest() => addQuestEvent.Broadcast(quest);
        public void CompleteQuest() => completeQuestEvent.Broadcast(quest);
    }
}