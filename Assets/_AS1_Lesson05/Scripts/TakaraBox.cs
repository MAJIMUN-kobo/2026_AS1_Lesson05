using UnityEngine;

public class TakaraBox : MonoBehaviour
{
    // Headerアトリビュート：
    // インスペクターにタイトルを設定することができる
    [Header("* * * 宝石ドロップ設定 * * *")]
    public GameObject treasurePrefab;       // 「宝石」のプレハブを参照
    public Vector2 dropForceMin = new Vector2(-1.0f, 0.5f); // 飛び出す方向（最小値）
    public Vector2 dropForceMax = new Vector2(1.0f, 1.0f);  // 飛び出す方向（最大値）
    public float dropTorqueMin = -5.0f;     // 回転力（最小値）
    public float dropTorqueMax = 5.0f;      // 回転力（最大値）
    public float lifeTime = 1.0f;           // 表示時間
    public Animator animator;               // Animatorコンポーネントの参照

    [Header("* * * 効果音設定 * * *")]
    public AudioSource audioSource;         // AudioSourceコンポーネントの参照
    public AudioClip openSound;             // 宝箱が開く時の効果音（.mp3）
    public AudioClip dropSound;             // 宝石が飛び出す時の効果音（.mp3）

    [Header("* * * スコア設定 * * *")]
    public ScoreManager scoreManager;       // スコア管理クラスの参照
    public int scoreMim = 10;       // スコアの加算値（最小値）
    public int scoreMax = 100;      // スコアの加算値（最大値）


    void Start()
    {
        
    }


    void Update()
    {
        DropTreasure();     // 宝石をドロップ
    }


    /// <summary>
    /// 宝石をドロップさせるメソッド
    /// </summary>
    public void DropTreasure()
    {
        // Instantiate ... インスタンティエイト
        // ※　オブジェクトを複製することができるメソッド
        // Instantiate( 複製したいオブジェクト, 出現時の座標, 出現時の角度 )
        GameObject treasure = Instantiate( treasurePrefab, transform.position, transform.rotation );

        // ==== 👇　弾き飛ばす力を設定
        Vector2 dropForce = Vector2.zero;
        dropForce.x = Random.Range(dropForceMin.x, dropForceMax.x);
        dropForce.y = Random.Range(dropForceMin.y, dropForceMax.y);

        // === 👇　回転力を設定
        float dropTorque = Random.Range(dropTorqueMin, dropTorqueMax);

        // === 👇　宝石のRigidbodyを取得して吹っ飛ばす
        Rigidbody2D rigidbody = treasure.GetComponent<Rigidbody2D>();
        rigidbody.AddForce( dropForce, ForceMode2D.Impulse );
        rigidbody.AddTorque( dropTorque, ForceMode2D.Impulse );

        // ドロップしたオ宝石を削除
        // Destroy ... デストロイ
        // ※　指定したオブジェクトを削除するメソッド
        // Destroy( 削除したいオブジェクト, 待ち時間 )
        Destroy(treasure, lifeTime);
    }
}
