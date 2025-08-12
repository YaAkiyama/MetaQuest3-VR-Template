# Meta Quest 3 Unity VR Development Template

## 🎯 プロジェクト概要

Meta Quest 3向けのUnity VR開発テンプレートプロジェクトです。Unity MCP（Model Context Protocol）とGitHub MCPによるAI支援開発環境を統合し、効率的なVRアプリケーション開発を実現します。

### ✨ 主な機能

- **VRレーザーポインターシステム**: 右コントローラーに統合されたレーザーポインター
- **XR Interaction Toolkit統合**: Meta Quest 3コントローラー完全対応
- **Unity MCP連携**: Claude AIによるリアルタイム開発支援
- **GitHub MCP統合**: バージョン管理とCI/CD自動化
- **クリーンなプロジェクト構成**: 不要なテストオブジェクトを排除した最小構成

## 🛠️ 技術スタック

- **Unity**: 2022.3.62f1 LTS
- **XR Plugin**: OpenXR + Meta Quest Support
- **開発言語**: C#
- **対象デバイス**: Meta Quest 3 (v74+)
- **AI支援**: Claude 3.5 with Unity MCP & GitHub MCP

## 📋 必要環境

### ハードウェア
- Windows 10/11 (64-bit)
- Meta Quest 3
- USB-C ケーブル（データ転送対応）

### ソフトウェア
- Unity 2022.3.15f1以降（推奨: 2022.3.62f1）
- Android Studio Koala 2024.2以降
- Meta Quest Developer Hub v4.0.0+
- Git for Windows v2.47+

## 🚀 セットアップ手順

### 1. リポジトリのクローン
```bash
git clone https://github.com/YaAkiyama/MetaQuest3-VR-Template.git
cd MetaQuest3-VR-Template
```

### 2. Unityプロジェクトを開く
1. Unity Hubを起動
2. 「Open」→ プロジェクトフォルダを選択
3. Unity 2022.3.62f1で開く

### 3. プラットフォーム設定
1. File → Build Settings
2. Android プラットフォームに切り替え
3. Quest 3をUSB接続
4. Build and Run

## 🎮 現在のシーン構成

### クリーンアップ後の構成（2025年8月12日更新）
```
mq3template.unity
├── Directional Light        # 基本照明
├── XR Interaction Manager   # VRシステム管理
├── XR Origin (XR Rig)
│   └── Camera Offset
│       ├── Main Camera      # VRヘッドセット
│       ├── Left Controller  # 左手コントローラー
│       └── Right Controller # 右手コントローラー（レーザーポインター機能付き）
├── VR UI Panel             # World Space UI Canvas
└── EventSystem             # UIイベントシステム
```

### 主要コンポーネント

#### Right Controller
- **VRLaserPointer**: カスタムレーザーポインタースクリプト
- **XRRayInteractor**: レイキャスト相互作用
- **LineRenderer**: レーザービジュアル表示
- 緑色に変化するヒット検出機能

#### VR UI Panel
- World Space配置（Position: 0, 2, 3）
- VR空間内でのUI表示用
- レーザーポインターで操作可能

## 📊 パフォーマンス最適化

- **目標FPS**: 72-90 FPS
- **Draw Call**: 100-150以下
- **三角形数**: 100k以下（同時表示）
- **テクスチャメモリ**: 1GB以下

## 📁 プロジェクト構造

```
MetaQuest3-VR-Template/
├── Documentation/
│   └── PROJECT_STRUCTURE.md   # 詳細なプロジェクト構成
├── Scripts/
│   └── VRLaserPointer.cs      # レーザーポインタースクリプト
├── ProjectSettings.md          # プロジェクト設定詳細
├── README.md                   # このファイル
└── .gitignore                  # Unity用gitignore設定
```

## 🔧 開発ステータス

| 項目 | ステータス | 詳細 |
|-----|----------|------|
| Unity MCP | ✅ 稼働中 | Port 6400で正常動作 |
| GitHub MCP | ✅ 接続済み | API認証成功 |
| シーンクリーンアップ | ✅ 完了 | テストオブジェクト削除済み |
| レーザーポインター | ✅ 実装済み | 右コントローラーに統合 |
| Quest 3ビルド | 🔄 準備完了 | ビルドテスト待ち |

## 🎯 次のステップ

1. VR UI Panelにボタンやテキストを追加
2. 左コントローラーに追加機能実装
3. Quest 3実機でのビルドテスト
4. パフォーマンス最適化

## 🤝 コントリビューション

プルリクエストを歓迎します！バグ報告や機能提案はIssuesへお願いします。

### 現在のIssue
- [#1 Quest 3 実機ビルドテスト](https://github.com/YaAkiyama/MetaQuest3-VR-Template/issues/1)

## 📄 ライセンス

MIT License - 詳細は[LICENSE](LICENSE)ファイルを参照

## 📞 サポート

質問や問題がある場合は、GitHubのIssuesセクションでお知らせください。

---

**最終更新**: 2025年8月12日 12:30 JST
**作成者**: YaAkiyama
**Unity MCP統合**: ✅ 動作確認済み（Port 6400）
**GitHub MCP統合**: ✅ 動作確認済み