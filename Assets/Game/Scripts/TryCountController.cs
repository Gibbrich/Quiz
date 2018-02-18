using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryCountController : MonoBehaviour
{
    #region Private fields

    [SerializeField] private Text count;
    
    #endregion
        
    #region Public methods
    
    public void UpdateTryCount(int tryCount)
    {
        count.text = tryCount.ToString();
    }    
    
    #endregion
}