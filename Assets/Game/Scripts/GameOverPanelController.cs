using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{
    #region Editor tweakable fields

    [SerializeField] private Text gameOverMessage;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    #endregion

    #region Private fields

    private GameController gameController;
    private UIController uiController;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UIController>();

        restartButton.onClick.AddListener(() =>
        {
            uiController.CloseGameOverPanel();
            gameController.StartNewGame(true, true, true);
        });
        exitButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }

    #endregion

    #region Public methods

    public void Open(string message)
    {
        gameOverMessage.text = message;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    #endregion
}