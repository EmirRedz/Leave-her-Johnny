using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLetter : MonoBehaviour
{
    public Animator pressEAnimator;
    public GameObject letterHolder;
    public Animator letterHolderAnim;
    public float animTime;
    private bool canReadLetter;

    public GameObject letter1, letter2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canReadLetter = true;
            pressEAnimator.SetBool("isToggleOpen", true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canReadLetter)
        {
            letterHolder.SetActive(true);
        }

        if (letter1 != null && letter2 != null && letterHolder.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                letter1.SetActive(false);
                letter2.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && letterHolder.activeInHierarchy)
        {
            CloseLetter();
        }
    }

    public void CloseLetter()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        letterHolderAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(animTime);
        letterHolder.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        canReadLetter = false;
        pressEAnimator.SetBool("isToggleOpen", false);       
    }
}
