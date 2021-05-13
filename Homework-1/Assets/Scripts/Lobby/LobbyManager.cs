using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_Text errorText;

    public void Start()
    {
        Application.targetFrameRate = 160;
        string name = PlayerPrefs.GetString("name");
        if(name != null && name.Length > 0)
        {
            nameField.text = name;
        }
    }

    public void TryHost()
    {
        if (IsNameOk(nameField.text))
        {
            HideError();
            PlayerPrefs.SetString("name", nameField.text);
            PlayerPrefs.SetString("role", "host");
            LoadRoom();
        }
        else
        {
            ShowError("Please enter a valid name.");
        }
    }

    public void TryClient()
    {
        if (IsNameOk(nameField.text))
        {
            HideError();
            PlayerPrefs.SetString("name", nameField.text);
            PlayerPrefs.SetString("role", "client");
            LoadRoom();
        }
        else
        {
            ShowError("Please enter a valid name.");
        }
    }

    private bool IsNameOk(string name)
    {
        if(name == null || name.Length == 0)
        {
            return false;
        }
        return true;
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ShowError(string error)
    {
        errorText.text = error;
        errorText.enabled = true;
    }

    private void HideError()
    {
        errorText.enabled = false;
    }

    private void LoadRoom()
    {
        SceneManager.LoadScene("MultiplayerRoom");
    }

}
