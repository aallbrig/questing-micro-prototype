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
        public void QuestGiver_Can_BroadcastWhenInteraction()
        {
            var script = new GameObject().AddComponent<QuestGiver>();
            var evt = Substitute.For<QuestEvent>();
            var quest = Substitute.For<Quest>();
            script.questInteraction = evt;
            script.quest = quest;

            script.Interaction();

            evt.Received().Broadcast(quest);
        }
    }
}