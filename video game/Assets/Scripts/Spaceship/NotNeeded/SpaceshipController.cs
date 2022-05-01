using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour {
    [SerializeField] private Transform myForward;
    [SerializeField] private float mySpeed;
    private int level = 0;
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private bool isCrash;
    private bool notCalled = true;
    private float invincibleTime;
    public GameObject bullet;
    public Animator animator;
    private float fireFrequency = 0.3f;
    private float timer = 0;
    public SpriteRenderer fire;
    public SpriteRenderer explode;

    private Vector3 leftEdge;
    private Vector3 rightEdge;

    // Start is called before the first frame update
    void Start() {
        this.level = 0;
        MainCamera = Camera.main;
        
        screenBounds =
            MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        Invincible();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftControl)) {
            mySpeed = 3;
        } else {
            mySpeed = 5;
        }
        //Debug.Log(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

        if (!isCrash) {
            Vector3 viewPos = transform.position;
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            viewPos += move * mySpeed * Time.deltaTime;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;

            timer -= Time.deltaTime;

            if (Input.GetKey(KeyCode.Space) && timer <= 0) {
                timer = fireFrequency;
                Vector3 centre = transform.rotation * new Vector3(0.14f, 0.5f, 0);
                Instantiate(bullet, transform.position + centre, transform.rotation);
                BattleSoundManager.playSound("ps");
            }

            if (invincibleTime <= 0) {
                animator.SetBool("Invincible", false);
                gameObject.layer = 6;
            } else {
                gameObject.layer = 7;
                invincibleTime -= Time.deltaTime;
            }
        } else if (isCrash && notCalled) {
            Die();
        }
    }

    public void Powerup() {
        level++;
        if (level == 1) {
            fireFrequency = 0.01f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Powerup" || other.tag == "PowerUp") {
            isCrash = false;
        } else { 
            isCrash = true;
        }
    }

    public void Die() {
        notCalled = false;
        fire.enabled = false;
        Battle.lifes = Battle.lifes-1;
        //float life = PlayerPrefs.GetFloat("Lifes");
        //PlayerPrefs.SetFloat("Lifes", life--);
        BattleSoundManager.playSound("pd");
        
        if (Battle.lifes <= 0) {
            StartCoroutine(checkLife(SceneManager.GetActiveScene().buildIndex + 1));
        } else {
            animator.SetBool("Dead", true);
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
        
        //Destroy(gameObject);
    }

    public void Invincible() {
        notCalled = true;
        invincibleTime = 2f;
        isCrash = false;
        animator.SetBool("Invincible", true);
    }

    IEnumerator checkLife(int sceneLevel) {
        
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        print("Loading");
        SceneManager.LoadScene(2);
        
    }
}
