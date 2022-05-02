using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Enemy {
    private BossState currentState;
    private BossState readyState;
    private bool doingState = true;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public int spreadMode = 1;

    public Transform laserFirePoint;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    public LineRenderer lineRenderer3;
    public LineRenderer lineRenderer4;
    public GameObject VFX1;
    public GameObject VFX2;
    public GameObject VFX3;
    public GameObject VFX4;
    public List<ParticleSystem> particles;

    public GameObject location1;
    public GameObject location2;
    public GameObject location3;
    public GameObject location4;
    public bool toLocation1 = false;
    public bool toLocation2 = false;
    public bool toLocation3to4 = false;
    public bool atLocation3 = false;
    public bool rotating = false;

    public Animator animator;
    public SpriteRenderer fire;
    public SpriteRenderer explode;
    private BossHPbar bhp;
    // Start is called before the first frame update
    void Start() {
        bhp = GameObject.FindGameObjectWithTag("BossHPbar").GetComponent<BossHPbar>();
        toLocation1 = true;
        explode.enabled = false;
        health = 3000;
        score = 100000;
        attackCharge = 2;
        ChangeState(new BossStateOne());
        FillList();
        DisableLaser();
    }

    // Update is called once per frame
    void Update() {
        if (!Battle.bossDead) {
            bhp.transform.position = Vector3.MoveTowards(bhp.transform.position, new Vector3(0, 7.2f, 0), 40f * Time.deltaTime);
            if (!doingState) {
                currentState = readyState;
            }
            if (currentState != null) {
                currentState = currentState.DoState(this);
                doingState = true;
            }
        
            if (toLocation1) {
                transform.position = Vector3.MoveTowards(transform.position, location1.transform.position, 3 * Time.deltaTime);
                if (transform.position == location1.transform.position) {
                    toLocation1 = false;
                    doingState = false;
                }
            } else if (toLocation2) {
                transform.position = Vector3.MoveTowards(transform.position, location2.transform.position, 8 * Time.deltaTime);
                if (transform.position == location2.transform.position) {
                    toLocation2 = false;
                    doingState = false;
                }
            } else if (toLocation3to4) {
                GameObject target = location3;
                float speed = 4;
                if (transform.position == location3.transform.position) {
                    atLocation3 = true;
                    doingState = false;
                }

                if (atLocation3) {
                    target = location4;
                    speed = 0.5f;
                }
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                if (transform.position == location4.transform.position) {
                    toLocation3to4 = false;
                    atLocation3 = false;
                }
            }
            if (rotating) {
                if (transform.rotation.z != 0) {
                    if (transform.rotation.z < 0) {
                        transform.Rotate(new Vector3(0, 0, 1f));
                    } else {
                        transform.Rotate(new Vector3(0, 0, 1f));
                    }
                
                } else {
                    rotating = false;
                }
            }
            bhp.SetValue(health);
            HurtCountDown();
        }
    }



    public void BulletSpread() {
        for (int i = 0; i < 24; i++) {
            if (spreadMode == 1) {
                bullet.GetComponent<BossBullet>().rotation = 15f * i;
            } else if (spreadMode == 2) {
                bullet.GetComponent<BossBullet>().rotation = 7.5f + 15f * i;
            } else if (spreadMode == 3) {
                bullet.GetComponent<BossBullet>().rotation = 3.75f + 15f * i;
            } else if (spreadMode == 4) {
                bullet.GetComponent<BossBullet>().rotation = 1.875f + 15f * i;
            }

            Vector3 centre = transform.rotation * new Vector3(0, -0.5f, 0);
            Instantiate(bullet, transform.position + centre, transform.rotation);
        }
        spreadMode = Random.Range(1, 5);
    }

    public void BulletRandom() {
        bullet2.GetComponent<BossBulletTwo>().rotation = Random.Range(0, 360);
        Vector3 centre = transform.rotation * new Vector3(0, -0.5f, 0);
        Instantiate(bullet2, transform.position + centre, transform.rotation);
    }

    public void Bullet2Random() {
        bullet3.GetComponent<BossBulletThree>().rotation = Random.Range(0, 360);
        Vector3 centre = transform.rotation * new Vector3(0, -0.5f, 0);
        Instantiate(bullet3, transform.position + centre, transform.rotation);
    }

    public void MoveToLocation1() {
        toLocation1 = true;
        rotating = true;
    }

    public void MoveToLocation2() {
        toLocation2 = true;
        rotating = true;
    }
    
    public void MoveLocation3to4() {
        toLocation3to4 = true;
        rotating = true;
    }

    public void FillList() {
        for (int i = 0; i < VFX1.transform.childCount; i++) {
            var ps = VFX1.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null) {
                particles.Add(ps);
            }
        }

        for (int i = 0; i < VFX2.transform.childCount; i++) {
            var ps = VFX2.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null) {
                particles.Add(ps);
            }
        }
        
        for (int i = 0; i < VFX3.transform.childCount; i++) {
            var ps = VFX3.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null) {
                particles.Add(ps);
            }
        }
        
        for (int i = 0; i < VFX4.transform.childCount; i++) {
            var ps = VFX4.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null) {
                particles.Add(ps);
            }
        }
    }

    public void EnableLaser() {
        lineRenderer1.enabled = true;
        lineRenderer2.enabled = true;
        lineRenderer3.enabled = true;
        lineRenderer4.enabled = true;
        lineRenderer1.gameObject.layer = 10;
        lineRenderer2.gameObject.layer = 10;
        lineRenderer3.gameObject.layer = 10;
        lineRenderer4.gameObject.layer = 10;

        for (int i = 0; i < particles.Count; i++) {
            particles[i].Play();
        }
    }

    public void DisableLaser() {
        lineRenderer1.enabled = false;
        lineRenderer2.enabled = false;
        lineRenderer3.enabled = false;
        lineRenderer4.enabled = false;
        lineRenderer1.gameObject.layer = 11;
        lineRenderer2.gameObject.layer = 11;
        lineRenderer3.gameObject.layer = 11;
        lineRenderer4.gameObject.layer = 11;

        for (int i = 0; i < particles.Count; i++) {
            particles[i].Stop();
        }
    }

    public void ShootLaser(float direction) {

        laserFirePoint.transform.Rotate(direction * new Vector3(0, 0, 0.15f));
    }

    public void ChangeState(BossState state) {
        readyState = state;
    }


    public override void Movement() {
        
    }

    public override void Shooting() {
        
    }

    public override void Initialize() {
        
    }

    public override void DeadAnimation() {
        StartCoroutine(Dead(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Dead(int sceneLevel) {
        gameObject.layer = 11;
        fire.enabled = false;
        explode.enabled = true;
        Battle.bossDead = true;
        DisableLaser();
        animator.SetTrigger("boss_dead");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
