## Link.WPF.Toolkit

WPF Controls


## For Developer

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