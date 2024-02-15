using System;
using UnityEngine;

[RequireComponent(typeof(TextToAudio))]
public class TextReplacer : MonoBehaviour
{
    [SerializeField] private string requiredString;
    [SerializeField] private string newString;
    
    private TextToAudio _textToAudio;

    private void Awake()
    {
        _textToAudio = GetComponent<TextToAudio>();
    }

    private void Start()
    {
        _textToAudio.ReplaceText(requiredString,newString);
    }
}