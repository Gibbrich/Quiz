using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region Private fields

    [SerializeField] private Text score;
    
    #endregion
        
    #region Public methods
    
    public void UpdateScore(int score)
    {
        this.score.text = score.ToString();
    }   
    
    #endregion
}