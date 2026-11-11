using UnityEngine;
using System;
using TMPro;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    #region Properties
    [field: SerializeField] public float ClickRatio { get; set; }
    [field: SerializeField] public PoolSystem Pool { get; set; }
    public static event Action OnAngelsReward;
    public static event Action OnDemonsReward;
    #endregion

    #region Fields
    [SerializeField] private AgentBase[] _agents;
    [SerializeField] private TextMeshProUGUI _rewardText;
    [SerializeField] private TextMeshProUGUI _clicksText;

    [SerializeField] private ParticleSystem _particlesRain;
    [SerializeField] private AudioSource _rewardAudio;
    private string _agentType;
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        SlotButtonUI.OnSlotReward += GetReward;
    }
    private void OnDestroy()
    {
        SlotButtonUI.OnSlotReward -= GetReward;
    }

    #endregion

    #region Public Methods
    public void RainParticles()
    {
        _particlesRain.Emit(Mathf.Clamp((int)ClickRatio, 0, 13));
    }
    #endregion

    #region Private Methods
    /***
 *       ____    U _____ u                 _       ____     ____    _    
 *    U |  _"\ u \| ___"|/__        __ U  /"\  uU |  _"\ u |  _"\ U|"|u  
 *     \| |_) |/  |  _|"  \"\      /"/  \/ _ \/  \| |_) |//| | | |\| |/  
 *      |  _ <    | |___  /\ \ /\ / /\  / ___ \   |  _ <  U| |_| |\|_|   
 *      |_| \_\   |_____|U  \ V  V /  U/_/   \_\  |_| \_\  |____/ u(_)   
 *      //   \\_  <<   >>.-,_\ /\ /_,-. \\    >>  //   \\_  |||_   |||_  
 *     (__)  (__)(__) (__)\_)-'  '-(_/ (__)  (__)(__)  (__)(__)_) (__)_) 
 */
    private void GetReward(Reward reward)
    {
        ShowReward(reward);
        _rewardAudio.Play();

        //Apply rewards
        if (reward.RewardType == RewardType.Plus)
        {
            ClickRatio += reward.Value;
            _clicksText.text = "x" + ClickRatio;
            return;
        }

        if (reward.RewardType == RewardType.Multi)
        {
            ClickRatio *= reward.Value;
            _clicksText.text = "x" + ClickRatio;
            return;
        }

        if (reward.RewardType == RewardType.Agent)
        {
            AgentBase newAgent = Instantiate(_agents[(int)reward.Value], transform.position, Quaternion.identity);
            newAgent.destiny = reward.ObjectReward;
            // Angels
            if (reward.Value == 0 || reward.Value == 2)
            {
                OnAngelsReward?.Invoke();
            }

            // Demons
            if (reward.Value == 1 || reward.Value == 3)
            {
                OnDemonsReward?.Invoke();
            }
            return;
        }
    }

    private void ShowReward(Reward reward)
    {
        //Initialziation
        if (!_rewardText.gameObject.activeSelf)
        {
            _rewardText.gameObject.SetActive(true);
            _rewardText.transform.localScale = Vector3.zero;
        }

        //Update text
        if (reward.RewardType == RewardType.Agent)

            if (reward.Value == 0 || reward.Value == 2) // ANGELS
                _agentType = "Angel";

            if (reward.Value == 1 || reward.Value == 3) // DEMONS
                _agentType = "Demon";

            _rewardText.text = "REWARD\n" + _agentType;

        if (reward.RewardType != RewardType.Agent)
            _rewardText.text = "REWARD\n " + reward.RewardType + reward.Value + " Clicks";

        // Crear una secuencia
        Sequence mySequence = DOTween.Sequence();

        // Añadir el primer efecto de escala
        mySequence.Append(_rewardText.transform.DOScale(1, 1));

        // Añadir el efecto de sacudida en la rotación
        mySequence.Append(_rewardText.transform.DOShakeRotation(1, new Vector3(0, 0, 30)));

        // Añadir el segundo efecto de escala
        mySequence.Append(_rewardText.transform.DOScale(0, 1));

        // Iniciar la secuencia
        mySequence.Play();

    }
    #endregion
}
