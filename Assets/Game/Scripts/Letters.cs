using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Letters : MonoBehaviour
{
    #region Editor tweakable fields

    [SerializeField] private LetterController letterViewPrefab;

    #endregion

    #region Private fields

    private readonly List<LetterController> letterControllers = new List<LetterController>();
    private float cardWidth;
    private const int CARD_GAP = 10;

    #endregion
    
    #region Unity callbacks

    private void Start()
    {
        cardWidth = letterViewPrefab.GetComponent<RectTransform>().sizeDelta.x;
    }

    #endregion

    #region Public methods

    public void ShowLetter(char letter)
    {
        letterControllers
            .Where(controller => controller.Letter == letter)
            .ForEach(controller => controller.ShowLetter());
    }

    public void UpdateWord(List<char> letters)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        letterControllers.Clear();
        
        float x = Screen.width / 2.0f - (letters.Count * cardWidth + (letters.Count - 1) * CARD_GAP) / 2;
        float y = Screen.height * 3 / 4.0f;
        
        letters.ForEach(letter =>
        {
            LetterController letterController = LetterController.Create(letterViewPrefab, new Vector3(x, y), transform, letter);
            x += cardWidth + CARD_GAP;
            letterControllers.Add(letterController);
        });
    }

    #endregion
}