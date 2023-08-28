using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Threading;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public LifeManager lifeManager;
    private float xBound1 = 2.5f;
    private float xBound2 = -13f;
    public float yBound1 = 3.9f;
    public float yBound2 = -35;
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    private Transform player;
    private Animator animator;
    public CameraShake cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;
    private bool isHurt;
    public static int numberOfCoins=0;
    private Quaternion initialRotation;
    private Vector2 movement;
    private float rotationAngle = 45f;
    public TextMeshProUGUI coinsText;
    private Quaternion targetRotation = Quaternion.identity;
    private Rigidbody2D rb;
    public AudioSource coins;
    public AudioSource hurt;
    [SerializeField]private GameObject gameOver;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject help;


    void Awake()
    {
        GameOver.gameOverFlag = false;
        gameOver.SetActive(false);
        settings.SetActive(false);
        help.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        initialRotation = transform.rotation;

        player = transform.Find("player");
        animator = player.GetComponent<Animator>();
        isHurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        /*if (PauseGame.isPaused)
        {
            return;
        }
        if(GameOver.gameOverFlag)
        {
            return;
        }*/
        //movement direction vector
        movement = new Vector2(horizontal, vertical);
        coinsText.text = numberOfCoins.ToString();
        //checking movement direction
        float localScaleX = Mathf.Abs(transform.localScale.x);
        if (horizontal > 0)
        {
            targetRotation = Quaternion.Euler(0, 0, rotationAngle);
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
        if (horizontal < 0)
        {
            targetRotation = Quaternion.Euler(0, 0, -rotationAngle);
            transform.localScale = new Vector3(-localScaleX, transform.localScale.y, transform.localScale.z);
        }
        if (horizontal == 0f)
        {
            targetRotation = initialRotation;
        }

        //checking bounds and keeping the player inside bound
        if (transform.position.x >= xBound1)
            transform.position = new Vector3(xBound1, transform.position.y, 0);
        if (transform.position.x <= xBound2)
            transform.position = new Vector3(xBound2, transform.position.y, 0);
        if (transform.position.y >= yBound1)
        {
            lifeManager.LessenLife();
            transform.position = new Vector3(transform.position.x, yBound1-10, 0);
        }
        if (transform.position.y <= yBound2)
            transform.position = new Vector3(transform.position.x, yBound2, 0);

        //checking getting hurt
        GetHurt();
    }


    private void FixedUpdate()
    {
        //check for movement direction and move the player
        if (movement != null)
        {
            rb.velocity = movement.normalized * speed;
        }

        //rotate the player
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        rb.MoveRotation(rotation);

    }

    public void GetHurt()
    {
        if(isHurt)
        {
            hurt.Play();
            animator.SetBool("isHurt", true);
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
        }
        else
        {
            animator.SetBool("isHurt", false);
        }
    }

    public void setIsHurt(bool val)
    {
        isHurt = val;
    }

    public bool getHurtVal()
    {
        return isHurt;
    }

    public void incrementCoins()
    {
        coins.Play();
        numberOfCoins++;
    }

    public void setCoins(int coins)
    {
        numberOfCoins = coins;
    }
}
