using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services
{
    public static class FileLoader
    {
        private static string PathData=>"Assets/Resources/Audio/";

        public static string GetPath(string fileName)
        {
            return PathData + fileName + ".wav";
        }

        public static async UniTask<AudioClip> LoadFile(string fileName)
        {
            var cts = new CancellationTokenSource();
            string path = GetPath(fileName);
            string absolutePath = Path.Combine(Application.dataPath, path);
            await UniTask.WaitUntil(()=>!File.Exists(absolutePath),cancellationToken:cts.Token);
            var asset = await Resources.LoadAsync<AudioClip>($"Audio/{fileName}").WithCancellation(cts.Token);
            return (AudioClip)asset;
        }
    }
}