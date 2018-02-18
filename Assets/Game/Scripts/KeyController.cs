using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    #region Editor tweakable fields

    [SerializeField] private KeyCode key;

    #endregion
    
    #region Fields

    private Button button;
    private GameController gameController;

    #endregion
    
    #region Properties
    
    public KeyCode Key
    {
        get { return key; }
    }

    public char Letter
    {
        get
        {
            // as KeyCode has the same int value as char, we can just cast
            return (char) key;
        }
    }

    #endregion
    
    #region Unity callbacks

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        button = GetComponentInChildren<Button>();
        
        button.onClick.AddListener(() => gameController.KeyClicked(this));
    }

    private void OnValidate()
    {
        GetComponentInChildren<Text>().text = Key.ToString();
    }

    #endregion
}