using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnim;
    AudioSource playerAudio;
    public ParticleSystem deathExplosion;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 10;
    public float gravityModifier = 2;
    public int jumpCount = 2;
    public bool onGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //<> find any type and component
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpCount >= 0)
        {
            if (onGround == true)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                onGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 0.75f);
                jumpCount -= 1;
            }

            if (onGround == false && jumpCount >= 0)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 0.75f);
                jumpCount -= 1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtParticle.Play();
            jumpCount = 2;
            playerAnim.ResetTrigger("Jump_trig");
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over! LLLLL");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            deathExplosion.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 0.95f);
        }
    }
}
