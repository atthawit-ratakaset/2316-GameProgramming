using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip(), 0.4f);
    }

    public void PlayWalkSound()
   {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);
   }

}
