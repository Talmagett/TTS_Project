using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using StarterAssets.Services;
using UnityEngine.Networking;

public static class APIService
{
    #region Classes
    [System.Serializable]
    public class RequestResult
    {
        public string Code;
    }

    #endregion

    private static string HostPortAddress { get;} = "tts.ulut.kg";
    private static string URL => "http://" + HostPortAddress + "/api/tts";
    private static string Token => "Eq8qQ6gGbObBcVTpmEoqPpy776i93ZtFfqKM8LZzlFZmg7HU6fIdUT87fmXs7R82";
    
    public class Content
    {
        public string text;
        public int speaker_id;
    }
    
    private static string MakeJson(string text, int speakerId)
    {
        return JsonConvert.SerializeObject(new Content { text = text, speaker_id = speakerId });
    }
    
    public static async UniTask<RequestResult> SendRequest(string text, int speakerId,string fileName)
    {
        var uwr = new UnityWebRequest(URL, "POST");

        string json = MakeJson(text, speakerId);
        
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);

        string path = FileLoader.GetPath(fileName);
        
        DownloadHandlerFile downloadHandlerFile = new DownloadHandlerFile(path);
        uwr.downloadHandler = downloadHandlerFile;

        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("Authorization", "Bearer " + Token);

        var cts = new CancellationTokenSource();
        var operation = uwr.SendWebRequest();
        try
        {
            await operation.WithCancellation(cts.Token);
        }
        catch
        {
            if (uwr.result == UnityWebRequest.Result.ConnectionError)
                Debug.Log("No connection");
        }

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            throw new Exception("No success");
        }
        
        string code = uwr.responseCode.ToString();
        
        uwr.uploadHandler.Dispose();
        uwr.downloadHandler?.Dispose();
        uwr.Dispose();

        if (code == "0")
            return null;

        UnityEditor.AssetDatabase.Refresh();
        
        var returningData = new RequestResult
        {
            Code = code,
        };
        
        return returningData;
    }
}