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

        if (isSuperPower)
        {
            transform.position = new Vector3((transform.position.x + otherPlayer.position.x) / 2, transform.position.y, transform.position.z);
            otherPlayer.position = new Vector3((transform.position.x + otherPlayer.position.x) / 2, otherPlayer.transform.position.y, otherPlayer.transform.position.z);
            rigidBody.velocity = new Vector2(0, verticalVelocity+2);
        }
        else
        {
            rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        }

        if (Input.GetButtonDown("Jump"))
        {

            horizontalVelocity = -(horizontalVelocity);
            rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        }

    }

    public void MakeBoost()
    {
        gameObject.layer = 10;
        isSuperPower = true;
        StartCoroutine(RemoveBoost());
    }

    private IEnumerator RemoveBoost()
    {
        yield return new WaitForSeconds(2.5f);
        isSuperPower = false;
        gameObject.layer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Bonus")
        {

            if (isSuperPower)
            {
                collision.collider.gameObject.transform.position = new Vector3(-collision.collider.gameObject.transform.position.x, collision.collider.gameObject.transform.position.y + 100f, collision.collider.gameObject.transform.position.z);
                gameManager.IncreaseScore(10);
                rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

                particle.Play();
            }
            else
            {
                if (collision.collider.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
                {

                    collision.collider.gameObject.transform.position = new Vector3(-collision.collider.gameObject.transform.position.x, collision.collider.gameObject.transform.position.y + 100f, collision.collider.gameObject.transform.position.z);
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
            if (!isSuperPower)
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
            collision.gameObject.transform.position = new Vector3(-collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 100f, collision.gameObject.transform.position.z);
            gameManager.IncreaseCoin();
        }

        if (collision.collider.tag == "Boost")
        {
            collision.gameObject.transform.position=new Vector3(-collision.gameObject.transform.position.x,collision.gameObject.transform.position.y+100f,collision.gameObject.transform.position.z);
            MakeBoost();
            otherPlayer.GetComponent<PlayerMovement>().MakeBoost();
        }
    }


}
