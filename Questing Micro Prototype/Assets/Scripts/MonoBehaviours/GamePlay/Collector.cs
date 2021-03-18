using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class Collector<T> : MonoBehaviour
    {
        public List<T> collection = new List<T>();
    }
}