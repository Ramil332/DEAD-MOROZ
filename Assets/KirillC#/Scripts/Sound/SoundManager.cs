using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static SoundAssets;

public static class SoundManager
{

    public enum Sound
    {
        PlayerMove,
        PlayerAttack,
        PlayerDie,
        Shoot,
        Exploizion,
        GiveWeapon,
        EnemyAttack,
        EnemyHit,
        EnemyDie,
        SantaAttack,
        SantaHoHoHo,
        SantaHit,
        SantaDie,

    }

    private static Dictionary<Sound, float> _soundTimerDictionary;

    public static void Initialize()
    {
        _soundTimerDictionary = new Dictionary<Sound, float>();
        _soundTimerDictionary[Sound.PlayerMove] = 0;
    }

    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

            audioSource.clip = GetAudioClip(sound);
            audioSource.maxDistance = 100f;
            audioSource.volume = GetVolumeAudio(sound);
            audioSource.Play();
        }
    }
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }


    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default: return true;
            case Sound.PlayerMove:
                    if(_soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = _soundTimerDictionary[sound];
                    float playMoveTimerMax = 1f;
                    if(lastTimePlayed + playMoveTimerMax < Time.time)
                    {
                        _soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
                //break;
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.SoundAudioClipArray)
        {
            if(soundAudioClip.Sound == sound)
            {
                return soundAudioClip.AudioClip;
            }

        }

        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }

    private static float GetVolumeAudio(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.SoundAudioClipArray)
        {
            if (soundAudioClip.Sound == sound)
            {
                return soundAudioClip.Volume;
            }

        }

        Debug.LogError("Sound " + sound + " not found!");
        return 0;
    }

}