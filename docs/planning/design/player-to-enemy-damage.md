player-to-enemy-damage.md
# プレーヤーから敵へのダメージ

# 修正メモ
##　(現在)
WeaponDamage ここの責務を分ける
　weaponの実体の作成
　コライダーからEnemyStatusの検知 
　敵へのダメージ

PlayerAttack
　攻撃、非攻撃時のWeaponDamageが持っているコライダーのオンオフ
  

DamageTextUI
　敵の検知のイベントを購読 ここもずれる可能性ある
　敵の食らったダメージを表示
  
EnemyDetection
範囲内の特定のスクリプトの検知 EnemyMove1 EnemyStatus
敵の検知のイベント発行
　
検知した敵のスタン　ここもよくなさそう
検知した敵のプレイヤーの検知の提出 ここもよくなさそう

EnemyHPUI
　敵の検知のイベントを購読 ここがずれている
  UIの表示

##　(案)
武器のprefabに付けるもの　EnemyStatusコライダーの取得 自身の武器Type
playerに付けるもの　武器に付けているスクリプトから敵のデータの受け取り
- playerに付けるもの　敵へのダメージの情報を送る
- 
