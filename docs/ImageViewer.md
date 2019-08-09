## Image Viewer - `ImageViewer`

> Add Zoom & Drag Support.

### Sample Code:

``` xml
<cstk:ImageViewer Source="Resources/Image_Temp.png" />
```

* `Ctrl + Mouse Wheel` - Zoom Control
* `Right Mouse Button` - Drag Move

### Properties

|Property|Description|
|:---:|:---:|
|Source|Image Source|
|ZoomScale|Image Scaling Ratio|



### RoadMap - Unrealized

* Min&Max Scaling Ratio Setting -max scaling
* Zoom Control Mode - how control zoom,default ctrl+mousewheel,other like mousewheel
* Zoom Change Value - How many Change,current 10% increase or decrease,other like fixed value 1; - referance GridLength Struct