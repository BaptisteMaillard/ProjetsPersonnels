using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInrange;

    public Item item;
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
            TakeItem();
        }
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);
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
