using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game/Game settings")]
public class GameSettings : ScriptableObject
{
    #region Editor tweakable fields

    [SerializeField] private int maxTryCount = 5;
    [SerializeField] private int minCountLettersInWord = 5;
    [SerializeField] private TextAsset text;

    #endregion
    
    #region Properties
    
    public int MaxTryCount
    {
        get { return maxTryCount; }
    }

    public int MinCountLettersInWord
    {
        get { return minCountLettersInWord; }
    }

    public TextAsset Text
    {
        get { return text; }
    }

    #endregion
}