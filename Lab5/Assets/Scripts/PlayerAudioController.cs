using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;
    [SerializeField] private SoAudioClips winAudioClips;
    [SerializeField] private SoAudioClips jumpPadAudioClips;
    [SerializeField] private SoAudioClips collectedAudioClips;
    [SerializeField] private SoAudioClips respawnedAudioClips;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip(), 0.3f);
    }

    public void PlayWalkSound()
   {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip());
   }

    public void PlayFallSound()
   {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClip());
   }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathAudioClips.GetAudioClip());
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winAudioClips.GetAudioClip());
    }

    public void PlayJumpPadSound()
    {
        audioSource.PlayOneShot(jumpPadAudioClips.GetAudioClip());
    }

    public void PlayCollectedSound()
    {
        audioSource.PlayOneShot(collectedAudioClips.GetAudioClip());
    }

    public void PlayCollectibleRespawnedSound()
    {
        audioSource.PlayOneShot(respawnedAudioClips.GetAudioClip());
    }



}
