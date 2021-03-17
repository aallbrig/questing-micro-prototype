using Interfaces;
using MonoBehaviours.Spawners;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
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
            var evt = ScriptableObject.CreateInstance<GameObjectEvent>();
            var transform = new GameObject().transform;
            script.parentTransform = transform;
            script.selectedCharacter = selectableCharacterVar;
            script.onSpawn = evt;

            script.Spawn();

            Assert.AreEqual(1, transform.childCount);
        }

        [Test]
        public void Spawner_EmitsEvent_OnSpawn()
        {
            var script = new GameObject().AddComponent<SelectableCharacterSpawner>();
            var selectableCharacter = ScriptableObject.CreateInstance<SelectableCharacter>();
            selectableCharacter.prefab.var = new GameObject();
            var selectableCharacterVar = ScriptableObject.CreateInstance<SelectableCharacterVar>();
            selectableCharacterVar.value = selectableCharacter;
            var transform = new GameObject().transform;
            script.parentTransform = transform;
            script.selectedCharacter = selectableCharacterVar;
            var evt = ScriptableObject.CreateInstance<GameObjectEvent>();
            var evtListener = Substitute.For<IOneObjectEventListener<GameObject>>();
            evt.RegisterListener(evtListener);
            script.onSpawn = evt;

            script.Spawn();

            evtListener.Received().OnEventBroadcast(script.instance);
        }
    }
}