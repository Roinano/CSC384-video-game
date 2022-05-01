using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{

    private PlayerState currentState;

    [SerializeField] private float mySpeed;
    public int level = 0;
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject bullet;
    public Animator animator;
    private float timer = 0;
    public SpriteRenderer fire;
    public SpriteRenderer explode;
    private EnergyBar eb;
    private bool releaseEnergy;

    //Add states here
    //public ???State var = new ???State();

    public Transform laserFirePoint;
    public LineRenderer lineRenderer;
    public GameObject startVFX;
    public GameObject endVFX;
    public List<ParticleSystem> particles;


    private void Awake() {
        gameObject.layer = 7;
    }

    void Start() {
        InitializeVar();
        eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        releaseEnergy = false;
        currentState = new PlayerNormalState();
        this.level = 0;
        MainCamera = Camera.main;
        screenBounds =
            MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        //m_transform = GetComponent<Transform>();
        FillList();
        DisableLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
    }

    public void Controller() {
        if (Input.GetKey(KeyCode.LeftControl)) {
            mySpeed = 3;
        } else {
            mySpeed = 5;
        }
        Vector3 viewPos = transform.position;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        viewPos += move * mySpeed * Time.deltaTime;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;

        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer <= 0) {
            timer = StateData.fireFrequency;
            Vector3 centre = transform.rotation * new Vector3(0.14f, 0.5f, 0);
            Instantiate(bullet, transform.position + centre, transform.rotation);
            BattleSoundManager.playSound("ps");
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (eb.slider.value == 50) {
                releaseEnergy = true;
                Battle.chargable = false;
                EnableLaser();
            }
        }
        BlastMode();
    }

    public void DestroyAfterAnimation(float time) {
        Destroy(gameObject, time);
    }

    public void BlastMode() {
        if (releaseEnergy) {
            eb.Decay();
            Battle.blastMode = true;
            ShootLaser();
        }
        if (eb.slider.value <= 0) {
            releaseEnergy = false;
            Battle.chargable = true;
            Battle.blastMode = false;
            DisableLaser();
        }
    }

    public void ShootLaser() {
        
        //Vector2 direction = (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, laserFirePoint.up);
        RaycastHit2D[] hits = Physics2D.RaycastAll(laserFirePoint.position, laserFirePoint.up);
        startVFX.transform.position = new Vector3(transform.position.x, transform.position.y +1f, 0);

        Enemy enemy = null;
        foreach (var hitted in hits) {
            enemy = hitted.transform.GetComponent<Enemy>();
            if (enemy != null) {
                break;
            }
        }
        if (enemy != null) {
            float x = (enemy.transform.position.y - transform.position.y) / 7.4f;
            if (x < 0) {
                x *= -1;
            }
            lineRenderer.SetPosition(1, new Vector3(x, 0, 0));
            endVFX.transform.position = new Vector3(transform.position.x, enemy.transform.position.y, 0);
            enemy.TakeLaserDamage();
        } else {
            lineRenderer.SetPosition(1, new Vector3(20, 0, 0));
            endVFX.transform.position = new Vector3(transform.position.x, 500, 0);
        }
    }

    public void EnableLaser() {
        lineRenderer.enabled = true;
        
        for (int i = 0; i < particles.Count; i++) {
            particles[i].Play();
        }
    }

    public void DisableLaser() {
        endVFX.transform.position = new Vector3(transform.position.x, 500, 0);
        lineRenderer.enabled = false;

        for (int i = 0; i < particles.Count; i++) {
            particles[i].Stop();
        }
    }

    public void FillList() {
        for (int i = 0; i < startVFX.transform.childCount; i++) {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null) {
                particles.Add(ps);
            }
        }
        
        for (int i = 0; i < endVFX.transform.childCount; i++) {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null) {
                particles.Add(ps);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PowerUp") {
            StateData.dead = false;
        } else {
            StateData.dead = true;
            Battle.dead = true;
        }
    }

    public void InitializeVar() {
        StateData.dead = false;
        StateData.deadCalled = false;
        StateData.invincible = true;
        StateData.invincibleTime = 2f;
        StateData.fireFrequency = 0.3f;
    }
}