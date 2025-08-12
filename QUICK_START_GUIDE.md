# 🚀 Meta Quest 3 VR開発環境 - クイックスタートガイド

## Claude Desktop 新規チャット開始用テンプレート

### 📝 コピー用スタートアップメッセージ

以下のメッセージをClaude Desktopの新しいチャットにコピー＆ペーストしてください：

---

```
Meta Quest 3 Unity VR開発環境が構築済みです。現在の環境状態：

【環境情報】
- Unity 2022.3.62f1 LTS（起動中）
- プロジェクト: MetaQuest3Template (C:\UnityProjects\MetaQuest3Template)
- Unity MCP: Port 6400で稼働中
- GitHub MCP: 接続済み
- リポジトリ: https://github.com/YaAkiyama/MetaQuest3-VR-Template

【ベースラインシーン】
Assets/Scenes/mq3template_baseline.unity が基本テンプレートです。
- XR Origin（VRカメラ + 両手コントローラー）
- VR UI Panel（World Space Canvas）
- 右コントローラーにレーザーポインター機能

【今回作りたいアプリ】
[ここに作りたいアプリの仕様を記載してください]

例：
- VR空間で3Dオブジェクトを掴んで移動できるアプリ
- VRメニューから色を選択して空間に絵を描けるアプリ
- 複数のUIパネルを切り替えられるVRダッシュボード

Unity MCPとGitHub MCPを使って開発を進めてください。
```

---

## 🎯 開発開始前チェックリスト

### Unity環境確認
- [ ] Unity 2022.3.62f1が起動している
- [ ] MetaQuest3Templateプロジェクトが開いている
- [ ] Consoleにエラーが出ていない
- [ ] Android Platformに切り替え済み

### MCP接続確認
- [ ] Unity MCP Bridge: Window → Unity MCP で "Connected" 表示
- [ ] Claude Desktop: 設定 → Developer タブが表示されている
- [ ] GitHubアカウントにログイン済み

### Quest 3準備（実機テスト時）
- [ ] Quest 3の開発者モードON
- [ ] USB-Cケーブルで接続
- [ ] `adb devices`でデバイス認識確認

## 📁 プロジェクト構成

```
C:\UnityProjects\MetaQuest3Template\
├── Assets/
│   ├── Scenes/
│   │   ├── mq3template.unity（作業用シーン）
│   │   └── mq3template_baseline.unity（ベースライン）
│   ├── Scripts/
│   │   └── VRLaserPointer.cs
│   └── [新規作成フォルダ]/
├── Packages/
│   └── Unity MCP Bridge
└── ProjectSettings/
```

## 🔄 リセット手順（作り直したい時）

### 方法1: シーンをベースラインに戻す
```
1. File → Open Scene
2. Assets/Scenes/mq3template_baseline.unity を選択
3. File → Save As... → 新しい名前で保存
```

### 方法2: Claudeで自動リセット
```
「現在のシーンをベースラインにリセットして、TestCubeなどのオブジェクトを全て削除してください」
```

### 方法3: Git経由でリセット
```bash
git stash
git checkout main
git pull origin main
```

## 💡 よく使うClaude MCPコマンド例

### Unity操作
- 「シーンの階層を表示して」
- 「新しいGameObjectを作成して」
- 「C#スクリプトを作成して」
- 「コンソールのエラーを確認して」
- 「プロジェクトを保存して」

### GitHub操作
- 「現在の変更をGitHubにコミットして」
- 「新しいブランチを作成して」
- 「Issueを作成して」
- 「READMEを更新して」

## 🎮 アプリ仕様テンプレート

### 基本仕様記載例
```
【アプリ名】VR [アプリタイプ]

【概要】
[1-2行でアプリの説明]

【主要機能】
1. [機能1の説明]
2. [機能2の説明]
3. [機能3の説明]

【UI要素】
- [UI要素1]：[説明]
- [UI要素2]：[説明]

【インタラクション】
- 右コントローラー：[動作]
- 左コントローラー：[動作]
- トリガーボタン：[動作]

【技術要件】
- [必要な機能やパッケージ]
```

## 📊 現在の環境仕様

| 項目 | 詳細 |
|------|------|
| Unity Version | 2022.3.62f1 LTS |
| Target Platform | Android (Meta Quest 3) |
| XR Plugin | OpenXR + Meta Quest Support |
| Rendering | URP (Universal Render Pipeline) |
| Input System | XR Interaction Toolkit |
| Unity MCP | Port 6400 |
| Project Path | C:\UnityProjects\MetaQuest3Template |

## 🔧 トラブルシューティング

### Unity MCPが接続できない場合
```
1. Unity EditorでWindow → Unity MCP
2. "Auto Configure Claude"をクリック
3. Claude Desktopを再起動
```

### Quest 3が認識されない場合
```cmd
adb kill-server
adb start-server
adb devices
```

### ビルドエラーが発生した場合
```
「Unity MCPでビルドエラーの詳細を確認して、解決方法を教えて」
```

## 📚 参考リンク

- [GitHubリポジトリ](https://github.com/YaAkiyama/MetaQuest3-VR-Template)
- [Unity XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html)
- [Meta Quest Developer Hub](https://developer.meta.com/horizon/)
- [OpenXR仕様](https://www.khronos.org/openxr/)

---

**最終更新**: 2025年8月12日
**作成者**: Unity MCP + GitHub MCP Integration
**ベースラインバージョン**: v1.0.0