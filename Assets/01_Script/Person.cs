using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private Animator personAnim;
    private Movement personMovement;
    private ScoreSystem scoreSystem;

    private void Start()
    {
        personAnim = GetComponent<Animator>();
        personMovement = GetComponent<Movement>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -7 || gameObject.transform.position.x <= -4)
        {
            Destroy(gameObject);
        }
    }

    public void OnDie()
    {
        scoreSystem.Score -= 200;
        personAnim.SetBool("IsDie", true);

        if(gameObject.transform.position.x < 0)
        {
            personMovement.moveDirection = new Vector3(-1, -1, 0);
        }
        else
        {
            personMovement.moveDirection = new Vector3(1, -1, 0);
        }
    }
}
