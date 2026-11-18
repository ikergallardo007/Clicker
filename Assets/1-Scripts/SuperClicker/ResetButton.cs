using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private Button _resetButton;
    private GameController _game;
    private PoolScript _pool;
    private SlotButtonUI[] _buttons;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _game = FindAnyObjectByType<GameController>();
        _pool = FindAnyObjectByType<PoolScript>();
        _buttons = _pool.GetComponentsInChildren<SlotButtonUI>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _resetButton.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Reset()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
            );
    }
    #endregion

    #region Gizmos
    #endregion
}