## Link.WPF.Toolkit & Link.WPF.ThemeGallery

[![License](https://img.shields.io/github/license/ShiJess/Link.WPF.Toolkit)](LICENSE)

|Channel|Toolkit|ThemeGallery|
|:--:|:--:|:--:|
|NuGet| [![Link.WPF.Toolkit](https://img.shields.io/nuget/v/Link.WPF.Toolkit.svg)](https://www.nuget.org/packages/Link.WPF.Toolkit/) [![Link.WPF.Toolkit](https://img.shields.io/nuget/dt/Link.WPF.Toolkit)](https://www.nuget.org/packages/Link.WPF.Toolkit/) | [![Link.WPF.ThemeGallery](https://img.shields.io/nuget/v/Link.WPF.ThemeGallery.svg)](https://www.nuget.org/packages/Link.WPF.ThemeGallery/) [![Link.WPF.ThemeGallery](https://img.shields.io/nuget/dt/Link.WPF.ThemeGallery)](https://www.nuget.org/packages/Link.WPF.ThemeGallery/) |

* WPF Controls - [User Guide](docs/ReadMe.md)
* WPF Themes & Styles - [Choose Theme](docs/Theme.md)

<!--
|   |
|:---:|
|[`IPAddrBox` Control](docs/IPAddrBox.md)| 
-->

## For User - Usage

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

## For Developer - Develop Note

use .netstandard style *.proj

``` xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">
</Project>
```


## Other WPF Control Lib

[Extended WPF Toolkit](https://github.com/xceedsoftware/wpftoolkit)


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
    * some company classical style imitation, e.g:google style,ms style,ali style,netease style,etc.
    * attention:ContextMenu style,avoid separator exception


* Markdown support —— https://github.com/Kryptos-FR/markdig.wpf
    * https://github.com/neolithos/NeoMarkdigXaml

* EnumToDisplayNameConverter Enum Extention
    * add Ignore Attribute —— Enum GetValues ignore signed
    * 转中文数字大小写

* Wait Mask
    * delay hide —— e.g:hide wait message delay one second
* 常用validaterule-如数字。。。
* 添加datagrid类似控件，
    * 修改行功能：弹窗窗体or控件修改行
    * datagrid_冻结行列
    * DataGridTextExtColumn——控制editstyle输入
* 进度条
    * 圆形进度条
* textboxext——isnumber属性，控制输入
* 下拉框提供空项，直接置null
* 文件浏览，文件保存-filebrowserdialog。。。
* 定期刷新支持的listcollectionview——支持设置刷新模式
    * 立即刷新&定时刷新&堆栈数量刷新