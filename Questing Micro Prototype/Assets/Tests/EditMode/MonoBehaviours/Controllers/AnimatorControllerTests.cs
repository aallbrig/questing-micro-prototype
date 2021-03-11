using MonoBehaviours.Controllers;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class AnimatorControllerTests
    {
        [Test]
        public void Animator_Receives_VelocityInfo()
        {
            var script = new GameObject().AddComponent<CharacterAnimatorController>();
        }
    }
}