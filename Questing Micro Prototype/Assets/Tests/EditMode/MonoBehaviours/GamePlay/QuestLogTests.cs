using Interfaces;
using MonoBehaviours.GamePlay;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.GamePlay
{
    public class QuestLogTests
    {
        [Test]
        public void QuestLog_ListOfQuests_TurnedIntoQuestStatus()
        {
            var script = new GameObject().AddComponent<QuestLog>();
            var quest = Substitute.For<Quest>();
            script.quests.Add(quest);

            script.InitializeQuestStatuses();

            Assert.AreEqual(1, script.questStatuses.Count);
        }

        [Test]
        public void QuestLog_Can_InteractWithQuest()
        {
            var script = new GameObject().AddComponent<QuestLog>();
            var quest = Substitute.For<Quest>();
            
            script.OnQuestInteraction(quest);

            Assert.AreEqual(1, script.questStatuses.Count);
        }

        [Test]
        public void QuestLog_Can_CompleteQuest()
        {
            var script = new GameObject().AddComponent<QuestLog>();
            var quest = Substitute.For<Quest>();
            script.quests.Add(quest);
            script.InitializeQuestStatuses();
            
            script.OnQuestInteraction(quest);
            script.OnQuestInteraction(quest);

            Assert.IsTrue(script.questStatuses[quest]);
        }

        [Test]
        public void QuestLog_Player_CanInteractWithQuestGivers()
        {
            var script = new GameObject().AddComponent<QuestLog>();
            var hitArea = new GameObject();
            var interactable = Substitute.For<IInteractable>();
            hitArea.AddComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            script.hitArea = hitArea;

            script.Interact();
            
            
        }
    }
}