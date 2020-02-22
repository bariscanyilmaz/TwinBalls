using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float verticalVelocity = 10;
    public float horizontalVelocity = 0;
    public Rigidbody2D otherPlayer;
    public Collider2D ignoreCollider;
    private Collider2D ownCollider;
    private Rigidbody2D rigidBody;
    private GameHelper gameManager;
    private bool isSuperPower;
    private bool superPowerStarted;
    private float duration;
    public ParticleSystem particle;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        ownCollider = GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(ignoreCollider, ownCollider);
        gameManager = GameObject.Find("GameManager").GetComponent<GameHelper>();

    }

    // Update is called once per frame
    void Update()
    {

        // if (gameManager.Score % 500 == 0)
        if (gameManager.Score > 0)
        {

            if (!superPowerStarted)
            {
                var offset = Mathf.Abs((otherPlayer.transform.position.x - transform.position.x));
                if (offset <= (ownCollider.bounds.extents.x) * 2)
                {
                    isSuperPower = true;
                    superPowerStarted = true;
                    gameObject.layer=10;

                }
            }

            if (duration < 10f)
            {

                if (isSuperPower)
                {
                    transform.position = new Vector3((transform.position.x + otherPlayer.position.x) / 2, transform.position.y, transform.position.z);
                    rigidBody.velocity = new Vector2(0, verticalVelocity);
                    duration += Time.deltaTime;
                    Invoke("ResetDuration", 15);

                }
                else
                {
                    rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
                }
            }
            else
            {
                superPowerStarted = false;
                gameObject.layer=0;
                rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
            }


        }
        else
        {
            rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            horizontalVelocity = -(horizontalVelocity);
            rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        }

    }


    private void ResetDuration()
    {
        duration = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Bonus")
        {

            if (isSuperPower)
            {
                collision.collider.gameObject.transform.position = new Vector3(-collision.collider.gameObject.transform.position.x, collision.collider.gameObject.transform.position.y + 15, collision.collider.gameObject.transform.position.z);
                gameManager.IncreaseScore(10);
                rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

                particle.Play();
            }
            else
            {
                if (collision.collider.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
                {

                    collision.collider.gameObject.transform.position = new Vector3(-collision.collider.gameObject.transform.position.x, collision.collider.gameObject.transform.position.y + 15, collision.collider.gameObject.transform.position.z);
                    gameManager.IncreaseScore(10);
                    rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

                    particle.Play();
                }
                else
                {

                    gameManager.GameOver();
                }
            }


        }



        if (collision.collider.tag == "Trap")
        {
            if (isSuperPower)
            {

            }
            else
            {
                var particle = collision.collider.gameObject.GetComponent<ParticleScript>();
                if (particle != null)
                {
                    particle.ParticalPlay();
                }
                gameManager.GameOver();
            }


        }

        if (collision.collider.tag == "Coin")
        {
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 15f, collision.gameObject.transform.position.z);
            gameManager.IncreaseCoin();
        }
    }


}
