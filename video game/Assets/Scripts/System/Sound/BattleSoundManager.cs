using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSoundManager : MonoBehaviour
{
    public static AudioClip playerShoot, playerDead, enemyDead, enemyHurt;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = Resources.Load<AudioClip>("PlayerShoot");
        playerDead = Resources.Load<AudioClip>("PlayerDead");
        enemyHurt = Resources.Load<AudioClip>("EnemyHurt");
        enemyDead = Resources.Load<AudioClip>("EnemyDead");

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void playSound(string type) {
        audioSrc.volume = PlayerPrefs.GetFloat("SE");
        switch (type) {
            case "ps":
                audioSrc.PlayOneShot(playerShoot);
                break;
            case "pd":
                audioSrc.PlayOneShot(playerDead);
                break;
            case "ed":
                audioSrc.PlayOneShot(enemyDead);
                break;
            case "eh":
                audioSrc.volume /= 2;
                audioSrc.PlayOneShot(enemyHurt);
                break;
        }
    }
}
