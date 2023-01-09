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
    public float moveTime;

    private Animator playerAnim;
    private int maxLine;
    private int i;
    private bool isMove;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
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
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(i < maxLine - 1)
                {
                    i++;
                    MovePlayer(i);
                    playerAnim.SetFloat("MoveInput", 0.5f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(i > 0 )
                {
                    i--;
                    MovePlayer(i);
                    playerAnim.SetFloat("MoveInput", 1f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }
    }

    private void MovePlayer(int i)
    {
        player.transform.DOMove(transforms[i], moveTime);
        StartCoroutine(MoveCheck());
    }

    IEnumerator MoveCheck()
    {
        isMove = false;
        yield return new WaitForSeconds(moveTime);
        playerAnim.SetFloat("MoveInput", 0);
        isMove = true;
    }

    IEnumerator Attack()
    {
        attack.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attack.SetActive(false);
    }
}
