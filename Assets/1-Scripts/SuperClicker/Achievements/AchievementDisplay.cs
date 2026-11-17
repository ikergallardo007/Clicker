using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class AchievementDisplay : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private Image _achievementIcon;
    [SerializeField] private TextMeshProUGUI _achievementText;
    private CanvasGroup _canvasGroup;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _canvasGroup.alpha = 0f;
    }
    #endregion

    #region Public Methods
    public void ShowAchievement(AchievementData data)
    {
        _achievementIcon.overrideSprite = data.Sprite;
        _achievementText.text = data.Title;
        _canvasGroup.alpha = 0f;
        Move();
    }
    #endregion

    #region Private Methods
    private void Move()
    {
        Sequence achievementSequence = DOTween.Sequence();

        achievementSequence.Append(_canvasGroup.DOFade(1f, 1f));
        achievementSequence.AppendInterval(2f);
        achievementSequence.Append(_canvasGroup.DOFade(0f, 1f));

        achievementSequence.OnComplete(() =>
        {
            this.gameObject.SetActive(false);
        });

        achievementSequence.Play();
    }
    #endregion

    #region Gizmos
    #endregion
}