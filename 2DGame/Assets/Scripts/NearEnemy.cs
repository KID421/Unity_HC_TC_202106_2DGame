using UnityEngine;
using System.Collections;   // 引用 系統.集合 - 協同程序

/// <summary>
/// 近距離攻擊敵人類型：近距離攻擊
/// </summary>
// 類別 : 父類別
// : 冒號後面第一個代表的是要繼承的類別
public class NearEnemy : BaseEnemy
{
    #region 欄位
    [Header("攻擊區域的位移與大小")]
    public Vector2 checkAttackOffset;
    public Vector3 checkAttackSize;
    #endregion

    #region 事件
    protected override void OnDrawGizmos()
    {
        // 父類別原本的程式內容
        base.OnDrawGizmos();

        Gizmos.color = new Color(0.5f, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(
            transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize);
    }

    protected override void Update()
    {
        base.Update();

        CheckPlayerInAttackArea();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 檢查玩家是否進入攻擊區域
    /// </summary>
    private void CheckPlayerInAttackArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize, 0, 1 << 7);

        // 如果 碰到物件為玩家 就將狀態改為 攻擊
        if (hit) state = StateEnemy.attack;
    }

    protected override void AttackMethod()
    {
        base.AttackMethod();

        StartCoroutine(DelaySendDamageToPlayer());          // 啟動協同程序
    }

    // 協同程序用法：
    // 1. 引用 System.Collections API
    // 2. 傳回方法，傳回類型為 IEnumerator
    // 3. 使用 StartCoroutine() 啟動協同程序
    /// <summary>
    /// 延遲將傷害傳給玩家
    /// </summary>
    private IEnumerator DelaySendDamageToPlayer()
    {
        yield return new WaitForSeconds(attackDelayFirst);
        print("第一次攻擊");
        player.Hurt(attack);
    }
    #endregion
}
