using NUnit.Framework;
using ScriptableObjects.GamePlay;
using ScriptableObjects.Refs;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.GamePlay
{
    public class QuestTests
    {
        [Test]
        public void Quest_IntroText_CanAdd()
        {
            var quest = ScriptableObject.CreateInstance<Quest>();

            quest.introText.Add(new StringRef());

            Assert.AreEqual(1, quest.introText.Count);
        }
    }
}