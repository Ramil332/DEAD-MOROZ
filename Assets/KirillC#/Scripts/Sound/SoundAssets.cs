using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    /* private static SoundAssets _i;

     public static SoundAssets i 
     { get  {
             if (_i == null) _i = Instantiate(Resources.Load<SoundAssets>("SoundAssets"));
             return _i;
         } 
     }*/

    public static SoundAssets i = null;

    private void Awake()
    {
        if (i == null)
            i = this;

        SoundManager.Initialize();
    }
    public SoundAudioClip[] SoundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound Sound;
        public AudioClip AudioClip;
        [Range(0, 1)] public float Volume;
        [Range(-3, 3)] public float Pitch;
    }
}
