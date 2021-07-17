using UnityEngine;

// 認識運算子
// 1. 數學運算子
public class LearnOperator : MonoBehaviour
{
    public int a = 10;
    public int b = 3;
    public int c = 7;
    public int hp = 100;

    public float scoreA = 99;
    public float scoreB = 1;

    public int health = 50;
    public int key = 1;
    public int chest = 7;
    public int diamond = 0;

    private void Start()
    {
        #region 數學運算子
        print(a + b);       // 13
        print(a - b);       // 7
        print(a * b);       // 30
        print(a / b);       // 3
        print(a % b);       // 1

        // 遞增 ++
        c = c + 1;          // = 指定符號：右邊先運算再指定給左邊
        c++;                // 簡寫
        print("c 運算後的結果：" + c);
        // 遞減 --
        // 自行練習

        // 指定運算 - 適用加減乘除餘
        // 例子：扣血 13
        hp = hp - 13;       // 87
        hp -= 13;           // 74

        // 例子：補血 20
        hp += 20;           // 94
        #endregion

        #region 比較運算子
        // > < >= <= == !=
        // 使用比較運算子的結果 都是布林值
        // 比較正確結果為 true 否則為 false
        print("99 大於 1：" + (scoreA > scoreB));          　// true
        print("99 小於 1：" + (scoreA < scoreB));          　// false
        print("99 大於等於 1：" + (scoreA >= scoreB));       // true
        print("99 小於等於 1：" + (scoreA <= scoreB));       // false
        print("99 等於 1：" + (scoreA == scoreB));         　// false
        print("99 不等於 1：" + (scoreA != scoreB));         // true
        #endregion

        #region 邏輯運算子
        print("邏輯運算子");
        // 比較兩筆布林值的資料

        print("並且");
        // 並且 &&
        // 只要有一個布林值為 false 結果就為 false
        print(true && true);                    // true
        print(true && false);                   // false
        print(false && true);                   // false
        print(false && false);                  // false

        print("或者");
        // 或者 ||
        // 只要有一個布林值為 true 結果就為 true
        print(true || true);                    // true
        print(true || false);                   // true
        print(false || true);                   // true
        print(false || false);                  // false

        // 過關條件：血量 大於 0 並且 鑰匙 要等於 1
        print("是否過關：" + (health > 0 && key == 1));
        // 過關條件：寶箱 大於等於 5 或者 鑽石 大於等於 2
        print("是否過關：" + (chest >= 5 || diamond >= 2));

        // 相反 !
        print(!true);
        print(!false);
        #endregion
    }
}
