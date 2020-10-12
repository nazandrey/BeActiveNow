using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : SingletonDestroyable<AudioManager>
{
    [SerializeField]
    private AudioSource music;
    
    [SerializeField]
    private AudioSource welcomeAudio;
    
    [SerializeField]
    private AudioSource startLevelAudio;

    [SerializeField]
    private List<AudioSource> gameSounds;

    private void Start()
    {
        PlayMusic();
    }

    public void PlayWelcomeAudio()
    {
        if (welcomeAudio != null) 
            welcomeAudio.Play();
    }
    
    public void PlayMusic()
    {
        if (music != null) 
            music.Play();
    }

    public void PlayStartLevelAudio()
    {
        if (startLevelAudio != null) 
            startLevelAudio.Play();
    }

    private float StartAudioCoroutine(AudioSource[] audios)
    {
        var audio = audios[UnityEngine.Random.Range(0, audios.Length)];
        StartCoroutine(PlayOneShotCoroutine(audio));
        return audio.clip.length;
    }

    public void Play(string soundName)
    {
        var sound = gameSounds.FirstOrDefault(gameSound => gameSound.name == soundName);
        if (sound == null)
        {
            Debug.LogWarning($"Звук с наименованием {soundName} не найден");
            return;
        }
        StartCoroutine(PlayOneShotCoroutine(sound));
    }

    private IEnumerator PlayOneShotCoroutine(AudioSource sound)
    {
        sound.PlayOneShot(sound.clip);
        yield return new WaitForSeconds(sound.clip.length);
    }
}
