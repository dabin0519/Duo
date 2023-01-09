using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Vector2[] transforms;
    public GameObject player;
    public float moveTime;

    private int maxLine;
    private int i;
    private bool isMove;

    private void Start()
    {
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

                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(i > 0 )
                {
                    i--;
                    MovePlayer(i);
                }
            }

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
        isMove = true;
    }
}
