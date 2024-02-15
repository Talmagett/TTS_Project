using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        public void PlaySoundOnCamera(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}