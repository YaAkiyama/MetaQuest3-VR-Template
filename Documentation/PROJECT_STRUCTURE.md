# Unity VRプロジェクト構成

## 📁 プロジェクト概要
- **プロジェクト名**: MetaQuest3Template
- **Unity バージョン**: 2022.3.62f1 LTS
- **ターゲットプラットフォーム**: Android (Meta Quest 3)
- **最終更新**: 2025年8月12日

## 🎮 シーン構成: mq3template.unity

```
mq3template.unity
├── Directional Light
│   └── 基本的な照明設定
│       - Position: (0, 3, 0)
│       - Rotation: (50, 330, 0)
│
├── XR Interaction Manager
│   └── VRインタラクションシステムの中央管理
│
├── XR Origin (XR Rig)
│   └── Camera Offset (Height: 1.1176m)
│       ├── Main Camera
│       │   └── VRヘッドセットのメインカメラ
│       │       - Tag: MainCamera
│       │       - VR用の設定済み
│       │
│       ├── Left Controller
│       │   └── 左手コントローラー
│       │       - XR Controller設定済み
│       │       - インタラクション機能搭載
│       │
│       └── Right Controller
│           └── 右手コントローラー（レーザーポインター機能付き）
│               - XR Controller設定済み
│               - VRLaserPointerスクリプト搭載
│               - LineRenderer搭載
│               - XRRayInteractor搭載
│
├── VR UI Panel
│   └── World Space UI Canvas
│       - Position: (0, 2, 3)
│       - VR空間内のUI表示用
│       - GraphicRaycaster搭載
│
└── EventSystem
    └── UIイベント処理システム
        - XR UI Input Module対応
```

## 📦 必須パッケージ

### インストール済み
- ✅ XR Plugin Management
- ✅ OpenXR Plugin
- ✅ XR Interaction Toolkit (3.0.8+)
- ✅ Meta OpenXR (1.0.4+)
- ✅ Android Logcat (1.4.2+)
- ✅ Unity MCP Bridge

### XR設定
- **XR Plugin**: OpenXR
- **OpenXR Features**: Meta Quest Support
- **Interaction Profile**: Oculus Touch Controller Profile

## 🎯 コンポーネント詳細

### Right Controller コンポーネント
1. **Transform** - 位置と回転
2. **ActionBasedController** - XRコントローラー入力
3. **XRRayInteractor** - レイキャスト相互作用
4. **LineRenderer** - レーザービジュアル
5. **XRInteractorLineVisual** - XR用ライン表示
6. **SortingGroup** - 描画順序管理
7. **VRLaserPointer** - カスタムレーザーポインター

### VR UI Panel コンポーネント
1. **RectTransform** - UI位置管理
2. **Canvas** - World Space設定
3. **CanvasScaler** - スケール調整
4. **GraphicRaycaster** - UI相互作用

## 🔧 プロジェクト設定

### Build Settings
- **Platform**: Android
- **Texture Compression**: ASTC
- **Target Architectures**: ARM64
- **Scripting Backend**: IL2CPP
- **API Compatibility Level**: .NET Standard 2.1

### Player Settings
- **Company Name**: DefaultCompany
- **Product Name**: MetaQuest3Template
- **Package Name**: com.defaultcompany.metaquest3template
- **Minimum API Level**: 26 (Android 8.0)
- **Target API Level**: 33+ (Android 13.0+)

### Graphics Settings
- **URP Asset**: 使用中
- **HDR**: 無効（パフォーマンス最適化）
- **MSAA**: 2x
- **Shadow Distance**: 50m

## 📝 スクリプト

### VRLaserPointer.cs
- **場所**: Assets/Scripts/VRLaserPointer.cs
- **機能**: VRレーザーポインター機能を提供
- **設定可能項目**:
  - laserMaxLength: 10f
  - laserWidth: 0.01f
  - laserColor: Cyan
  - hitColor: Green

## 🚀 ビルド手順

1. File → Build Settings
2. Androidプラットフォームを選択
3. Quest 3をUSBで接続
4. "Build and Run"をクリック
5. APKがQuest 3に自動インストールされる

## ⚠️ 注意事項

- Quest 3の開発者モードを有効にすること
- USB デバッグを許可すること
- Unity 2022.3.22f1はビルドエラーがあるため使用しない
- Unity 6はQuest 3でパフォーマンス問題があるため使用しない

## 📊 パフォーマンス目標

- **FPS**: 72-90 FPS
- **Draw Call**: 100-150以下
- **三角形数**: 100k以下（同時表示）
- **テクスチャメモリ**: 1GB以下

---

**最終更新**: 2025年8月12日
**更新者**: Unity MCP + GitHub MCP Integration