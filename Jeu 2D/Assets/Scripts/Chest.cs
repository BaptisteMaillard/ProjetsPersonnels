using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInrange;

    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundToPlay;

    // Start is called before the first frame update
    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInrange)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInrange = false;
        }
    }


}
