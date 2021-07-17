using UnityEngine;      // 引用 Unity 引擎 提供的 API (Unity Engine 命名空間)

// 類別
// 語法：修飾詞 類別關鍵字 腳本名稱
public class Car : MonoBehaviour
{
    #region 註解
    // 單行註解：添加說明、翻譯、紀錄等等...會被程式忽略
    // KID 2021.07.17 (六) 開發汽車腳本

    /* 多行註解
     * 多行註解
     * 多行註解
     * 多行註解
     */
    #endregion

    #region 認識欄位與常用四大類型
    // 欄位：儲存簡單的資料
    // 語法：
    // 修飾詞 資料類型 欄位名稱 指定符號 預設值 結尾
    // 指定符號 =
    // 修飾詞：
    // 1. 私人 private 預設－不顯示
    // 2. 公開 public  　　－顯示

    // Unity 內常用的四大類型
    // 整數　　int    例：1, 99, 0, -123
    // 浮點數　float  例：2.3, 3.1415, -1.123
    // 字串　　string 例：BMW, 賓士, 對話內容@#...
    // 布林值　bool   例：true, false

    // 定義欄位
    // Unity 以屬性 Inspector 面板上的值為主
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "賓士";
    public bool windowSky = true;

    // 可以使用中文，不建議 - 編碼問題與轉換效能問題
    // 獨立開發、團隊許可
    public int 輪胎數量 = 4;

    // 欄位屬性：輔助欄位添加額外功能
    // 語法：[屬性名稱(屬性值)]
    // 標題：[Header(字串)]
    [Header("輪胎數量")]
    public int wheelCount;
    // 提示：[Tooltip(字串)]
    [Tooltip("這個欄位的作用是設定汽車的高度...")]
    public float height = 1.5f;
    // 範圍：[Range(最小數值，最大數值)] - 僅限數值類型 float 與 int
    [Range(2, 10)]
    public int doorCount;
    // 錯誤示範：不適用於 float 與 int 以外的類型
    [Range(2, 10)]
    public bool canOpenMusic;
    #endregion

    #region 其他類型
    // 顏色 Color
    public Color color1;                                        // 不指定為黑色透明
    public Color red = Color.red;                               // 使用預設顏色
    public Color yellow = Color.yellow;
    public Color colorCustom1 = new Color(0.5f, 0.5f, 0);       // 自訂顏色(R，G，B)
    public Color colorCustom2 = new Color(0.5f, 0, 0.5f, 0.5f); // 自訂顏色(R，G，B，A)

    // 座標 2 - 4 維 Vector2 - 4
    // 保存數值資訊，浮點數
    public Vector2 v2;
    public Vector2 v2Zero = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Custom = new Vector2(-99.5f, 100.5f);

    public Vector3 v3;
    public Vector4 v4;

    // 按鍵類型
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; // 左鍵 0，右鍵 1，滾輪 2

    // 遊戲物件與元件
    public GameObject goCamera; // 遊戲物件包含場景上的以及專案內的預製物
    // 元件僅限於存放屬性面板有此元件的物件
    public Transform traCar;
    public SpriteRenderer sprPicture;
    #endregion

    #region 事件
    // 開始事件：播放遊戲時執行一次，處理初始化
    private void Start()
    {
        // 輸出(任何類型資料);
        print("哈囉，沃德~ :P");

        // 練習取得欄位 Get
        print(brand);
        // 練習設定欄位 Set
        windowSky = true;
        cc = 5000;
        weight = 9.9f;
    }

    // 更新事件：大約一秒 60 次，60FPS，處理物件移動或者監聽玩家輸入
    private void Update()
    {
        print("我在 Update 內 @3@");
    }
    #endregion
}
