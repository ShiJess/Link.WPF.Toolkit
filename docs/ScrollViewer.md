## ScrollViewer Helper - `ScrollViewerHelper`

> Nesting ScrollViewer Scroll & ScrollViewer Scroll Horizontal

### Sample Code

* Use Attach Property   
    ``` xml
    <!--ScrollViewer Scroll Horizontal-->
    <ListBox cstk:ScrollViewerHelper.ScrollHorizontal="True" >
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
    * Add Refrence[Nuget add this automatically] - `System.Windows.Interactivity.dll`
    * Add Namespace to xaml code:
        ``` xml
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
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
* `IgnoreMouseWheelBehavior` - same as `ScrollViewerHelper.ScrollParent`
* `ScrollParentWhenAtEdge` - same as 'ScrollViewerHelper.ScrollParent'
