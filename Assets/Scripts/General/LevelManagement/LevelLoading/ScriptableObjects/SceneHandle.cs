using System.Collections.Generic;

using UnityEngine;

namespace LevelLoading.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSceneHandle", menuName = "Scriptable Objects/Scene Handle")]
    public class SceneHandle : ScriptableObject
    {
        public Object scene;

        [SerializeField] private List<PassageHandle> passageList = new List<PassageHandle>();
        public List<PassageHandle> passages { get => passageList; set => passageList = value; }
    }
}