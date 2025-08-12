# Meta Quest 3 Unity VR Development Template

## 🎯 プロジェクト概要

Meta Quest 3向けのUnity VR開発テンプレートプロジェクトです。Unity MCP（Model Context Protocol）とGitHub MCPによるAI支援開発環境を統合し、効率的なVRアプリケーション開発を実現します。

### ✨ 主な機能

- **VRレーザーポインターシステム**: 直感的なUI操作を実現
- **XR Interaction Toolkit統合**: Meta Quest 3コントローラー完全対応
- **Unity MCP連携**: Claude AIによるリアルタイム開発支援
- **GitHub MCP統合**: バージョン管理とCI/CD自動化

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

## 🎮 VR機能詳細

### VRレーザーポインター
- 自動ターゲット検出
- ホバーエフェクト
- UIボタンインタラクション
- カスタマイズ可能な見た目

### シーン構成
```
mq3template.unity
├── XR Origin (XR Rig)
│   ├── Camera Offset
│   │   ├── Main Camera
│   │   ├── Left Controller
│   │   └── Right Controller
│   └── VR Laser Pointer System
├── XR Interaction Manager
├── VR Test Canvas
│   └── VR Test Button
└── EventSystem
```

## 📊 パフォーマンス最適化

- **目標FPS**: 72-90 FPS
- **Draw Call**: 100-150以下
- **三角形数**: 100k以下（同時表示）
- **テクスチャメモリ**: 1GB以下

## 🤝 コントリビューション

プルリクエストを歓迎します！バグ報告や機能提案はIssuesへお願いします。

## 📄 ライセンス

MIT License - 詳細は[LICENSE](LICENSE)ファイルを参照

## 📞 サポート

質問や問題がある場合は、GitHubのIssuesセクションでお知らせください。

---

**最終更新**: 2025年8月12日
**作成者**: YaAkiyama
**Unity MCP統合**: ✅ 動作確認済み
**GitHub MCP統合**: ✅ 動作確認済み