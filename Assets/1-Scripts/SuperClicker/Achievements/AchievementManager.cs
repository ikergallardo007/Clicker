// Controla y desbloquea los logros.
using UnityEngine;
using System;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour
{
    #region Properties
    public event Action<AchievementData> OnAchievementUnlocked;
    #endregion

    #region Fields
    [Header("Achievement Definitions")]
    [SerializeField] private List<AchievementData> _achievements = new();

    [Header("Player Progress")]
    [SerializeField] private List<AchievementProgress> _progress = new();
    [Header("Achievement Display")]
    [SerializeField] private AchievementDisplay _display;
    private List<AchievementData> _obtainedAchievements = new();
    private readonly Dictionary<string, AchievementProgress> _progressById = new();
    private readonly List<AchievementData> _validAchievements = new();
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        InitializeAchievements();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (_obtainedAchievements.Count > 0 &&
            !_display.gameObject.activeSelf)
        {
            _display.gameObject.SetActive(true);
            AchievementData data = _obtainedAchievements[0];
            _display.ShowAchievement(data);
            _obtainedAchievements.RemoveAt(0);
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void InitializeAchievements()
    {
        _progressById.Clear();
        _validAchievements.Clear();

        // Index existing on player progress.
        foreach (AchievementProgress item in _progress)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.AchivementId))
                continue;

            if (_progressById.ContainsKey(item.AchivementId))
            {
                Debug.LogWarning(
                    $"Duplicate progress ID: {item.AchivementId}"
                    );
                continue;
            }

            _progressById.Add(item.AchivementId, item);
        }

        // Register achievement definitions.
        HashSet<string> registeredIds = new();

        foreach (AchievementData achievement in _achievements)
        {
            if (achievement == null)
                continue;

            if (string.IsNullOrWhiteSpace(achievement.Id))
            {
                Debug.LogWarning(
                    "An achievement has an empty ID."
                    );
                continue;
            }

            if (!registeredIds.Add(achievement.Id))
            {
                Debug.LogWarning(
                    $"Duplicate achievement ID: {achievement.Id}"
                    );
                continue;
            }

            _validAchievements.Add(achievement);

            // Create progress if it does not exist.
            if (!_progressById.ContainsKey(achievement.Id))
            {
                AchievementProgress newProgress =
                    new AchievementProgress(achievement.Id);

                _progress.Add(newProgress);

                _progressById.Add(
                    achievement.Id,
                    newProgress
                    );
            }
        }
    }

    public void AddProgress(AchievementType type, int amount = 1)
    {
        if (amount <= 0)
            return;

        foreach (AchievementData achievement in _validAchievements)
        {
            if (achievement.Type != type)
                continue;

            if (!_progressById.TryGetValue(
                achievement.Id,
                out AchievementProgress playerProgress))
                continue;

            bool unlocked = playerProgress.AddProgress(
                amount,
                achievement.TargetValue
                );

            if (unlocked)
            {
                Debug.Log(
                    $"Achievement unlocked: {achievement.Title}"
                    );

                _obtainedAchievements.Add(achievement);
            }
        }
    }
    #endregion

    #region Gizmos
    #endregion
}