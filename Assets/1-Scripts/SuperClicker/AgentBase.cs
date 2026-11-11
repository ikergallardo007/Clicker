using UnityEngine;

public class AgentBase : MonoBehaviour
{
	#region Properties
	[field: SerializeField] public float RepeatRate { get; set; }
	public SlotButtonUI destiny {  get; set; }
	#endregion

	#region Fields
	[SerializeField] protected AudioSource _agentAudio;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {

    }

	// Update is called once per frame
	void Update()
    {
        
    }
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion   
}
