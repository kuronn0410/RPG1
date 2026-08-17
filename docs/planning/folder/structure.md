Script/
├─ Enemy/
│  ├─ Boss/
│  │  ├─ BossDatabase.cs
│  │  ├─ BossParameter.cs
│  │  ├─ BossPrefabData.cs
│  │  ├─ BossPrefabDatabase.cs
│  │  └─ BossType.cs
│  │
│  ├─ EnemyData/
│  │  ├─ CurrentEnemyStatus.cs
│  │  ├─ EnemyDamagePos.cs
│  │  ├─ EnemyDatabase.cs
│  │  ├─ EnemyParameter.cs
│  │  ├─ EnemyPrefabData.cs
│  │  ├─ EnemyPrefabDatabase.cs
│  │  ├─ EnemyRole.cs
│  │  ├─ EnemySpawner.cs
│  │  ├─ EnemyStatus.cs
│  │  └─ EnemyType.cs
│  │
│  ├─ EnemyMove/
│  │  ├─ EnemyAnimation.cs
│  │  ├─ EnemyAttack.cs
│  │  ├─ EnemyDamage.cs
│  │  ├─ EnemyDeath.cs
│  │  ├─ EnemyMove1.cs
│  │  └─ Tekimove3.cs
│  │
│  ├─ EnemySound/
│  │  └─ EnemyAudio.cs
│  │
│  └─ EnemyPrefabValidator.cs
│
├─ Interface/
│  ├─ IDamageable/
│  │  └─ IDamageable.cs
│  │
│  ├─ Interactable/
│  │  ├─ DoorChange.cs
│  │  ├─ IInteractable.cs
│  │  ├─ IWorldUIDisplayable.cs
│  │  └─ ShopInteract.cs
│  │
│  ├─ IShop/
│  │  ├─ IShop.cs
│  │  └─ IShopDatabase.cs
│  │
│  ├─ Sound/
│  │  ├─ IUISePlayer.cs
│  │  ├─ IVolumeControllable.cs
│  │  └─ UISeType.cs
│  │
│  └─ World/
│     └─ IWorldUIHover.cs
│
├─ Manager/
│  ├─ EnemyManager.cs
│  ├─ GameManager.cs
│  ├─ GameManagers.cs
│  ├─ TitleUIManager.cs
│  └─ UIManager.cs
│
├─ Player/
│  ├─ Basic/
│  │  ├─ EnemyDetection.cs
│  │  ├─ ExperienceSystem.cs
│  │  ├─ MoneySystem.cs
│  │  ├─ PlayerAnimation.cs
│  │  ├─ PlayerAttack.cs
│  │  ├─ PlayerInteract.cs
│  │  ├─ PlayerMove.cs
│  │  └─ PlayerStatus.cs
│  │
│  ├─ Card/
│  │  ├─ CardAbility/
│  │  │  ├─ AttackBoostCardAbility.cs
│  │  │  ├─ CardAbilityManeger.cs
│  │  │  ├─ HealCardAbility.cs
│  │  │  ├─ MaxHpBoostCardAbility.cs
│  │  │  ├─ PoisonAttackCardAbility.cs
│  │  │  ├─ StunAttackCardAbility.cs
│  │  │  └─ TpPotionCardAbility.cs
│  │  │
│  │  ├─ CardData.cs
│  │  ├─ CardDatabase.cs
│  │  ├─ CardEffectType.cs
│  │  ├─ CardType.cs
│  │  ├─ InputCardUse.cs
│  │  └─ PossessionCard.cs
│  │
│  ├─ PlayerData/
│  │  ├─ PlayerBaseStatus.cs
│  │  └─ PlayerLevelData.cs
│  │
│  ├─ PlayerSound/
│  │  └─ PlayerAudio.cs
│  │
│  └─ Weapon/
│     ├─ PossessionWeapon.cs
│     ├─ WeaponDamage.cs
│     ├─ WeaponDatabase.cs
│     ├─ WeaponHolder.cs
│     ├─ WeaponParameter.cs
│     └─ WeaponType.cs
│
├─ Save/
│  ├─ ContinuGame.cs
│  ├─ GuideData.cs
│  ├─ ResetGame.cs
│  ├─ SaveData.cs
│  ├─ SaveSystem.cs
│  ├─ SettingSaveSystem.cs
│  └─ SettingsData.cs
│
├─ Setting/
│  ├─ CurrentSettingDatas.cs
│  ├─ MouseSensitivity.cs
│  ├─ SettingData.cs
│  └─ SettingFPS.cs
│
├─ Shop/
│  ├─ Card/
│  │  ├─ CardShopData.cs
│  │  └─ CardShopDatabase.cs
│  │
│  ├─ Weapon/
│  │  ├─ WeaponShopData.cs
│  │  └─ WeaponShopDatabase.cs
│  │
│  └─ ShopSystem.cs
│
├─ Sound/
│  ├─ Map/
│  │  └─ MapAudio.cs
│  │
│  ├─ Title/
│  │  └─ TitleAudio.cs
│  │
│  ├─ Town/
│  │  └─ TownAudio.cs
│  │
│  ├─ BgmManager.cs
│  ├─ BGMType.cs
│  ├─ SEManager.cs
│  └─ SoundManager.cs
│
└─ UI/
   ├─ Card/
   │  ├─ CardButtonMode.cs
   │  ├─ CardButtonStateManager.cs
   │  ├─ CardDeckManager.cs
   │  ├─ CardProductButton.cs
   │  ├─ CardUIBase.cs
   │  ├─ DeckCardUI.cs
   │  ├─ PossessionCardUI.cs
   │  └─ UseCardUI.cs
   │
   ├─ Guide/
   │  ├─ GuideManager.cs
   │  ├─ GuideType.cs
   │  ├─ MapGuideUIController.cs
   │  └─ TownGuideUIController.cs
   │
   ├─ Loadding/
   │  └─ LoadUIManager.cs
   │
   ├─ Map/
   │  ├─ BossIntroUI.cs
   │  └─ LevelUpUI.cs
   │
   ├─ PlayerAppear/
   │  ├─ EnemyHPUI.cs
   │  ├─ GameStateUI.cs
   │  ├─ MoneyUI.cs
   │  ├─ PlayerHPUI.cs
   │  ├─ PlayerStatusUI.cs
   │  └─ StageLevelUI.cs
   │
   ├─ Setting/
   │  └─ FPSUIState.cs
   │
   ├─ Shop/
   │  ├─ SeeShopUI.cs
   │  ├─ ShopProductButton.cs
   │  ├─ ShopType.cs
   │  └─ ShopUI.cs
   │
   ├─ System/
   │  ├─ InteractionPromptUI.cs
   │  ├─ InventoryUI.cs
   │  ├─ OpenAndClosePanelButton.cs
   │  ├─ SceneMove.cs
   │  └─ SceneType.cs
   │
   ├─ Title/
   │  ├─ TitleButton.cs
   │  └─ TitleButtonType.cs
   │
   ├─ Weapon/
   │  ├─ SwitchWeaponButton.cs
   │  └─ WeaponSwitchUI.cs
   │
   ├─ WorldUI/
   │  ├─ DamageDisplay.cs
   │  ├─ DamageTextUI.cs
   │  ├─ WorldButtonRun.cs
   │  ├─ WorldUIButton.cs
   │  ├─ WorldUIButtonType.cs
   │  ├─ WorldUIManager.cs
   │  └─ WorldUIRaycaster.cs
   │
   └─ UIPanelType.cs