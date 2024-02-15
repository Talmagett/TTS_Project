using Services;
using UnityEngine;
[RequireComponent(typeof(TextToAudio))]

public class TextReplacerBySex : MonoBehaviour
{
    [SerializeField] private string requiredString;
    [SerializeField] private string newStringMale;
    [SerializeField] private string newStringFemale;
    
    private TextToAudio _textToAudio;

    private void Awake()
    {
        _textToAudio = GetComponent<TextToAudio>();
    }

    private void Start()
    {
        _textToAudio.ReplaceText(requiredString, PlayerService.PlayerSex == 2 ? newStringFemale : newStringMale);
    }
}