# VRCPhotoAlbum


<img src="https://github.com/gatosyocora/VRCPhotoAlbum/blob/master/images/VRCPhotoAlbum_previewimage.png" width="50%"/>


VRChatで撮影した写真をながめるためのWindows向けアプリケーションです

日付情報から写真の日付や期間検索や簡単な画像処理ができます。  
[vrc_meta_tool](https://github.com/27Cobalter/vrc_meta_tool)でメタ情報をいれた写真であれば,  
撮影したユーザーやワールド, 日時の情報を表示したり, それらを元に検索したりできます.

latest release : ver 0.4

## 動作確認環境
* Windows10 64bit バージョン1903
* Intel i7-7000

## 画面構成

### 写真一覧画面
<img src="https://github.com/gatosyocora/VRCPhotoAlbum/blob/master/images/VRCPhotoAlbum_topimage.png" width="50%"/>

画像フォルダ以下にある写真をすべて表示した画面です.  
検索機能などがあります.

### 写真詳細画面
<img src="https://github.com/gatosyocora/VRCPhotoAlbum/blob/master/images/VRCPhotoAlbum_previewimage.png" width="50%"/>

選択した写真の詳細を表示した画面です.  
写真に埋め込まれたメタ情報などを表示しています.  
各情報を選択することで絞り込み検索ができます.

### 設定画面
<img src="https://github.com/gatosyocora/VRCPhotoAlbum/blob/master/images/VRCPhotoAlbum_settingimage.png" width="50%"/>

設定を確認および変更できる画面です.
以下, 現在できることです.
* 表示する写真が入ったフォルダの選択
* キャッシュ情報とキャッシュの削除
* テスト機能の有効無効の切り替え

## 使い方
### 初回起動時
1. 設定画面が表示されるので「画像フォルダ」横の「参照」を選択し, 写真が入ったフォルダを選択します.  
(vrc_meta_toolでメタ情報をいれた写真があるフォルダを選択するのをオススメします)
2. 「適用」を選択します.


### 写真を表示
1. 写真一覧画面で写真を選択する.
2. 写真詳細画面が表示される.


### 写真を検索
A. 写真一覧画面上部の検索欄に検索したいユーザー名またはワールド名を入力する.  
(入力した文字が部分的に一致するユーザーとワールドを検索します)

B. 写真詳細画面のユーザー名またはワールド名横のボタン, 日時横のボタンを選択する.  
(選択したものに完全一致するものを検索します)

C. 写真一覧画面にある日付入力欄で日付を選択する.  
または「今日」ボタンを選択する.  
(選択した日付に撮影されたものを検索します)

D. 写真一覧画面にある「今週」「今月」ボタンを選択する.  
(選択した期間に撮影されたものを検索します)

### 管理する写真フォルダを変更
1. 写真詳細画面の右下にある「歯車ボタン」を選択し, 設定画面を開く.
2. 設定画面上部の「画像フォルダ」横の「参照」ボタンを選択し, 対象フォルダを選択する.
3. 画面下の「適用」ボタンを選択する.

### 写真にうつった人のTwitterを探す
[vrc_meta_tool](https://github.com/27Cobalter/vrc_meta_tool)の機能でTwitter情報も写真に埋め込んでいる場合,  
その写真の写真詳細画面のユーザー一覧の対象ユーザー横に「Twitterボタン」が表示されます.

### 画像を回転 [テスト機能]
テスト機能なので最悪の場合, 画像を破損させてしまう可能性があります.  
あらかじめご了承ください
1. 設定画面の「テスト機能」を選択し, チェックを入れる
2. 「適用」ボタンを選択する.
3. 写真一覧画面で回転させたい画像を選択する
4. 画面詳細画面の上部の「回転」ボタンを選択する.
  * 左90度回転
  * 水平方向反転
  * 右90度回転

## 更新履歴
(ver0.4.0)
* vrc_meta_toolを使用していない写真もファイル名から日付情報を取得するように
* ファイルエクスプローラを開くボタンを追加

(ver0.3.1)
* 写真が増える不具合を修正

(ver0.3)
* アプリケーションを一新(従来の機能はなくなった)
* vrc_meta_toolで埋め込んだ情報を表示できるように
* ユーザー, ワールド, 日付, 期間で検索できるように

(ver0.2)
* 常駐アプリ化(インジケーターに表示されるようになった, 右クリックでウィンドウ表示,写真整理,終了が可能)
* スタートアップに登録/解除(インジケーターのアイコン右クリックからおこなう)

(ver0.1)
* 写真を日付ごとのフォルダに分ける
* 日付ごとのフォルダの一覧を表示（それぞれに含まれる写真の数を表示）
* 写真の枚数順にフォルダ一覧を並べ替え
* 日付順にフォルダ一覧を並べ替え
* 特定のフォルダの写真一覧をサムネイル付きで表示
* 写真を選択すると既存のアプリケーションで開く

## 利用規約など
MITライセンスです。詳しくは[LICENSE](https://github.com/gatosyocora/VRCPhotoAlbum/blob/master/LICENSE)へ

## インストール
1. [releases](https://github.com/gatosyocora/VRCPhotoAlbum/releases)からVRCPhotoAlbum_vXXX.zipをダウンロードして解凍(XXXはバージョン)
2. VRCPhotoAlbum.exeを起動する

## アンインストール
インストールしたフォルダごと削除する

## 開発環境
* Windows 10
* .NET Core 3.1
* Visual Studio 2019

## 使用ライブラリ
### アーキテクチャ
* ReactiveProperty [[MIT License](https://github.com/runceel/ReactiveProperty/blob/master/LICENSE.txt)]
### データ処理
* VrcMetaTool.NET [[MIT License](https://github.com/KoyashiroKohaku/VrcMetaTool.NET/blob/master/LICENSE)]
* Microsoft.EntityFrameworkCore.Sqlite [[Apache-2.0](https://github.com/dotnet/efcore/blob/master/LICENSE.txt)]
### デザイン・レイアウト
* Microsoft.Xaml.Behaviors.Wpf [[MIT License](https://github.com/microsoft/XamlBehaviorsWpf/blob/master/LICENSE)]
* MahApps.Metro [[MIT License](https://github.com/MahApps/MahApps.Metro/blob/develop/LICENSE)]
* MaterialDesignInXamlToolkit [[MIT License](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/blob/master/LICENSE)]
  * MaterialDesignThemes.MahApps
  * MaterialDesignThemes
  * MaterialDesignColors
* VirtualizingWrapPanel [[MIT License](https://gitlab.com/sbaeumlisberger/virtualizing-wrap-panel/-/blob/develop/LICENSE)]
### その他
* Nito.AsyncEx [[MIT License](https://github.com/StephenCleary/AsyncEx/blob/master/LICENSE)]
