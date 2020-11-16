using System.Collections;
using UnityEngine;

public enum ColorFeedbackType
{
    damage, recovery, door
}


public class ColorFeedback : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySprite;
    public Color flashColor;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float flashDelay;
    private bool isFlashing = false;
    private AudioSource audioSource;
    public AudioClip audioHurt;
    [SerializeField] ColorFeedbackType colorFeedback;

    public void Awake()
    {

        audioSource = GetComponent<AudioSource>();

        if (colorFeedback == ColorFeedbackType.damage)
            flashColor = Color.red;

        if (colorFeedback == ColorFeedbackType.recovery)
            flashColor = Color.green;

        if (colorFeedback == ColorFeedbackType.door)
            flashColor = Color.gray;
    }
    public void StartFlash()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashCo());
        }
    }

    public IEnumerator FlashCo()
    {
        if (audioHurt != null)
        { audioSource.clip = audioHurt; audioSource.Play(); }

        isFlashing = true;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (mySprite)
            {
                mySprite.color = flashColor;
                yield return new WaitForSeconds(flashDelay);
                mySprite.color = Color.white;
                yield return new WaitForSeconds(flashDelay);
            }
        }
        isFlashing = false;
    }
}
