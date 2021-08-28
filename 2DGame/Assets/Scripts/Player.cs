using UnityEngine;
using UnityEngine.UI;                   // 引用 介面 API
using UnityEngine.Events;

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
    [Header("攻擊冷卻"), Range(0, 5)]
    public float cd = 2;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 20;
    [Header("攻擊區域的位移與大小")]
    public Vector2 checkAttackOffset;
    public Vector3 checkAttackSize;
    [Header("死亡事件")]
    public UnityEvent onDead;
    [Header("音效區域")]
    public AudioClip soundJump;
    public AudioClip soundAttack;

    // 私人欄位不顯示
    // 開啟屬性面板除錯模式 Debug 可以看到私人欄位
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    /// <summary>
    /// 玩家水平輸入值
    /// </summary>
    private float hValue;
    /// <summary>
    /// 攻擊計時器
    /// </summary>
    private float timer;
    /// <summary>
    /// 是否攻擊
    /// </summary>
    private bool isAttack;
    /// <summary>
    /// 文字血量
    /// </summary>
    private Text textHp;
    /// <summary>
    /// 血條
    /// </summary>
    private Image imgHp;
    /// <summary>
    /// 血量最大值：保存血量最大數值
    /// </summary>
    private float hpMax;
    /// <summary>
    /// 攝影機控制類別
    /// </summary>
    private CameraControl cameraControl;
    /// <summary>
    /// 儲存碰撞物件資訊
    /// </summary>
    private GameObject goPropHit;
    #endregion

    #region 事件
    private void Start()
    {
        // GetComponent<類型>() 泛型方法，可以指定任何類型
        // 作用：取得此物件的 2D 剛體元件
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        hpMax = hp;

        textHp = GameObject.Find("文字血量").GetComponent<Text>();
        imgHp = GameObject.Find("血條").GetComponent<Image>();

        cameraControl = GameObject.Find("攝影機").GetComponent<CameraControl>();
    }

    // 一秒約執行 60 次
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
        Attack();
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

        Gizmos.color = new Color(0.5f, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(
            transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize);
    }

    // 碰撞事件：Collision
    // 1. 兩個碰撞物件都要有 Collider 
    // 2. 並且其中一個要有 Rigidbody
    // 3. 兩個都沒有勾選 Is Trigger
    // Enter 事件：碰撞開始時執行一次
    private void OnCollisionEnter2D(Collision2D collision)
    {
        goPropHit = collision.gameObject;
        EatProp(collision.gameObject.tag);
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
        // 控制走路動畫：不等於零時 勾選，等於零時 取消
        ani.SetBool("走路開關", horizontal != 0);
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

        // 設定動畫參數 與 是否在地板上 相反
        ani.SetBool("跳躍開關", !isGround);

        // 如果 在地板上 並且 玩家 按下 空白鍵 角色就往上跳躍
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jump));
            aud.PlayOneShot(soundJump, Random.Range(0.7f, 1.1f));
        }
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        // 如果 不是攻擊中 並且 按下 左鍵 才可以攻擊 啟動觸發參數
        if (!isAttack && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttack = true;
            ani.SetTrigger("攻擊觸發");
            aud.PlayOneShot(soundAttack, Random.Range(0.7f, 1.1f));

            // 判定攻擊區域是否有打到 8 號敵人圖層物件
            Collider2D hit = Physics2D.OverlapBox(transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize, 0, 1 << 8);

            // 擊中物件存在時 對其造成傷害
            if (hit)
            {
                hit.GetComponent<BaseEnemy>().Hurt(attack);     // 敵人 受傷
                StartCoroutine(cameraControl.ShakeEffect());    // 攝影機 晃動
            }
        }

        // 如果按下左鍵攻擊中就開始累加時間
        if (isAttack)
        {
            if (timer < cd)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                isAttack = false;
            }
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    public void Hurt(float damage)
    {
        hp -= damage;                       // 血量扣除傷害值

        if (hp <= 0) Dead();                // 如果 血量 <= 0 就 死亡

        textHp.text = "HP " + hp;           // 文字血量.文字內容 = "HP " + 血量
        imgHp.fillAmount = hp / hpMax;      // 血條.填滿數值 = hp / hpMax
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        hp = 0;                             // 血量歸零
        ani.SetBool("死亡開關", true);       // 死亡動畫
        onDead.Invoke();                    // 呼叫死亡事件
        enabled = false;                    // 關閉此腳本
    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="propName">吃到的道具名稱</param>
    private void EatProp(string propName)
    {
        switch (propName)
        {
            case "蘋果":
                Destroy(goPropHit);             // 刪除(物件，延遲時間)
                hp += 10;
                hp = Mathf.Clamp(hp, 0, hpMax); // 夾住 HP 在範圍內
                textHp.text = "HP " + hp;       // 更新介面
                imgHp.fillAmount = hp / hpMax;
                break;
            default:
                break;
        }
    }
    #endregion
}
