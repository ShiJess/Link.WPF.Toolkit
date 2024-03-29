## Link.WPF.Toolkit & Link.WPF.ThemeGallery

[![License](https://img.shields.io/github/license/ShiJess/Link.WPF.Toolkit)](LICENSE)

|Channel|Toolkit|ThemeGallery|
|:--:|:--:|:--:|
|NuGet| [![Link.WPF.Toolkit](https://img.shields.io/nuget/v/Link.WPF.Toolkit.svg)](https://www.nuget.org/packages/Link.WPF.Toolkit/) [![Link.WPF.Toolkit](https://img.shields.io/nuget/dt/Link.WPF.Toolkit)](https://www.nuget.org/packages/Link.WPF.Toolkit/) | [![Link.WPF.ThemeGallery](https://img.shields.io/nuget/v/Link.WPF.ThemeGallery.svg)](https://www.nuget.org/packages/Link.WPF.ThemeGallery/) [![Link.WPF.ThemeGallery](https://img.shields.io/nuget/dt/Link.WPF.ThemeGallery)](https://www.nuget.org/packages/Link.WPF.ThemeGallery/) |

### Guide Docs

* WPF Controls - [User Guide](docs/ReadMe.md)
* WPF Themes & Styles - [Choose Theme](docs/Theme.md)


## For User - Usage

> More See Guide Docs

* Add Namespace to xaml code
    * Like this:
    ``` xml
    xmlns:cstk="http://schemas.canself.com/wpf/xaml/toolkit"
    ```
* Use Control
    * Sample Code:
    ``` xml
    <cstk:IPAddrBox Text="192.168.1.1" />
    ```

## For Developer - Develop Notes

* Use `.netstandard` style `*.csproj`
* For .Net Framework 4.5 and older
    * You need Visual Studio 2019 Install SDK
    * Visual Studio 2022 not support official, but Can Use Older SDK Installed By VS2019

``` xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>    
        <UseWPF>true</UseWPF>
    </PropertyGroup>
</Project>
```

* net45 and later reference changed

> Notes: In Samples Project, Net40 xmlns namespace need change manual

``` xml
<!-- replace System.Windows.Interactivity.dll -->
<PackageReference Include="Microsoft.Xaml.Behaviors.Wpf" Version="1.1.39" />
<!-- replace System.ComponentModel.DataAnnotations -->
<PackageReference Include="System.ComponentModel.Annotations" Version="5.0.0" />
```


## Other WPF Control Lib

* ~~[WPF Toolkit: Xceed Extended WPF Toolkit](https://github.com/xceedsoftware/wpftoolkit)~~ : New Version (v4.0.0) License More Limited
* [MaterialDesignInXamlToolkit: Material Design in XAML & WPF](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
* [ControlzEx: Shared Controlz for WPF](https://github.com/ControlzEx/ControlzEx)

## RoadMap

* About `ScrollViewer`:
    * ~~Nesting ScrollViewer -- Scroll Parent when internal scrollviewer scroll to end;~~
    * ~~Scroll Vertical After Horizontal & Scroll Horizontal After Vertical~~
    * Auto Scroll[When content change] - always scroll to end & When mouse is pressed, mouse wheel scroll disable
* About `PasswordTextBox` - passwordbox/passwordtextbox
    * Password Binding Support
    * Show Password Support
* About `DateTimePicker`
    * `Hour.Minute.Second` Support
* Custom Window - `WindowChrome`
    * ~~Custom Min&Max&Close button~~
    * F11 max process,need hide close button
* MessageBox support customization
* custom FileDialog,FolderBrowserDialog
* Watermark Input TextBox
* MultiCheck ComboBox
* TextBox with line number
* ListBox With Grid Panel - use some attach helper?
* Number TextBox With UpDown Button
    * Double Number TextBox - Support dot input when use `UpdateSourceTrigger=PropertyChanged` - official TextBox not support

* Add Style Lib - provide some common style
    * common control style, e.g:TextBox,Button,ComboBox,etc.
    * some company classical style imitation, e.g:google style/material,ms style/fluent,ali style/ant,~~netease style~~,etc.
    * attention:ContextMenu style,avoid separator exception


* Markdown support —— https://github.com/Kryptos-FR/markdig.wpf
    * https://github.com/neolithos/NeoMarkdigXaml

* EnumToDisplayNameConverter Enum Extention
    * add Ignore Attribute —— Enum GetValues ignore signed
    * 转中文数字大小写

* Wait Mask
    * delay hide —— e.g:hide wait message delay one second
* ~~常用validaterule-如数字。。。~~
* 添加datagrid类似控件，
    * 修改行功能：弹窗窗体or控件修改行
    * datagrid_冻结行列
    * DataGridTextExtColumn——控制editstyle输入
* 进度条
    * 圆形进度条 [在ThemeGallery中添加]
* textboxext——isnumber属性，控制输入
* 下拉框提供空项，直接置null
* 文件浏览，文件保存-filebrowserdialog。。。
* 定期刷新支持的listcollectionview——支持设置刷新模式
    * 立即刷新&定时刷新&堆栈数量刷新

* ~~Validation 数据验证，添加各类验证rule及界面验证 建议调用方法~~