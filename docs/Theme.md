## Themes & Styles Use Guide

App.xaml

``` xml
<ResourceDictionary Source="/Link.WPF.ThemeGallery;component/Themes/Theme.Dark.xaml" />
```


### About WindowStyle

* Window无法使用默认样式，必须指定样式。—— 提供两个主要窗体样式
    * WindowStyle_MainDefault —— 无标题栏，需要自己手动添加标题栏，如添加菜单栏，主要用于主窗口页面
    * WindowStyle_Default —— 保留原始的标题栏，仅仅更改了窗体的配色，以及系统按钮，常用于弹窗 ，其默认 `<Setter Property="ResizeMode" Value="NoResize"/>`


* TextBlock 
    * TextBlock设置默认样式会导致其他，如ComboBox的一些字体设置失效，故，此处提供Key为TextBlock_Default的样式作为默认样式，使用时，需指定样式