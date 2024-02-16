using System;
using Services;
using StarterAssets;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private StarterAssetsInputs playerInputs;
        [SerializeField] private FirstPersonController firstPersonController;
        [SerializeField] private GameObject male;
        [SerializeField] private GameObject female;

        private void Awake()
        {
            male.SetActive(PlayerService.PlayerSex==1);
            female.SetActive(PlayerService.PlayerSex==2);
        }

        public void SetUnlockCameraControl(bool value)
        {
            playerInputs.cursorLocked = value;
            playerInputs.cursorInputForLook = value;
        }

        public void SetUnlockMovementControl(bool value)
        {
            firstPersonController.enabled = value;
        }
    }
}