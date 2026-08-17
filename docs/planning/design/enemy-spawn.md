enemy-spawn.md
# 敵の生成

## 関連ファイル
EnemySpawner.cs

## 初期化処理の順番



## 所有関係・参照関係
```text
EnemySpawner
- EnemyPrefabDatabase ([SerializeField])
--EnemyStatus 
--EnemyPrefabData
- PlayerLevelData (static)
- Transform(SerializeField)

EnemyStatus
-EnemyType ([SerializeField])
