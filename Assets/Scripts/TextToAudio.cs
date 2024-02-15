using Services;
using Sirenix.OdinInspector;
using UnityEngine;

public class TextToAudio : MonoBehaviour
{
    [SerializeField, TextArea] private string text;
    [SerializeField] private int speakerId;
    [SerializeField] private string textId;
    [SerializeField] private bool isLoaded;
    
    [Button]
    public void CreateTest()
    {
        TestCheck();
    }

    private async void TestCheck()
    {
        if(!isLoaded)
            await APIService.SendRequest(text, speakerId,textId);

        var response = await FileLoader.LoadFile(textId);
        AudioSource.PlayClipAtPoint(response,Vector3.zero);
    }
}