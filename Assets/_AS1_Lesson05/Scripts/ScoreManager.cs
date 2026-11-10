using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("* * * Score View * * *")]
    public int score = 0;   // ゲーム内スコア

    [Header("* * * uGUI 設定 * * *")]
    public TextMeshProUGUI scoreText;   // テキストコンポーネントの参照

    [Header("* * * サウンド設定 * * *")]
    public AudioSource audioSource;     // コンポーネントの参照
    public AudioClip saveSound;         // データ保存時の効果音
    public AudioClip deleteSound;       // データ削除時の効果音



    void Start()
    {
        LoadScore();        // スコアを読み込み
    }


    void Update()
    {
        UpdateText();       // テキストの表示を更新
    }


    /// <summary>
    /// スコアを加算するメソッド
    /// </summary>
    /// <param name="add">加算値</param>
    public void AddScore(int add)
    {
        score += add;
    }


    /// <summary>
    /// スコアの表示を更新するメソッド
    /// </summary>
    public void UpdateText()
    {
        scoreText.text = score.ToString();
    }


    /// <summary>
    /// スコアを保存するメソッド
    /// </summary>
    public void SaveScore()
    {
        // スコアを保存
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        // 音を鳴らす
        PlaySound( saveSound );
    }


    /// <summary>
    /// スコアを読み込むメソッド
    /// </summary>
    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score");
    }


    /// <summary>
    /// スコアのデータを削除するメソッド
    /// </summary>
    public void DeleteScore()
    {
        // スコアを削除する
        // PlayerPrefs.DeleteKey( 保存名 )
        PlayerPrefs.DeleteKey("Score");

        // 削除した時の効果音
        PlaySound(deleteSound);
    }


    /// <summary>
    /// 効果音を再生するメソッド
    /// </summary>
    /// <param name="se">効果音</param>
    public void PlaySound( AudioClip se )
    {
        // 引数で送られてきた効果音を再生
        audioSource.PlayOneShot( se );
    }
}
