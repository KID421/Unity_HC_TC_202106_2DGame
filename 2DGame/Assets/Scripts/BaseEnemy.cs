using UnityEngine;

/// <summary>
/// 敵人基底類別
/// 功能：隨機走動、等待、追蹤玩家、受傷與死亡 - 狀態檢查能
/// 狀態機：列舉 Enum、判斷式 switch (基礎語法)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region 欄位
    [Header("基本能力")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;
    
    // 將私人欄位顯示在屬性面板上
    [SerializeField]
    private StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    /// <summary>
    /// 等待時間：隨機
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// 等待用計時器
    /// </summary>
    private float timerIdle;
    #endregion

    #region 事件
    private void Start()
    {
        #region 初始值設定
        timeIdle = Random.Range(1f, 5f);
        #endregion
    }

    private void Update()
    {
        CheckState();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 檢查狀態
    /// </summary>
    private void CheckState()
    {
        switch (state)
        {
            case StateEnemy.idle:
                Idle();
                break;
            case StateEnemy.walk:
                Walk();
                break;
            case StateEnemy.track:
                break;
            case StateEnemy.attack:
                break;
            case StateEnemy.dead:
                break;
        }
    }

    /// <summary>
    /// 等待：隨機秒數後進入到走路狀態
    /// 判定後切換至走路狀態
    /// </summary>
    private void Idle()
    {
        if (timerIdle < timeIdle)               // 如果 計時器 < 等待時間
        {
            timerIdle += Time.deltaTime;        // 累加時間
            print("等待");
        }
        else                                    // 否則
        {
            state = StateEnemy.walk;            // 切換狀態
            timerIdle = 0;                      // 計時器歸零
        }
    }

    /// <summary>
    /// 隨機走路
    /// </summary>
    private void Walk()
    {
        print("走路");
    }
    #endregion
}

// 定義列舉
// 1. 使用關鍵字 enum 定義列舉以及包含的選項，可以在類別外定義
// 2. 需要有一個欄位定義為此列舉類型
// 語法：修飾詞 enum 列舉名稱 { 選項1，選項2，....，選項N }
public enum StateEnemy
{
    idle, walk, track, attack, dead
}