using ScriptableObjects.GamePlay;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestChain : MonoBehaviour
    {
        public Quest requiredCompletedQuest;
        private QuestGiver _questGiver;

        public void OnQuestComplete(Quest completedQuest)
        {
            if (requiredCompletedQuest == completedQuest)
                _questGiver.Setup();
        }

        private void OnEnable()
        {
            _questGiver = GetComponent<QuestGiver>();
        }
    }
}