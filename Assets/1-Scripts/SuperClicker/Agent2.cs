using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Agent2 : AgentBase
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] bool _archdemon = false;
    private GameController _game;
    private PoolScript _pool;
    private SlotButtonUI[] _buttons;
    private int _clicks = 1;
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
        InvokeRepeating(nameof(ClickAll), 1, RepeatRate);
    }


    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void ClickAll()
    {
        if (_archdemon)
            _clicks = (int) _game.ClickRatio;
        Movement();
        
        foreach (SlotButtonUI slot in _buttons)
        {
            Button button = slot.GetComponent<Button>();
            if (button.enabled)
            {
                slot.Click(_clicks, true);
                _agentAudio.Play();
            }
        }
    }

    private void Movement()
    {


        Sequence agentSequence = DOTween.Sequence();

        agentSequence.Append(transform.DOMove(Vector3.zero, 0.5f));

        agentSequence.Append(transform.DOScale(1000, 0.5f));

        agentSequence.Append(transform.DOScale(250, 0.1f));

        agentSequence.Play();
    }
    #endregion

        #region Gizmos
        #endregion
    }