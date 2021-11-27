using UnityEngine;

namespace Yamara.Audio
{
    //[CreateAssetMenu(menuName = "ScriptableObjects/Create SEManagerSettings")]
    public class SEManagerSettings : ScriptableObject
    {
        [SerializeField] int audioSourceCount = 8;
        public int AudioSourceCount { get { return audioSourceCount; } }
    }
}