using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 30000)]
    public int jump = 100;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("用來儲存角色是否在地板上的資訊，在地板上 true、不在地板上 false")]
    public bool isGround;
    [Header("重力"), Range(0.01f, 1)]
    public float gravity = 1;
    [Header("檢查地板區域：位移與半徑")]
    public Vector3 groundOffset;
    [Range(0, 2)]
    public float groundRadius = 0.5f;

    // 私人欄位不顯示
    // 開啟屬性面板除錯模式 Debug 可以看到私人欄位
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    /// <summary>
    /// 玩家水平輸入值
    /// </summary>
    private float hValue;
    #endregion

    #region 事件
    private void Start()
    {
        // GetComponent<類型>() 泛型方法，可以指定任何類型
        // 作用：取得此物件的 2D 剛體元件
        rig = GetComponent<Rigidbody2D>();
    }

    // 一秒約執行 60 次
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
    }

    // 固定更新事件
    // 一秒固定執行 50 次，官方建議有使用到物理 API 要在此事件內執行
    private void FixedUpdate()
    {
        Move(hValue);
    }

    // 繪製圖示事件：輔助開發者用，僅會顯示在編輯器 Unity 內
    private void OnDrawGizmos()
    {
        // 先決定顏色在繪製圖示
        Gizmos.color = new Color(1, 0, 0, 0.3f);    // 半透明紅色
        // 繪製球體(中心點，半徑)
        Gizmos.DrawSphere(transform.position + groundOffset, groundRadius);
    }
    #endregion

    #region 方法
    /// <summary>
    /// 取得玩家輸入水平軸向值：A、D、左、右
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        // 水平值 = 輸入.取得軸向(軸向名稱)
        // 作用：取得玩家按下水平按鍵的值，按右為 1，按左為 -1，沒按為 0
        hValue = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">左右數值</param>
    private void Move(float horizontal)
    {
        /** 第一種移動方式：自訂重力
        // 區域變數：在方法內的欄位，有區域性，僅限於此方法內存取
        // 簡寫：transform 此物件的 Transform 變形元件
        // posMove = 角色當前座標 + 玩家輸入的水平值
        // Time.fixedDeltaTime 指 1/50 秒
        Vector2 posMove = transform.position + new Vector3(horizontal, -gravity, 0) * speed * Time.fixedDeltaTime;
        // 剛體.移動座標(要前往的座標)
        rig.MovePosition(posMove);
        */

        /** 第二種移動方式：使用專案內的重力 - 較緩慢 */
        rig.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, rig.velocity.y);
    }

    /// <summary>
    /// 旋轉方向：處理角色面向問題，按右角度 0，按左角度 180
    /// </summary>
    private void TurnDirection()
    {
        // 如果 玩家按 D 就將角度設定為 0, 0, 0
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        // 如果 玩家按 A 就將角度設定為 0, 180, 0
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // Vector2 參數可以使用 Vector3 代入，程式會自動把 Z 軸取消
        // << 位移運算子
        // 指定圖層語法：1 << 圖層編號
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundOffset, groundRadius, 1 << 6);

        // 如果 碰到物件存在 就代表在地面上 否則 就代表不在地面上
        // 判斷式如果只有 一個結束符號； 可以省略大括號
        if (hit) isGround = true;
        else isGround = false;

        // 如果 在地板上 並且 玩家 按下 空白鍵 角色就往上跳躍
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jump));
        }
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    public void Hurt(float damage)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="propName">吃到的道具名稱</param>
    private void EatProp(string propName)
    {

    }
    #endregion
}
