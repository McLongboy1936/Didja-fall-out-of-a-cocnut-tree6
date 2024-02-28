
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//[RequiredComponent(typeof(audioSource))]

public class LoadEndScene : MonoBehaviour
{
    //[SerializeField] private AudioSource WinSoundEffect;
    public AudioSource source;
    public AudioClip bonkSound;
    public Sprite bonked;

    private SpriteRenderer spriteRenderer;
    
   // private AudioSource source;
   // public  VictorySound;
   [SerializeField] private StateMachine stateMachine;

    public void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        stateMachine.Play();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void LoadFinalScene()
    {
 
    }
    public void ChangeSprite()
    {
        if (spriteRenderer != null && bonked != null)
        {
            spriteRenderer.sprite = bonked;
        }
    }
    public void callWin()
    {
        stateMachine.Win();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        ChangeSprite();
        source.PlayOneShot(bonkSound);
        
         if (stateMachine == null)
        {
            Debug.Log("Otherscript is null");
        }
        //Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            Invoke("callWin", 2f);
            // source.PlayOneShot(audioClip);
        }

    }
}

