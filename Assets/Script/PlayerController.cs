using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // 공격 애니메이션 재생
            BossManager.instance.DefeatBoss(); // 보스에게 공격을 가했을 때 처리
        }
    }
}
