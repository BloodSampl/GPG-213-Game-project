using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private MeshCollider attackArea;
    private bool attacking = false;

    [SerializeField] float timeToAttack = 0.25f;
    private float timer = 0f;
    [SerializeField] Animator anim;

    private void Start()
    {
       attackArea = transform.GetChild(1).GetChild(0).GetComponent<MeshCollider>();
    }
    private void Update()
    {
       StartCoroutine("Attack");
    }
    IEnumerator Attack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !attacking)
        {
            attacking = true;

            attackArea.enabled = true;
            anim.SetBool("Attacking", true);
            yield return new WaitForSeconds(timeToAttack);
            attackArea.enabled = false;
            anim.SetBool("Attacking", false);
            attacking = false;
        }
    }
}
