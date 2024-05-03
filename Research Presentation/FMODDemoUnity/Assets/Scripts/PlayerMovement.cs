using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using StopMode = FMOD.Studio.STOP_MODE;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] EventReference playerFootstepsSound;
    private EventInstance playerFootsteps;
    Rigidbody2D rb;
    private float distanceToGround;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] KeyCode slowKey;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] LayerMask layer;
    float xdir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = transform.localScale.y/2;
        playerFootsteps = AudioManager.Instance.CreateEventInstance(playerFootstepsSound);
    }

    void Update()
    {        
        if (Input.GetKeyDown(jumpKey) && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void FixedUpdate()
    {
        UpdateSteps();
        xdir = (Input.GetKey(leftKey) ? -1f : 0f) + (Input.GetKey(rightKey) ? 1f : 0f);
        rb.velocity = new Vector2(xdir*speed*(Input.GetKey(slowKey) ? 0.25f : 1f), rb.velocity.y);
        
        
    }

    bool IsGrounded() {
        return Physics2D.OverlapCircle(new Vector2(rb.position.x, rb.position.y-distanceToGround), 0.1f, layer);
    }

    void UpdateSteps() {
        if (rb.velocity.x != 0 && IsGrounded()) {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED)) {
                playerFootsteps.start();
            }
        } else {playerFootsteps.stop(StopMode.ALLOWFADEOUT);}
    }
}
