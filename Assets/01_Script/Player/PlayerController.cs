using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Vector2[] transforms;
    public GameObject player;
    public GameObject attack;
    public GameObject attack2;
    public AudioClip attackClip;    
    public float moveTime;

    private AudioSource audioSource;
    private Animator playerAnim;
    private int maxLine;
    private int i;
    private int attackNum;
    private bool isMove;
    private bool canAttack = true;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        attack.SetActive(false);
        isMove = true;
        maxLine = transforms.Length;
        i = maxLine / 2;
        player.transform.position = transforms[i];
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (isMove)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if(i < maxLine - 1)
                {
                    i++;
                    MovePlayer(i);
                    playerAnim.SetFloat("MoveInput", 0.5f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if(i > 0 )
                {
                    i--;
                    MovePlayer(i);
                    playerAnim.SetFloat("MoveInput", 1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && canAttack)
            {
                audioSource.clip = attackClip;
                audioSource.Play();
                canAttack = false;
                switch (attackNum)
                {
                    case 0:
                        attackNum = 1;
                        playerAnim.SetBool("PlayerAttack", true);
                    break;

                    case 1:
                        attackNum = 0;
                        playerAnim.SetBool("PlayerAttack2", true);
                    break;
                }
            }
        }
    }

    private void MovePlayer(int i)
    {
        player.transform.DOMove(transforms[i], moveTime);
        StartCoroutine(MoveCheck());
    }

    public void OnAttack(int i)
    {
        switch (i)
        {
            case 0:
                attack.SetActive(true);
            break;

            case 1:
                attack2.SetActive(true);
            break ;
        }
    }

    public void FinishAttack()
    {
        playerAnim.SetBool("PlayerAttack",false);
        playerAnim.SetBool("PlayerAttack2", false);
        attack.SetActive(false);
        attack2.SetActive(false);
        canAttack = true;
    }

    IEnumerator MoveCheck()
    {
        isMove = false;
        yield return new WaitForSeconds(moveTime);
        playerAnim.SetFloat("MoveInput", 0);
        isMove = true;
    }

    public void OnDie()
    {
        isMove = false;
        playerAnim.SetBool("IsDie", true);
    }
}
