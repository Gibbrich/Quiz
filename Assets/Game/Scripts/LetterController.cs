using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    #region Private fields

    private Text text;
    private Image image;
    private char letter;

    #endregion
    
    #region Properties
    
    public char Letter
    {
        get { return letter; }
    }    
    
    #endregion
    
    #region Unity callbacks

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        text.text = letter.ToString();
    }

    #endregion
    
    #region Public methods

    public void ShowLetter()
    {
        image.gameObject.SetActive(false);
    }

    public static LetterController Create(LetterController prefab, Vector3 position, Transform parent, char letter)
    {
        LetterController letterController = Instantiate(prefab, position, Quaternion.identity, parent);
        letterController.letter = letter;
        return letterController;
    }
    
    #endregion
}