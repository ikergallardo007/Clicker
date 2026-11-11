using System;
using TMPro;
using UnityEngine;

public class AngelsText : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private TextMeshProUGUI _angelsText;
    private int _angelNumber = 0;
    #endregion

    #region Unity Callbacks
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.OnAngelsReward += AddAngel;
    }
    private void OnDestroy()
    {
        GameController.OnAngelsReward -= AddAngel;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void AddAngel()
    {
        _angelNumber++;
        _angelsText.text = "ANGELS: " + _angelNumber;
    }
    #endregion

    #region Gizmos
    #endregion
}