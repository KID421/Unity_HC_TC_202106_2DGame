using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

public class SceneController : MonoBehaviour
{
    // Unity 無法掛上腳本的兩大原因
    // 1. 腳本內有紅色蚯蚓，任何一本
    // 2. 類別與檔案名稱不同

    // Unity 按鈕如何與腳本溝通
    // 1. 公開的方法
    // 2. 需要實體物件掛此腳本
    // 3. 按鈕 On Click 設定點擊事件為此物件以及要呼叫的方法

    /// <summary>
    /// 載入遊戲場景
    /// </summary>
    public void LoadGameScene()
    {
        // 等兩秒再載入場景
        // 延遲呼叫(方法名稱，延遲時間)
        // 作用：等待指定時間後再呼叫指定方法
        Invoke("DelayLoadGameScene", 2);
    }

    // 等待一段時間再執行方法
    // Invoke 延遲呼叫
    /// <summary>
    /// 延遲載入場景
    /// </summary>
    private void DelayLoadGameScene()
    {
        // 場景管理.載入場景(場景名稱) - 載入指定的場景
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Invoke("DelayQuitGame", 2);
    }

    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    private void DelayQuitGame()
    {
        Application.Quit();     // 應用程式.離開() - 關閉遊戲
        print("離開遊戲");       // Quit 在編輯器內不會執行
    }
}
