using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class QuestLog : MonoBehaviour, IInteractor
    {
        public KeyCode interactKey = KeyCode.E;
        public List<Quest> quests = new List<Quest>();
        public readonly Dictionary<Quest, bool> questStatuses = new Dictionary<Quest, bool>();
        public GameObject hitArea;

        public void InitializeQuestStatuses()
        {
            // Don't override quests
            quests.ForEach(quest =>
            {
                if (!questStatuses.ContainsKey(quest)) questStatuses[quest] = false;
            });
        }

        public void OnQuestInteraction(Quest quest)
        {
            if (!quests.Contains(quest))
            {
                quests.Add(quest);
                questStatuses[quest] = false;
                return;
            }
            if (quests.Contains(quest) && !questStatuses[quest])
            {
                questStatuses[quest] = true;
            }
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

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(interactKey)) Interact();
        }
    }
}