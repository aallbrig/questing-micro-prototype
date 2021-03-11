using MonoBehaviours.Spawners;
using NUnit.Framework;
using ScriptableObjects.SelectableCharacter;
using ScriptableObjects.Vars;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Spawners
{
    public class SingleInstanceSpawnerTests
    {
        [Test]
        public void Spawner_CanSpawnSingleInstance_NoPreviousInstance()
        {
            var script = new GameObject().AddComponent<SelectableCharacterSpawner>();
            var selectableCharacter = ScriptableObject.CreateInstance<SelectableCharacter>();
            selectableCharacter.prefab.var = new GameObject();
            var selectableCharacterVar = ScriptableObject.CreateInstance<SelectableCharacterVar>();
            selectableCharacterVar.value = selectableCharacter;
            var transform = new GameObject().transform;
            script.parentTransform = transform;
            script.selectedCharacter = selectableCharacterVar;

            script.Spawn();

            Assert.AreEqual(1, transform.childCount);
        }
    }
}