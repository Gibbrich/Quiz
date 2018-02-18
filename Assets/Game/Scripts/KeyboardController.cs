using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    #region Private fields
    
    private KeyController[] keys;    
    
    #endregion
    
    #region Unity callbacks

    private void Start()
    {
        keys = GetComponentsInChildren<KeyController>();
    }

    #endregion
    
    #region Public methods
    
    public void ShowAllKeys()
    {
        keys.ForEach(controller => controller.gameObject.SetActive(true));
    }    
    
    #endregion
}