using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private AudioManager audioManager;
        
        public override void InstallBindings()
        {
            Container.BindInstance(playerManager).AsSingle();
            Container.BindInstance(audioManager).AsSingle();
        }
    }
}