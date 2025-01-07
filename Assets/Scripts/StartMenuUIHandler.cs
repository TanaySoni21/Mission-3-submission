using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button startButton;
    public Button exitButton;

    public void StartGame()
    {
        DataStorage.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
