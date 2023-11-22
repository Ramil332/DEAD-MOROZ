using UnityEngine;
using UnityEngine.Audio;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets I
    {
        get
        {
            if (_i == null)
                _i = (Instantiate(Resources.Load<GameAssets>("GameAssets")));
            return _i;
        }
    }


    public SoundAudioClip[] SoundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound Sound;
        public AudioClip AudioClip;
        [Range(0, 1)] public float Volume = 1;
        [Range(-3, 3)] public float Pitch;
        [Range(0, 256)] public int Priority;
        public float DestroyTimer = 1f;
        public bool Loop;

    }
}
