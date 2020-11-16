using UnityEngine;

public enum DialogueType
{
    oneShoot,
    sign,
    npc
}
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isPlayerOnTrigger;
    private bool isDialogueOpen;
    public DialogueType Type;
    private PlayerController player;
    void Start()
    {
        isDialogueOpen = false;

        if (Type == DialogueType.oneShoot)
        {
            Invoke("OpenTriggerDialogue", 1f);
        }
    }

    void Update()
    {
        if (Type == DialogueType.sign)
        {
            if (Input.GetButtonDown(KeyCode.Return.ToString()) && isPlayerOnTrigger)
            {
                Debug.Log("ShowMeThe Message");
                if (!isDialogueOpen)
                    OpenTriggerDialogue();

                if (isDialogueOpen)
                    EndTriggerDialogue();
            }
        }

        if (Type == DialogueType.oneShoot)
        {
            if (Input.GetButtonDown(KeyCode.Return.ToString()))
            {
                if (isDialogueOpen)
                    EndTriggerDialogue();
            }
        }
    }

    public void OpenTriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Invoke("ChangeIsDialogOpen", 0.5f);
    }


    public void EndTriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        Invoke("ChangeIsDialogOpen", 0.5f);
    }


    public void ChangeIsDialogOpen()
    {
        isDialogueOpen = !isDialogueOpen;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTrigger = true;
            player = collision.GetComponent<PlayerController>();
            player.ActiveClueSign();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        EndTriggerDialogue();
        if (player != null)
            player.DesactiveClueSign();
        isPlayerOnTrigger = false;
    }
}
