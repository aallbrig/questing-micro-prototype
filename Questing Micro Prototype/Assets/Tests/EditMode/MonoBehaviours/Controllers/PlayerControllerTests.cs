using MonoBehaviours.Controllers;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class PlayerControllerTests
    {
        [Test] public void ScriptExists() => Assert.NotNull(new GameObject().AddComponent<PlayerController>());
    }
}