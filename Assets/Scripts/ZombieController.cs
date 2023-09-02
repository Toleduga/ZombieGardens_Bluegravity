using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public Animator animator;
    public PlayerInteractor playerInteractor;

    public Rigidbody2D rb;
    public bool seek = false;
    bool dead;



    private void Start()
    {
        player = FindObjectOfType<TopDownCharacterController>().transform; 
        playerInteractor = FindObjectOfType<PlayerInteractor>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player != null && seek)
        {
            Vector2 direccion = (player.position - transform.position).normalized;
            rb.velocity = direccion * speed;
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical", rb.velocity.y);
            Debug.LogFormat("velocidad: {0}", rb.velocity);
        }


    }
    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }
       

    IEnumerator Kill(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }

    public void Death()
    {
        speed = 0;
        animator.SetTrigger("Death");
        this.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Kill(2f));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            Death();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if ((playerInteractor.flowers - 2) <= 0)
            {
                playerInteractor.flowers = 0;
                playerInteractor.DeathPlayer();
            }
            else { playerInteractor.flowers -= 2; }
            
            playerInteractor.GetComponent<AudioSource>().Play();
            playerInteractor.AnimLess();
            Death();
        }
    }
}
