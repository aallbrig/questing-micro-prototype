﻿using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using ScriptableObjects.RuntimeDictionaries;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestLog : MonoBehaviour, IInteractor
    {
        public KeyCode interactKey = KeyCode.E;
        public List<Quest> quests = new List<Quest>();
        public GameObject hitArea;
        public QuestStatuses questStatuses;
        public QuestEvent acceptedQuest;
        public QuestEvent completedQuest;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(interactKey)) Interact();
        }
        private void OnEnable() => InitializeQuestStatuses();
        public void Interact()
        {
            var colliderSize = Vector3.one;
            var collisions = Physics.OverlapBox(hitArea.transform.position, colliderSize);
            foreach (var collision in collisions)
                if (collision.TryGetComponent<IInteractable>(out var interactable))
                    interactable.Interaction();
        }

        public void InitializeQuestStatuses() =>
            // Don't override quests
            quests.ForEach(quest =>
            {
                if (!questStatuses.dictionary.ContainsKey(quest)) questStatuses.dictionary[quest] = false;
            });

        public void OnQuestInteraction(Quest quest)
        {
            if (!quests.Contains(quest))
            {
                quests.Add(quest);
                questStatuses.dictionary[quest] = false;
                if (acceptedQuest != null) acceptedQuest.Broadcast(quest);
                return;
            }
            if (quests.Contains(quest) && !questStatuses.dictionary[quest])
            {
                questStatuses.dictionary[quest] = true;
                if (completedQuest != null) completedQuest.Broadcast(quest);
            }
        }
    }
}