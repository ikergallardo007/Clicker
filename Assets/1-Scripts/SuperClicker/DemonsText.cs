using System;
using TMPro;
using UnityEngine;

public class DemonsText : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private TextMeshProUGUI _demonsText;
    private int _demonNumber = 0;
    #endregion

    #region Unity Callbacks
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.OnDemonsReward += AddDemon;
    }
    private void OnDestroy()
    {
        GameController.OnDemonsReward -= AddDemon;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void AddDemon()
    {
        _demonNumber++;
        _demonsText.text = "DEMONS: " + _demonNumber;
    }
    #endregion

    #region Gizmos
    #endregion
}