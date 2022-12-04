## Control Use Guide

* Add Namespace to xaml code first:

``` xml
xmlns:cstk="http://schemas.canself.com/wpf/xaml/toolkit"
```

* Use Control

|Control|Summary|
|:---:|:---:|
|[`IPAddrBox` Control](IPAddrBox.md)| IP Address Control - Like `192.168.1.1` |
|[`ImageViewer` Control](ImageViewer.md)| Image Viewer With Zoom & Drag |
|[`ScrollViewer` Helper](ScrollViewer.md)| ScrollView Helper - Nesting and Horizontal process|
|[`RichTextBlock` Control](RichTextBlock.md)| Rich TextBlock - Para Indent Support |


* Common ValueConverter

``` xml
<converter:EnumToDisplayNameConverter x:Key="EnumToNameConverter"/>
<converter:EnumToDescriptionConverter x:Key="EnumToDescriptionConverter"/>
<converter:InverseBooleanConverter x:Key="InverseBooleanConverter"/>
```

* NullEmptyToBoolean Series Converter
    * Source: Empty / Zero / Null
    * Target: Visibility / Bool
        * Default False: Visibility.Collapsed / False
        * False Use Param Support: Visibility.Hidden / Null

* Validation Rule
    * For reference only: Because ErrorContent Maybe Not Same