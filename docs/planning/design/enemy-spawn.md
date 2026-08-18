enemy-spawn.md
# 敵の生成

## 目的
ステージ開始時に、EnemyPrefabDatabaseから敵を選び、
SpawnPointへ生成してステータスを初期化する。

## 初期化処理の順番
```text
EnemySpawner.Start()
↓
PlayerLevelData.StageLevelを取得
↓
EnemySpawner.RandomSpawnEnemies() ボスステージではボス→通常敵の順番
↓
EnemyPrefabDatabaseから生成候補を取得
↓
EnemyPrefabData.enemyPrefabをInstantiate()
↓
生成された敵のAwake()
↓
生成された敵のOnEnable()
↓
EnemySpawnerがEnemyStatusを取得
↓
EnemyStatus.SetUpEnemyStatus()
↓
CurrentEnemyStatusからEnemyParameterを取得
↓
EnemySpawnerのspawnedEnemiesへ追加
↓
生成された敵のStart()
↓
EnemyStatusがEnemyManagerを検索
↓
EnemyManager.AddEnemy(this)

Instantiate()直後に敵のAwake()とOnEnable()が実行される。
その後にSetUpEnemyStatus()が呼ばれるため、敵のAwake()やOnEnable()ではセットアップ後の値を前提にできない。
```

## 所有関係
シーン上のGameObject
- EnemySpawnerを所有

EnemySpawner
- 生成済みEnemyへの非所有参照を保持するための `spawnedEnemies` というListを所有
- 一時的に作成する候補Listを所有

EnemySpawner
- 敵GameObjectの生成を担当
- spawnedEnemiesで生成した敵への参照を保持
- 敵GameObjectの破棄はEnemyDeathが担当

## 参照関係

EnemySpawner
- EnemyPrefabDatabase ([SerializeField])
- - List<EnemyPrefabData>
- - - EnemyType
- - - EnemyRole
- - - enemyPrefab
- - - - EnemyStatus 
- 
- 生成したGameObject
- - EnemyStatus
- - - SetUpEnemyStatus()を呼ぶ
- 
- spawnPoints（SerializeField・非所有参照）
- bossSpawnPoint（SerializeField・非所有参照）
- PlayerLevelData.StageLevel（static参照）

EnemyStatus
- EnemyType（SerializeField）
-  CurrentEnemyStatus.Instance（static参照）
- - currentEnemyParameters
- - - EnemyParameter
- 
- EnemyManager（FindAnyObjectByType・非所有参照）
- ExperienceSystem（FindAnyObjectByType・非所有参照）
- MoneySystem（FindAnyObjectByType・非所有参照）


## 依存関係
EnemySpawner
→ EnemyPrefabDatabase
→ EnemyPrefabData
→ EnemyStatus

EnemyStatus
→ CurrentEnemyStatus
→ EnemyParameter

EnemyStatus
→ EnemyManager
→ List<EnemyStatus>

EnemyStatus
→ ExperienceSystem
EnemyStatus
→ MoneySystem