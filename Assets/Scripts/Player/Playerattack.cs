using System.Collections;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public GameObject attackArea;
    private bool attacking = false;
    public Animator anim;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the attack area initially
        attackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !attacking)
        {
            StartCoroutine(PerformAttack());
        }
        
    }

    IEnumerator PerformAttack()
    {
        attacking = true;
        anim.SetTrigger("attack");

        // Wait for the specified delay before spawning the attack area
        yield return new WaitForSeconds(timeToAttack);

        // Enable the attack area
        attackArea.SetActive(true);

        // Wait for a short duration to match the animation (adjust as needed)
        yield return new WaitForSeconds(0.1f);

        // Disable the attack area
        attackArea.SetActive(false);

        attacking = false;
    }
}
