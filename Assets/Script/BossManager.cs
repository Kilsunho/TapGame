using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복된 BossManager 인스턴스 방지
        }
    }

    // 보스 클리어 처리
    public void DefeatBoss()
    {
        GameManager.instance.ClearBoss(); // 보스 클리어 시 GameManager에게 알림
    }
}
