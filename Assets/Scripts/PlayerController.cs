using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce=5.0f;
    [SerializeField] private float gravityModifier=1.0f;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    public bool gameOver = false;
    
    

    private Rigidbody playerRb;
    private bool isGrounded = true;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded&&!gameOver)
        { 
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(jumpSound, 1f);
        }

        //Harder option:
        //The player has to move the character back after every jump
        //float horizontalCorrection = Input.GetAxis("Horizontal");
        if (transform.position.x>0.3f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }
        else
        {           
            gameOver = true;
            dirtParticle.Stop();
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1f);
            explosionParticle.Play();
        }
    }
}
