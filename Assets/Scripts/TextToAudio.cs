using System;
using Managers;
using Services;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class TextToAudio : MonoBehaviour
{
    [SerializeField] [TextArea] private string text;
    [SerializeField] private bool isPlayer;
    [SerializeField] private int speakerId;
    [SerializeField] private string textId;
    [SerializeField] private bool isLoaded;
    [SerializeField] private bool playAudioOnCamera;
    private AudioSource _audioSource;
    
    private AudioManager _audioManager;
    
    [Inject]
    public void Construct(AudioManager audioManager)
    {
        _audioManager = audioManager;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        text = text.Contains("<player_name>") ? text.Replace("<player_name>", PlayerService.PlayerName) : text;
        speakerId = !isPlayer?speakerId:PlayerService.PlayerSex;
    }

    public void ReplaceText(string required, string newValue)
    {
        text = text.Contains(required) ? text.Replace(required, newValue) : text;
    }
    
    [Button]
    public void PlayAudio()
    {
        LoadAudioAndPlay();
    }

    private async void LoadAudioAndPlay()
    {
        if (!isLoaded)
            await APIService.SendRequest(text, speakerId, textId);

        var clip = await FileLoader.LoadFile(textId);
        if (playAudioOnCamera)
        {
            _audioManager.PlaySoundOnCamera(clip);
        }
        else
        {
            _audioSource.clip=clip;
            _audioSource.Play();
        }
    }
}