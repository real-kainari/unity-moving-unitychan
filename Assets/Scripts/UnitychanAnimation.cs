using UnityEngine;

public class UnitychanAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;



    public void SetIsWalk(bool isWalk)
    {
        animator.SetBool("IsWalk", isWalk);
    }

    public void SetIsRun(bool isRun)
    {
        animator.SetBool("IsRun", isRun);
    }

    public void JumpTrigger()
    {
        animator.SetTrigger("JumpTrigger");
    }
}