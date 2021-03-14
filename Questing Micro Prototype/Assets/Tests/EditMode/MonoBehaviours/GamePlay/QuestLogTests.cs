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
        public void QuestLog_Can_AddQuest()
        {
            var script = new GameObject().AddComponent<QuestLog>();
            var quest = Substitute.For<Quest>();
            
            script.AddQuest(quest);

            Assert.AreEqual(1, script.questStatuses.Count);
        }

        [Test]
        public void QuestLog_Can_CompleteQuest()
        {
            var script = new GameObject().AddComponent<QuestLog>();
            var quest = Substitute.For<Quest>();
            script.quests.Add(quest);
            script.InitializeQuestStatuses();
            
            script.CompleteQuest(quest);

            Assert.IsTrue(script.questStatuses[quest]);
        }
    }
}