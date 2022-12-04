## ScrollViewer Helper - `ScrollViewerHelper`

> Nesting ScrollViewer Scroll & ScrollViewer Scroll Mode - Horizontal

### Sample Code

* Use Attach Property - **Recommend**   
``` xml
<!--ScrollViewer Scroll Horizontal-->
<ListBox cstk:ScrollViewerHelper.ScrollMode="HorizontalOnly" >
    <ListBox.ItemsPanel>
        <ItemsPanelTemplate>
            <VirtualizingStackPanel IsItemsHost="True" Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </ListBox.ItemsPanel>
</ListBox>

<!--Route Nesting ScrollViewer Scroll Event-->
<ScrollViewer>
    <StackPanel>
        <ListBox cstk:ScrollViewerHelper.ScrollParent="True" Height="200" />                   
    </StackPanel>
</ScrollViewer>
```

* Use Behavior
    * Add Refrence[Nuget add this automatically] 
        * Net40 - `System.Windows.Interactivity.dll`
        * Net45 and later - Nuget Package `Microsoft.Xaml.Behaviors.Wpf`
    * Add Namespace to xaml code:
        * Net40
        ``` xml
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
        ```
        * Net45 and later
        ``` xml
        xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
        ```
    * Add Behavior code
    ``` xml
    <ScrollViewer>
        <StackPanel>
            <ListBox Height="200" >
                <i:Interaction.Behaviors>
                    <cstk:IgnoreMouseWheelBehavior />
                </i:Interaction.Behaviors>
            </ListBox>
            <ListBox Height="200" >
                <i:Interaction.Behaviors>
                    <cstk:ScrollParentWhenAtEdge />
                </i:Interaction.Behaviors>
            </ListBox>
        </StackPanel>
    </ScrollViewer>
    ```

### When to Use

* `cstk:ScrollViewerHelper.ScrollHorizontal` - support scrollviewer **Scroll Horizontal**
* `cstk:ScrollViewerHelper.ScrollParent` - support nesting scrollviewer **Scroll Parent**
* `cstk:ScrollViewerHelper.ScrollParentDelay` - support nesting scrollviewer **Scroll Parent Delay**

* `IgnoreMouseWheelBehavior` - same as `ScrollViewerHelper.ScrollParent` + Disable scroll self
* `ScrollParentWhenAtEdge` - same as `ScrollViewerHelper.ScrollParent` 
