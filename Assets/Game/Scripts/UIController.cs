using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Editor tweakable fields
    
    [SerializeField] private GameOverPanelController gameOverPanel;    
    
    #endregion
    
    #region Private fields

    private ScoreController scoreController;
    private TryCountController tryCountController;
    private Letters letters;
    private KeyboardController keyboardController;
    
    #endregion
    
    #region Unity callbacks

    private void Start()
    {
        keyboardController = GetComponentInChildren<KeyboardController>();
        scoreController = GetComponentInChildren<ScoreController>();
        tryCountController = GetComponentInChildren<TryCountController>();
        letters = GetComponentInChildren<Letters>();
    }

    #endregion
    
    #region Public methods

    public void ShowLetter(KeyController controller)
    {
        letters.ShowLetter(controller.Letter);
        controller.gameObject.SetActive(false);
    }

    public void UpdateWord(List<char> letters)
    {
        this.letters.UpdateWord(letters);
    }

    public void UpdateTryCount(int tryCount)
    {
        tryCountController.UpdateTryCount(tryCount);
    }

    public void UpdateScore(int score)
    {
        scoreController.UpdateScore(score);
    }

    public void OpenGameOverPanel(string message)
    {
        gameOverPanel.Open(message);
        letters.gameObject.SetActive(false);
        scoreController.gameObject.SetActive(false);
        tryCountController.gameObject.SetActive(false);
        keyboardController.gameObject.SetActive(false);
    }

    public void CloseGameOverPanel()
    {
        gameOverPanel.Close();
        letters.gameObject.SetActive(true);
        scoreController.gameObject.SetActive(true);
        tryCountController.gameObject.SetActive(true);
        keyboardController.gameObject.SetActive(true);
    }
    
    public void ShowAllKeys()
    {
        keyboardController.ShowAllKeys();
    }
    
    #endregion
}