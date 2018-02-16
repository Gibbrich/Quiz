using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Editor tweakable fields

    [SerializeField] private KeyController keyViewPrefab;
    
    #endregion
    
    #region Fields
    
    private readonly List<KeyCode[]> keyboard = new List<KeyCode[]>
    {
        new [] {KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P},
        new [] {KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L},
        new [] {KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M}
    };
    
    
    #endregion
    
    #region Unity callbacks

//    private void OnValidate()
//    {
//        float borderWidth = 50;
//
//        RectTransform rectTransform = GetComponent<RectTransform>();
//
//        float uiWidth = rectTransform.sizeDelta.x;
//        float uiHeight = rectTransform.sizeDelta.y;
//
//        float keysGap = (uiWidth - 2 * borderWidth) / 10;
//        float linesGap = (uiHeight / 2 - borderWidth) / 3;
//        
//        Vector3 startPosition = new Vector3(borderWidth)
//
//        foreach (var line in keyboard)
//        {
//            foreach (KeyCode keyCode in line)
//            {
//                KeyController.Create(keyViewPrefab, )
//            }
//        }
//    }

    #endregion
    
    #region Public methods

    public void ShowLetter(KeyCode code)
    {
        
    }

    public void RefreshWord(List<char> letters)
    {
        
    }
    
    #endregion
}