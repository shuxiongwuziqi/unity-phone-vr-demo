# vrtest
 这是一个用 `unity 3d` 实现手机VR的 demo

## 视频展示
![](https://github.com/jiiiimmmmmmm/vrtest/blob/master/展示视频gif.gif)

## 解决方案
### 陀螺仪状态获取
 首先我们来了解一下unity是如何获取手机陀螺仪数据的,这是来自unity官网的api文本，因为这个unity的api文本获取很慢，所以我就直接复制了文字，如果想深入学习unity的话，建议大家下载一个离线版api文档。
 
#### Gyroscope
#### Description
Interface into the Gyroscope.
Use this class to access the gyroscope. 
#### Properties
Underlying sensors used for data population:
`attitude`	Returns the attitude (ie, orientation in space) of the device.
`enabled`	Sets or retrieves the enabled status of this gyroscope.
`gravity`	Returns the gravity acceleration vector expressed in the device's reference frame.
`rotationRate`	Returns rotation rate as measured by the device's gyroscope.
`rotationRateUnbiased`	Returns unbiased rotation rate as measured by the device's gyroscope.
`updateInterval`	Sets or retrieves gyroscope interval in seconds.
`userAcceleration`	Returns the acceleration that the user is giving to the device.

 这个文档告诉我们Gyroscope这个类可以访问手机的陀螺仪，其中类属性有7个，上面已经给出了每个属性的含义，其中`attitude`、`rotationRate`和`rotationRateUnbiased`这三个属性理论上都可以获得手机转向信息，`rotationRate`和`rotationRateUnbiased`的区别是`rotationRate`不能做到平滑过渡，如果使用它会出现相机抖动严重的问题，而`rotationRateUnbiased`可以说是在`rotationRate`属性上做了平滑优化，以上两个属性的共同点是都是记录了陀螺仪转向的变化量，而`attitude`却是记录了陀螺仪现在的转向状态，在使用attitude属性的过程中，我发现如果直接使用attitude会出现很多错误，这个是手机坐标系和unity的坐标系不一致造成的，需要做转换，这样就加大了难度，所以我最后还是使用`rotationRateUnbiased`来获取陀螺仪的转向了。


### 如何实现双画面
 要让手机屏幕分别呈现左右眼所需要看到的场景，这个时候就需要创建连个摄像头来代表两个眼睛，对摄像头属性的改变如下：
  Viewport Rect for `right eye camera` X:0.5 Y:0 W:0.1 H:1
  Viewport Rect for `left eye camera` X:0.5 Y:0 W:0.1 H:1
  Rotation for `right eye camera` X:0.05 Y:-1 Z:0
  Rotattion for `left eye camera` X:-0.05 Y:1 Z:0
  其他属性保持默认即可
  
  
### 如何还原到初始视图
 我使用的眼vr眼镜盒子是`爱奇艺pro`，屏幕正上方可以有一个自定义按钮，所以在手机屏幕正上方我就加了一个reset按钮，这样就可以非常方便的还原视图了。

### 如何实现双画面边沿的黑色遮罩和绿色中心游标
 在使用眼镜的过程中，这个黑色边缘是看不到的，但是我发现现在流行的手机vr应用都有这个东西，可能是觉得加上会炫酷一点吧。而绿色中心游标的作用主要是方便以后实现vr摄像头对场景的交互。
 这个实现起来也比较简单，添加两个`Canvas`,然后把`Render Mode`设置为`Screen Space -Camera`,然后`Render Camera`设置为代表两个眼睛的`Camera`，然后在两个Canvas上面添加黑色遮罩图片，还有绿色中心游标图片。需要注意的是，如果需要图片透明部分表现为透明，需要把图片的`Texture Type`设置为`Sprite`,`Advanced`在下面的`Alpha Source`设置为`Input Texture Alpha`,然后就ok了。
 
 





