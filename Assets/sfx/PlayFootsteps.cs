using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    public AudioClip[] metalClips;
    public AudioClip[] hardwoodClips;
    public AudioClip[] dirtClips;

    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AllFootsteps()
    {
        if (Physics.Raycast(RayStart.position, RayStart.transform.up * -1, out hit, range, layerMask))
        {
            if (hit.collider.CompareTag("Metal"))
            {
                AudioClip metalClip = GetRandomMetalClip();
                PlayAllFootsteps(metalClip);
                Debug.Log("Metal detected! Playing metal SFX");
            }

            if (hit.collider.CompareTag("Hardwood"))
            {
                AudioClip hardwoodClip = GetRandomHardwoodClip();
                PlayAllFootsteps(hardwoodClip);
                Debug.Log("Hardwood detected! Playing hardwood SFX");
            }

            if (hit.collider.CompareTag("Dirt"))
            {
                AudioClip dirtClip = GetRandomDirtClip();
                PlayAllFootsteps(dirtClip);
                Debug.Log("Dirt detected! Playing dirt SFX");
            }
        }
    }

    private AudioClip GetRandomMetalClip()
    {
        return metalClips[UnityEngine.Random.Range(0, metalClips.Length)];
    }

    private AudioClip GetRandomHardwoodClip()
    {
        return hardwoodClips[UnityEngine.Random.Range(0, hardwoodClips.Length)];
    }

    private AudioClip GetRandomDirtClip()
    {
        return dirtClips[UnityEngine.Random.Range(0, dirtClips.Length)];
    }

    public void PlayAllFootsteps(AudioClip audio)
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.volume = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(audio);
    }
}