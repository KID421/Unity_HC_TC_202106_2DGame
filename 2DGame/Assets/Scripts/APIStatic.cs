using UnityEngine;

/// <summary>
/// 認識 API 以及第一種用法：靜態 static
/// </summary>
public class APIStatic : MonoBehaviour
{
    // API 文件，分為兩大類
    // 1. 靜　態：有關鍵字 static
    // 2. 非靜態：無關鍵字 static

    // 屬性：Properties 可以理解為等同於欄位
    // 方法：Methods

    public float number = 9.99f;
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22, 22, 22);

    private void Start()
    {
        #region 認識靜態屬性與方法
        // 靜態屬性
        // 1. 取得
        // ※ 語法：類別.靜態屬性
        print("隨機值：" + Random.value);           // 0 - 1
        print("無限大：" + Mathf.Infinity);

        // 2. 設定
        // ※ 語法：類別.靜態屬性 指定 值；
        Cursor.visible = false;
        // Random.value = 7.7f; // - 唯讀屬性不能設定 Read Only
        Screen.fullScreen = true;

        // 靜態方法
        // 3. 呼叫
        // ※ 語法：類別.靜態方法(對應引數)；
        float r = Random.Range(7.5f, 9.8f);
        print("隨機範圍 7.5 ~ 9.8：" + r);
        #endregion

        #region 練習靜態屬性與方法
        // 1. 取得靜態屬性
        print("所有攝影機數量：" + Camera.allCamerasCount);
        print("2D 重力：" + Physics2D.gravity);
        print("圓周率：" + Mathf.PI);
        // 2. 設定靜態屬性
        Physics2D.gravity = new Vector2(0, -20);
        print("2D 重力：" + Physics2D.gravity);
        Time.timeScale = 0.5f;                  // 慢動作，快動作 2，暫停 0
        print("時間大小：" + Time.timeScale);

        // 3. 呼叫靜態方法
        number =  Mathf.Floor(number);
        print("9.99 去小數點：" + number);

        float d = Vector3.Distance(a, b);
        print("A 與 B 的距離：" + d);

        Application.OpenURL("https://unity.com/");
        #endregion
    }

    public float hp = 70;

    private void Update()
    {
        #region 認識靜態屬性與方法
        hp = Mathf.Clamp(hp, 0, 100);       // 數學.夾住(值，最小值，最大值) - 將輸入的值夾在最小最大範圍內
        print("血量：" + hp);
        #endregion

        #region 練習靜態屬性與方法
        // 1. 取得靜態屬性
        print("是否按下任意鍵：" + Input.anyKey);
        // print("遊戲過了多久：" + Time.time);

        // 3. 呼叫靜態方法
        bool space = Input.GetKeyDown("space");
        print("是否按下空白鍵：" + space);
        #endregion
    }
}
