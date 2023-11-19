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
        MelleAttack,
        ShootPistol,
        ShootMinigan,
        Exploizion,
        GiveWeapon,
        EnemyAttack,
        EnemyHit,
        EnemyMove,
        EnemyDie,
        SantaAttack,
        SantaMove,
        SantaHoHoHo,
        SantaHit,
        SantaDie,
        Lift,
        CristalDestroy,
        CristalHit,
        MainSound,
        GatesSound,


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
            audioSource.pitch = GetPitchAudio(sound);
            audioSource.priority = GetPriorityAudio(sound);
            audioSource.Play();
            Object.Destroy(soundGameObject, GetDestroyTimeAudio(sound));
        }
    }
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
            //Object.Destroy(soundGameObject, audioSource.clip.length);

        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default: return true;
            case Sound.PlayerMove:
                if (_soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = _soundTimerDictionary[sound];
                    float playMoveTimerMax = 1f;
                    if (lastTimePlayed + playMoveTimerMax < Time.time)
                    {
                        _soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            case Sound.SantaMove:
                if (_soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = _soundTimerDictionary[sound];
                    float playMoveTimerMax = 1f;
                    if (lastTimePlayed + playMoveTimerMax < Time.time)
                    {
                        _soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            case Sound.EnemyMove:
                if (_soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = _soundTimerDictionary[sound];
                    float playMoveTimerMax = 1f;
                    if (lastTimePlayed + playMoveTimerMax < Time.time)
                    {
                        _soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.SoundAudioClipArray)
        {
            if (soundAudioClip.Sound == sound)
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

    private static float GetPitchAudio(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.SoundAudioClipArray)
        {
            if (soundAudioClip.Sound == sound)
            {
                return soundAudioClip.Pitch;
            }

        }

        Debug.LogError("Sound " + sound + " not found!");
        return 0;

    }

    private static int GetPriorityAudio(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.SoundAudioClipArray)
        {
            if (soundAudioClip.Sound == sound)
            {
                return soundAudioClip.Priority;
            }

        }

        Debug.LogError("Sound " + sound + " not found!");
        return 0;

    }

    private static float GetDestroyTimeAudio(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.SoundAudioClipArray)
        {
            if (soundAudioClip.Sound == sound)
            {
                return soundAudioClip.DestroyTimer;
            }

        }

        Debug.LogError("Sound " + sound + " not found!");
        return 0;

    }
}
