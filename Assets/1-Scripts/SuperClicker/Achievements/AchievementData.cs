// Define las características de un logro
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum AchievementType
{
    TotalClicks,
    PlayedTime,
    Progress,
    ObtainedRewards
}

[CreateAssetMenu(
    fileName = "Achievement_New",
    menuName = "Clicker/Achievement"
    )]
public class AchievementData : ScriptableObject
{
    #region Properties
    public string Id => _id;
    public string Title => _title;
    public string Description => _description;
    public AchievementType Type => _type;
    public int TargetValue => _targetValue;
    public Sprite Sprite => _sprite;
    #endregion

    #region Fields
    [Header("Identification")]
    [SerializeField] private string _id;
    [SerializeField] private string _title;

    [TextArea]
    [SerializeField] private string _description;

    [Header("Requirements")]
    [SerializeField] private AchievementType _type;

    [Min(1)]
    [SerializeField] private int _targetValue = 1;
    [Header("Icon")]
    [SerializeField] private Sprite _sprite;
    #endregion

    #region Unity Callbacks
    private void OnValidate()
    {
        if (_targetValue < 1)
            _targetValue = 1;
    }
    #endregion


}
