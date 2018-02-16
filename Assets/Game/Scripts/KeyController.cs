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
    
    #region Public methods

    public static KeyController Create(KeyController prefab, Vector3 position, KeyCode code, Transform parent)
    {
        KeyController keyController = Instantiate(prefab, position, Quaternion.identity, parent);
        keyController.key = code;
        return keyController;
    }
    
    #endregion
}