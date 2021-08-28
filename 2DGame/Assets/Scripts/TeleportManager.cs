using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 傳送門管理：判斷玩家是否進入以及完成關卡任務
/// </summary>
public class TeleportManager : MonoBehaviour
{
    // 1. 靜態為此類別所有物件共用資料：複數物件較不適合使用靜態
    // 2. 靜態在載入場景後不會恢復預設值
    // 3. 靜態欄位不會顯示在屬性面板

    /// <summary>
    /// 所有怪物數量
    /// </summary>
    public static int countAllEnemy;

    // Unity Button 按鈕事件自行定義方式
    // 1. 引用 UnityEngine.Events API
    // 2. 定義 UnityEvent 欄位
    // 3. 需要執行事件的地方使用 Invoke() 呼叫
    // 4. 僅限呼叫無參數或一個參數的方法
    [Header("過關事件")]
    public UnityEvent onPass;

    private void Start()
    {
        countAllEnemy = GameObject.FindGameObjectsWithTag("怪物").Length;
    }

    // 觸發事件：Trigger
    // 1. 兩個碰撞物件都要有 Collider 
    // 2. 並且其中一個要有 Rigidbody
    // 3. 兩個其中一個有勾選 Is Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果 進入傳送門的是主角 並且 怪物數量 為零 就可以過關
        if (collision.name == "主角" && countAllEnemy == 0)
        {
            onPass.Invoke();
        }
    }
}
