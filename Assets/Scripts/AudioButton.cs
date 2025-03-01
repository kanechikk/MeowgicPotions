using UnityEngine;

public class AudioButton : MonoBehaviour
{
	private AudioManager m_audioManager;
	private void Start()
	{
		m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public void PlayClickSound()
	{
		m_audioManager.PlaySFX(m_audioManager.SFXClickingButtons);
	}
}
