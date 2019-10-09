# vrtest
 这是一个用 `unity 3d` 实现手机VR摄像头的 demo

## 视频展示
![](https://github.com/jiiiimmmmmmm/vrtest/blob/master/展示视频gif.gif)

## 解决方案
 首先我们来了解一下unity是如何获取手机陀螺仪数据的,这是来自unity官网的api文本，因为这个unity的api文本获取很慢，所以我就直接复制了文字，如果想深入学习unity的话，建议大家下载一个离线版api
### Gyroscope
#### Description
Interface into the Gyroscope.
Use this class to access the gyroscope. The example script below shows how the Gyroscope class can be used to view the orientation in space of the device.
#### Properties
Underlying sensors used for data population:
attitude	Returns the attitude (ie, orientation in space) of the device.
enabled	Sets or retrieves the enabled status of this gyroscope.
gravity	Returns the gravity acceleration vector expressed in the device's reference frame.
rotationRate	Returns rotation rate as measured by the device's gyroscope.
rotationRateUnbiased	Returns unbiased rotation rate as measured by the device's gyroscope.
updateInterval	Sets or retrieves gyroscope interval in seconds.
userAcceleration	Returns the acceleration that the user is giving to the device.


