﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Resources
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("WSLMan.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Abort running process? (Data may be lost.) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property AbortProcessPrompt() As String
            Get
                Return ResourceManager.GetString("AbortProcessPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cannot change .vhdx file name. (The file may be in use.) Reason: {0} に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property CannotChangeVhdFileName() As String
            Get
                Return ResourceManager.GetString("CannotChangeVhdFileName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Before changing the base path, this program will copies files from the previous path to the new path. During copying, please don&apos;t use this distribution or otherwise data may be broken. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ChangingBasePathPrompt() As String
            Get
                Return ResourceManager.GetString("ChangingBasePathPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Close に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property CloseText() As String
            Get
                Return ResourceManager.GetString("CloseText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Distribution has been installed. To continue setup, will open a console window. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property DistributionInstallDone() As String
            Get
                Return ResourceManager.GetString("DistributionInstallDone", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Close &amp;configuration に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property DistributionPageButtonCloseConf() As String
            Get
                Return ResourceManager.GetString("DistributionPageButtonCloseConf", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Open &amp;configuration に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property DistributionPageButtonOpenConf() As String
            Get
                Return ResourceManager.GetString("DistributionPageButtonOpenConf", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Executing... (command: {0}) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ExecutingMessage() As String
            Get
                Return ResourceManager.GetString("ExecutingMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Failed to reboot system. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property FailedToRebootMessage() As String
            Get
                Return ResourceManager.GetString("FailedToRebootMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  All files (*.*)|*.* に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property FileDialogFilterAllFiles() As String
            Get
                Return ResourceManager.GetString("FileDialogFilterAllFiles", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Harddisk files (*.vhdx)|*.vhdx に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property FileDialogFilterHarddiskFiles() As String
            Get
                Return ResourceManager.GetString("FileDialogFilterHarddiskFiles", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  tarball files (*.tar)|*.tar に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property FileDialogFilterTarFiles() As String
            Get
                Return ResourceManager.GetString("FileDialogFilterTarFiles", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Installing... に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property Installing() As String
            Get
                Return ResourceManager.GetString("Installing", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Invalid value. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property InvalidValueMessage() As String
            Get
                Return ResourceManager.GetString("InvalidValueMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  (Without distribution) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property NoInstallDistribution() As String
            Get
                Return ResourceManager.GetString("NoInstallDistribution", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Open previous path in Explorer? に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property OpenOldPathPrompt() As String
            Get
                Return ResourceManager.GetString("OpenOldPathPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Exited with code {0} (command: {1}) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ProcessExitedWithCode() As String
            Get
                Return ResourceManager.GetString("ProcessExitedWithCode", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Terminate distribution &quot;{0}&quot;? (Data may be lost.) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property TerminateDistributionPrompt() As String
            Get
                Return ResourceManager.GetString("TerminateDistributionPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Are you sure to unregister &apos;{0}&apos;? (All distribution data including .vhdx will be lost.) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property UnregisterConfirmPrompt() As String
            Get
                Return ResourceManager.GetString("UnregisterConfirmPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  wsl.exe is not found. Please apply Windows Update. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property WSLExeNotFoundMessage() As String
            Get
                Return ResourceManager.GetString("WSLExeNotFoundMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  The distribution has been imported. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property WSLImportDone() As String
            Get
                Return ResourceManager.GetString("WSLImportDone", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  WSL has been installed.
        '''
        '''To apply changes, you must restart your computer. Restart now? に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property WSLInstallDone() As String
            Get
                Return ResourceManager.GetString("WSLInstallDone", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  This distribution is not stopped. Before copying the distribution needs to be stopped. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property WSLNotStoppedForChangingBasePath() As String
            Get
                Return ResourceManager.GetString("WSLNotStoppedForChangingBasePath", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  To apply changes, WSL service needs to restart.
        '''
        '''Restart now? (Console window will be displayed.) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property WSLServiceNeedToRestart() As String
            Get
                Return ResourceManager.GetString("WSLServiceNeedToRestart", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
