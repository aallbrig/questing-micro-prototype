using System;
using System.Collections.Generic;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestLog : MonoBehaviour
    {
        public List<Quest> quests = new List<Quest>();
        public readonly Dictionary<Quest, bool> questStatuses = new Dictionary<Quest, bool>();

        public void InitializeQuestStatuses()
        {
            // Don't override quests
            quests.ForEach(quest =>
            {
                if (!questStatuses.ContainsKey(quest)) questStatuses[quest] = false;
            });
        }

        public void CompleteQuest(Quest quest) => questStatuses[quest] = true;
        public void AddQuest(Quest quest) => questStatuses[quest] = false;
        private void OnEnable() => InitializeQuestStatuses();
    }
}