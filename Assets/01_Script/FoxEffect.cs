using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxEffect : MonoBehaviour
{
    private Animator effectAnim;

    private void Start()
    {
        effectAnim = GetComponent<Animator>();  
    }

    public void OnEffect()
    {
        effectAnim.SetBool("IsChange", true);
    }

    public void FinishEffect()
    {
        effectAnim.SetBool("IsChange", false);
    }
}
