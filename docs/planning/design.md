design.md

# 設計

## プレイヤー操作
- 移動
- 攻撃
- カメラ
- 入力停止
- 敵の検知　[enemy-detection.md](design/enemy-detection.md)

## インタラクション
- Raycast
- IInteractable
- 操作表示UI
- クリック後の処理

## 戦闘
- ダメージ処理
- 武器
- 敵とのやり取り

## カードシステム
- 所持カード
- デッキ
- 使用処理
- カード効果

## 敵
- 敵データ
- AI
- EnemyManagerとの関係

- 敵の生成  [enemy-spawn.md](design/enemy-spawn.md)




## UI
- イベントによる更新
- UIManagerの責務

## セーブ・ロード
- JSON
- async/await
- ゲームデータと設定データの分離

## サウンド
- BGM
- UI音
- Player / EnemyのSE