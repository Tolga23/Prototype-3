using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    private AudioSource _playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    public float jumpForce = 10;
    public bool onGround = true;
    public float gravityModifier = 1;
    public bool gameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(JumpThing()); 
    }

    IEnumerator JumpThing()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        yield return new WaitForEndOfFrame();
    }

    private void OnCollisionEnter(Collision collision) 
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtParticle.Play();
        }else if(collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Game over!");   
            gameOver = true;
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(crashSound,1.0f);
        }
        
    }

}

    

