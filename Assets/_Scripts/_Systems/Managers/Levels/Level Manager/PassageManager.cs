using UnityEngine;

namespace Root.Systems.Levels
{
    public class PassageManager : MonoBehaviour
    {
        public static PassageManager instance;

        public SceneHandle sceneHandle;

        public PassageController[] passages;

        private void Awake()
        {
            if (instance == null) instance = this; else Destroy(this);
        }

        public void LoadLevel(PassageController controller)
        {
            if (controller == null) return;

            PassageHandle passageHandle = sceneHandle.passages[controller.id];

            if (passageHandle == null) return;

            LevelManager.instance.LoadLevel(passageHandle);
        }
    }
}