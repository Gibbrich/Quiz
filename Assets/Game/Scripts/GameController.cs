using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Editor tweakable fields

    [SerializeField] private GameSettings gameSettings;

    #endregion

    #region Fields

    private List<char> letters;
    private UIController uiController;
    private int tryCount;
    private int score;
    private HashSet<string> words;

    #endregion

    #region Properties

    public int TryCount
    {
        get { return tryCount; }
        private set
        {
            tryCount = value;
            uiController.UpdateTryCount(value); 
        }
    }

    public int Score
    {
        get { return score; }
        private set
        {
            score = value; 
            uiController.UpdateScore(value);
        }
    }

    #endregion

    #region Unity callbacks

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        StartNewGame(true, true, true);
    }

    #endregion

    #region Public methods

    public void KeyClicked(KeyController keyController)
    {
        if (letters.Contains(keyController.Letter))
        {
            uiController.ShowLetter(keyController);
            letters.RemoveAll(c => c == keyController.Letter);
        }
        else
        {
            TryCount--;
        }

        if (letters.Count == 0)
        {
            Score += TryCount;
            uiController.ShowAllKeys();
            StartNewGame(false, false, false);
            return;
        }

        if (tryCount < 0)
        {
            string message = new StringBuilder()
                             .AppendLine("Игра окончена.")
                             .AppendFormat("Ваш счёт - {0}", Score)
                             .ToString();
            
            uiController.OpenGameOverPanel(message);
            return;
        }
    }
    
    public void StartNewGame(bool shouldClearScore, bool shouldReinitializeWords, bool shouldReinitializeTryCount)
    {
        if (shouldReinitializeWords)
        {
            var data = GetWords(gameSettings.Text.text)
                       .Where(word => word.Length >= gameSettings.MinCountLettersInWord)
                       .Select(word => word.ToLower())
                       .Distinct();

            words = new HashSet<string>(data);
        }
        
        if (shouldClearScore)
        {
            Score = 0;            
        }

        if (shouldReinitializeTryCount)
        {
            TryCount = gameSettings.MaxTryCount;
        }
        
        UpdateWord();
    }

    #endregion

    #region Private methods

    private void UpdateWord()
    {
        if (words.Count > 0)
        {
            // not optimal
            string correctWord = words.ElementAt(Random.Range(0, words.Count));
            words.Remove(correctWord);

            letters = correctWord.ToCharArray().ToList();
            uiController.UpdateWord(letters);
        }
        else
        {
            uiController.OpenGameOverPanel("Вы прошли игру!");
        }
    }
    
    private static string[] GetWords(string input)
    {
        MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

        var words = matches
                    .Cast<Match>()
                    .Select(match => match.Value)
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Select(TrimSuffix);

        return words.ToArray();
    }

    private static string TrimSuffix(string word)
    {
        int apostropheLocation = word.IndexOf('\'');
        if (apostropheLocation != -1)
        {
            word = word.Substring(0, apostropheLocation);
        }

        return word;
    }

    #endregion
}