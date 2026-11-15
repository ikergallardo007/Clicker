using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
        // A reward can assign the initial destination before Start runs.
        Movement();
        InvokeRepeating(nameof(Click), 1, RepeatRate);
        SlotButtonUI.OnSlotClicked += SetDestiny;
    }

    private void OnDestroy()
    {
        // This is a static event, so destroyed agents must unsubscribe explicitly.
        SlotButtonUI.OnSlotClicked -= SetDestiny;
        CancelInvoke(nameof(Click));
        transform.DOKill();
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
        if (newDestiny == null)
            return;

        destiny = newDestiny;
        Movement();
    }
    private void Click()
    {
        if (destiny == null)
            return;

        Button button = destiny.GetComponent<Button>();
        if (button == null || !button.enabled || !button.interactable)
            return;
        destiny.Click(1, true);
        _agentAudio.Play();
        // Only Agent
        if (destiny.ClicksLeft <= 0)
            Destroy(gameObject);
    }

    private void Movement()
    {
        if (destiny == null)
            return;

        transform.DOMove(destiny.transform.position, 1);
    }
    #endregion

    #region Gizmos
    #endregion
}
