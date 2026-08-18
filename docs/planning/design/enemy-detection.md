enemy-detection.md
# 敵の検知

## 目的

プレイヤー周辺の敵を検知する。

- 最も近い敵をHP・ダメージUIへ通知する
- 範囲内の敵へスタン効果を与える
- 範囲内の敵へプレイヤー透明化状態を通知する

## 通常の検知処理

EnemyDetection.Update()
↓
DetectEnemy()
↓
Physics.OverlapSphere()で範囲内のColliderを取得
↓
ColliderからEnemyStatusを取得
↓
プレイヤーとの距離を比較
↓
最も近いEnemyStatusをclosestEnemyへ保存
↓
前回の敵と異なる場合
OnClosestEnemyDetectedを通知
↓
EnemyHPUI・DamageTextUIが表示対象を変更

## カード使用時の検知

StunAttackCardAbility
↓
EnemyDetection.RangeinEnemy()
↓
範囲内のEnemyMove1を取得
↓
EnemyMove1.StunState()

TpPotionCardAbility
↓
EnemyDetection.PlayerTpPotionRange()
↓
範囲内のEnemyMove1を取得
↓
EnemyMove1.PlayerTpPotion()

## 所有関係

PlayerのGameObject
- EnemyDetectionコンポーネントを所有

EnemyDetection
- 敵を所有しない
- 検知結果としてEnemyStatusへの非所有参照を保持する

## 参照関係

EnemyDetection
- enemyLayer（SerializeField）
- closestEnemy（EnemyStatusへの非所有参照）
- previousEnemy（EnemyStatusへの非所有参照）
- EnemyStatus（通常検知・UI通知用）
- EnemyMove1（スタン・透明化処理用）

EnemyHPUI
- EnemyDetection（SerializeField・非所有参照）
- OnClosestEnemyDetectedを購読

DamageTextUI
- EnemyDetection（SerializeField・非所有参照）
- OnClosestEnemyDetectedを購読

## 依存関係

EnemyDetection
→ EnemyStatus
→ EnemyMove1

EnemyHPUI
→ EnemyDetection

DamageTextUI
→ EnemyDetection
＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

# 敵の検知

## 目的
プレーヤーが敵の検知を行い、UIに反映する

## 初期化処理の順番
EnemyStatus.Start() EnemyMove1.Start()
↓
EnemyDetection.Update().DetectEnemy();
↓
敵が範囲内に入る
↓
RangeinEnemy()　PlayerTpPotionRange()

## 所有関係




## 参照関係
EnemyDetection
- LayerMask enemyLayer([SerializeField])
- - Physics.OverlapSphere
- - - EnemyStatus HPなどの表示用
- - - EnemyMove1　動きを制御する用

EnemyHPUI
- EnemyDetection（SerializeField・非所有参照）
- OnClosestEnemyDetectedを購読

DamageTextUI
- EnemyDetection（SerializeField・非所有参照）
- OnClosestEnemyDetectedを購読

## 依存関係
EnemyDetection　
→EnemyStatus
→EnemyMove1

