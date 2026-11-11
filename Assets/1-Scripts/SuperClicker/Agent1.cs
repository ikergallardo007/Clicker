using DG.Tweening;
using UnityEngine;

public class Agent1 : AgentBase
{
    #region Properties
    #endregion

    #region Fields
    #endregion

    #region Unity Callbacks
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Movement();
        InvokeRepeating(nameof(Click), 1, RepeatRate);
        SlotButtonUI.OnSlotClicked += SetDestiny;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void SetDestiny(SlotButtonUI newDestiny)
    {
        destiny = newDestiny;
        Movement();
    }
    private void Click()
    {
        destiny.Click(1, true);
        _agentAudio.Play();
        // Only Agent
        if (destiny.ClicksLeft < 0)
            Destroy(gameObject);
    }

    private void Movement()
    {
        transform.DOMove(destiny.transform.position, 1);
    }
    #endregion

    #region Gizmos
    #endregion
}