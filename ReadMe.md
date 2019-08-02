## Link.WPF.Toolkit

[![NuGet](https://img.shields.io/nuget/v/Link.WPF.Toolkit.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Link.WPF.Toolkit/)

WPF Controls - [Use Guide](docs/ReadMe.md)

|   |
|:---:|
|[`IPAddrBox` Control](docs/IPAddrBox.md)| 


## For User - How to Use

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

New UserControl orginial code:

``` xml
<None Update="UserControl1.xaml">
    <Generator>MSBuild:Compile</Generator>
</None>
```

Need change to:

``` xml
<Page Include="UserControl1.xaml">
    <Generator>MSBuild:Compile</Generator>
</Page>
```

## Other WPF Control Lib

[Extended WPF Toolkit](https://github.com/xceedsoftware/wpftoolkit)