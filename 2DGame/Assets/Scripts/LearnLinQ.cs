using UnityEngine;
using System.Linq;      // 引用 LinQ 查詢語言 API - 查找陣列資料

public class LearnLinQ : MonoBehaviour
{
    public int[] scores = { 10, 80, 60, 30, 70, 99, 77, 1, 0 };

    public int[] result;
    public int[] resultEqualThan60;

    private void Start()
    {
        // 檢查有沒有 0 分
        // 黏巴達 Lambda 簡寫 C# 3.0 版後的簡寫方式
        
        // 檢查 scores 內 有沒有 分數為 0 的值
        // x 代名詞
        // => 設定條件
        result = scores.Where(x => x == 0).ToArray();

        // 檢查有沒有大於等於 60 分
        resultEqualThan60 = scores.Where(x => x >= 60).ToArray();
    }
}
