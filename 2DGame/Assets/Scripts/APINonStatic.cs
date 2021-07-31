using UnityEngine;

public class APINonStatic : MonoBehaviour
{
    // API 文件，分為兩大類
    // 1. 靜　態：有關鍵字 static
    // 2. 非靜態：無關鍵字 static

    // 使用非靜態屬性 1. 先定義此非靜態屬性的類別欄位
    // 使用非靜態屬性 3. 欄位必須放入要取的資訊的物件，※ 不能為空值
    public Transform traA;
    public Camera cam;
    public Transform traB;

    private void Start()
    {
        // 1. 取得非靜態屬性

        // print("取得座標：" + Transform.position); // 錯誤：需要有物件參考

        // 使用非靜態屬性 2. 
        // ※ 語法：欄位.非靜態屬性
        print("取得立方體座標：" + traA.position);
        print("取得攝影機的背景顏色：" + cam.backgroundColor);

        // 2. 設定非靜態屬性
        // ※ 語法：欄位.非靜態屬性 指定 值；
        cam.backgroundColor = new Color(0.8f, 0.5f, 0.6f);

        // 3. 呼叫非靜態方法
        // ※ 語法：欄位.非靜態方法(對應引數)；
        traB.Translate(1, 0, 0);
    }
}