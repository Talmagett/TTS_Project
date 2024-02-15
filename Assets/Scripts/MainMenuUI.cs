using System;
using Managers;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private Button male;
    [SerializeField] private Button female;
    [SerializeField] private int nextScene;
    
    private bool _isMale = true;

    private void Awake()
    {
        SetMaleTrue(true);
    }

    public void Confirm()
    {
        if (string.IsNullOrEmpty(playerNameInputField.text))
            return;

        PlayerService.PlayerName = playerNameInputField.text;
        PlayerService.PlayerSex = _isMale ? 1 : 2;

        SceneManager.LoadScene(nextScene);
    }

    public void SetMaleTrue(bool value)
    {
        _isMale = value;

        male.transform.localScale=Vector3.one*( _isMale ? 1.2f : 1);
        female.transform.localScale=Vector3.one*( !_isMale ? 1.2f : 1);
    }
}