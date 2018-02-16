using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Editor tweakable fields

    [SerializeField] private GameSettings gameSettings;
    
    #endregion
    
    #region Fields

    private List<char> charsToGuess;
    private UIController uiController;
    private int tryCount;
    private HashSet<string> words;

    #endregion
    
    #region Properties
    
    public int TryCount
    {
        get { return tryCount; }
    }
    
    #endregion
    
    #region Unity callbacks

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        tryCount = gameSettings.MaxTryCount;

        IEnumerable<string> data = gameSettings
            .Text
            .text
            .Split(' ')
            .Where(word => word.Length >= gameSettings.MinCountLettersInWord)
            .Select(word => word.ToLower())
            .Distinct();

        words = new HashSet<string>(data);
    }

    #endregion
    
    #region Public methods

    public void KeyClicked(KeyController keyController)
    {
        char letter = keyController.Key.ToString().ToLower()[0];

        if (charsToGuess.Contains(letter))
        {
            uiController.ShowLetter(keyController.Key);
            keyController.gameObject.SetActive(false);
        }
        else
        {
            tryCount--;
        }
    }
    
    #endregion
    
    #region Private methods

    private void RefreshWord()
    {
        // not optimal
        string correctWord = words.ElementAt(Random.Range(0, words.Count));
        words.Remove(correctWord);

        charsToGuess = correctWord.ToCharArray().ToList();
        uiController.RefreshWord(charsToGuess);
    }
    
    #endregion
}