using StarterAssets.Services;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private int speakerId;
    [SerializeField] private string textId;
    private void Awake()
    {
        TestCheck();
    }

    private async void TestCheck()
    {
        await APIService.SendRequest(text, speakerId,textId);

        var response = await FileLoader.LoadFile(textId);
        AudioSource.PlayClipAtPoint(response,Vector3.zero);
    }
}