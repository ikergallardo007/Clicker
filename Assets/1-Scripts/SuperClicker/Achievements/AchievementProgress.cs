// Almacena el progreso del jugador.
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class AchievementProgress
{
    #region Properties
    public string AchivementId => _achivementId;
    public int CurrentValue => _currentValue;
    public bool IsUnlocked => _isUnlocked;
    #endregion

    #region Fields
    [SerializeField] private string _achivementId;
    [SerializeField] private int _currentValue;
    [SerializeField] private bool _isUnlocked;
    #endregion



    #region Public Methods
    public AchievementProgress()
    {
    }

    public AchievementProgress(string id)
    {
        _achivementId = id;
        _currentValue = 0;
        _isUnlocked = false;
    }

    public bool AddProgress(int amount, int targetValue)
    {
        if (_isUnlocked || amount <= 0 || targetValue <= 0)
            return false;

        _currentValue = (int)Math.Min(
            (long)_currentValue + amount,
            targetValue
            );

        if (_currentValue >= targetValue)
        {
            _isUnlocked = true;
            return true;
        }

        return false;
    }
    #endregion

    #region Private Methods
    #endregion

    #region Gizmos
    #endregion
}
