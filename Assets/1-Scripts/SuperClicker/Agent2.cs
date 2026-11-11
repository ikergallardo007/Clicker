using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Agent2 : AgentBase
{
    #region Properties
    #endregion

    #region Fields
    private PoolScript _pool;
    private SlotButtonUI[] _buttons;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _pool = FindAnyObjectByType<PoolScript>();
        _buttons = _pool.GetComponentsInChildren<SlotButtonUI>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(ClickAll), 1, RepeatRate);
    }



    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void ClickAll()
    {
        Movement();
        foreach (SlotButtonUI slot in _buttons)
        {
            Button button = slot.GetComponent<Button>();
            if (button.enabled)
            {
                slot.Click(1, true);
                _agentAudio.Play();
            }
        }
    }

    private void Movement()
    {


        Sequence agentSequence = DOTween.Sequence();

        agentSequence.Append(transform.DOMove(Vector3.zero, 1));

        agentSequence.Append(transform.DOScale(1000, 1));

        agentSequence.Append(transform.DOScale(250, 0.1f));

        agentSequence.Play();
    }
    #endregion

        #region Gizmos
        #endregion
    }