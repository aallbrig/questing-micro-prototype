using MonoBehaviours.GamePlay;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using ScriptableObjects.GamePlay;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.GamePlay
{
    public class QuestGiverTests
    {

        [Test]
        public void QuestGiver_Can_BroadcastQuestAdd()
        {
            var script = new GameObject().AddComponent<QuestGiver>();
            var evt = Substitute.For<QuestEvent>();
            var quest = Substitute.For<Quest>();
            script.addQuestEvent = evt;
            script.quest = quest;

            script.AddQuest();
            
            evt.Received().Broadcast(quest);
        }

        [Test]
        public void QuestGiver_Can_BroadcastQuestComplete()
        {
            var script = new GameObject().AddComponent<QuestGiver>();
            var evt = Substitute.For<QuestEvent>();
            var quest = Substitute.For<Quest>();
            script.completeQuestEvent = evt;
            script.quest = quest;

            script.CompleteQuest();
            
            evt.Received().Broadcast(quest);
        }
    }
}