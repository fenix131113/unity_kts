using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorKT
{
    [CreateAssetMenu(fileName = "New AudioDataSO", menuName = "SO/EditorKT/AudioDataSO")]
    public class AudioDataSO : ScriptableObject
    {
#if UNITY_EDITOR
        private bool _showList;
        private bool _showLabel;
#endif
        [SerializeField] [TextArea] private string message;
        [SerializeField] private List<AudioDataList> audioData = new();
        [SerializeField] private string id;
        [SerializeField] private AudioType audioType;
    }

    [Serializable]
    public class AudioDataList
    {
        [field: SerializeField] public string TypeName { get; private set; }
        [field: SerializeField] public List<AudioData> Data { get; private set; } = new();
        
        public AudioDataList(string typeName)
        {
            TypeName = typeName;
        }
    }
    
    [Serializable]
    public class AudioData
    {
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; }

        public AudioData(AudioClip clip, float volume)
        {
            Clip = clip;
            Volume = volume;
        }

        public void SetClip(AudioClip newClip) => Clip = newClip;
        public void SetVolume(float newVolume) => Volume = newVolume;
    }

    public enum AudioType
    {
        DANGEROUS = 0,
        FRIENDLY = 1,
        NEUTRAL = 2,
        TEST = 3
    }
}