using System;
using Managers;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private Button male;
    [SerializeField] private Button female;
    [SerializeField] private GameObject[] activateObjects;
    
    private bool _isMale = true;
    private PlayerManager _playerManager;
    
    [Inject]
    public void Construct(PlayerManager playerManager)
    {
        _playerManager = playerManager;
    }

    private void Awake()
    {
        _playerManager.SetUnlockCameraControl(false);
        _playerManager.SetUnlockMovementControl(false);
        SetMaleTrue(true);
    }

    public void Confirm()
    {
        if (string.IsNullOrEmpty(playerNameInputField.text))
            return;

        PlayerService.PlayerName = playerNameInputField.text;
        PlayerService.PlayerSex = _isMale ? 1 : 2;
        gameObject.SetActive(false);
        
        _playerManager.SetUnlockCameraControl(true);
        _playerManager.SetUnlockMovementControl(true);

        foreach (var gO in activateObjects)
        {
            gO.SetActive(true);
        }
    }

    public void SetMaleTrue(bool value)
    {
        _isMale = value;

        male.transform.localScale=Vector3.one*( _isMale ? 1.2f : 1);
        female.transform.localScale=Vector3.one*( !_isMale ? 1.2f : 1);
    }
}