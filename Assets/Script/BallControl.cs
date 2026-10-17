using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallControl : MonoBehaviour
{
    Rigidbody rb;
    
    public float speed = 10f; 
    public float jumpSpeed;
    private float jumpForce;
    public bool onGround;
    private int Coin;
    public TextMeshProUGUI coinUI;
    public int targetScore;
    public string nextScene;
    private AudioSource coinSound;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        coinSound = this.GetComponent<AudioSource>();
        
        Coin = 0;

        //60 FPS
        Application.targetFrameRate = 120; 
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jumpForce = jumpSpeed;
            onGround = false; 
        }
        else
        {
            jumpForce = 0;
        }

        Vector3 movement = new Vector3(moveHorizontal, jumpForce, moveVertical);
        rb.AddForce(movement * speed);

        if (!onGround)
        {
            jumpForce = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            Destroy(other.gameObject);

            Coin++;
            coinUI.text = "Coin: " + Coin;

            targetScore--;
            if (targetScore == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
        else if (other.gameObject.tag == "Boundary")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        this.transform.localScale *= 1.1f;
    }
}
