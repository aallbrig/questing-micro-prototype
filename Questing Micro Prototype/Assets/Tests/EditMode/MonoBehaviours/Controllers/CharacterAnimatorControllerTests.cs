using MonoBehaviours.Controllers;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class CharacterAnimatorControllerTests
    {
        [Test]
        public void Script_Exists()
        {
            var script = new GameObject().AddComponent<CharacterAnimatorController>();
            Assert.NotNull(script);
        }
    }
}