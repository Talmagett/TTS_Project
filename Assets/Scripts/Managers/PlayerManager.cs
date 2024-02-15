using StarterAssets;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private StarterAssetsInputs playerInputs;
        [SerializeField] private FirstPersonController firstPersonController;
        
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