/*
README

Camera Collision Script
Lylek Games

Thank you for purchasing this asset!

CAMERA COLLISION PREFAB:
To use the Camera Collision, simply drag and drop the FocusPoint prefab from the Prefabs folder onto your player. Reset the
transform position to (0, 0, 0) so the FocusPoint is centered on the player. Then adjust the y axis so the pivot point
lies above your players head. You should be good to go!

Positioning the the focus point to the side of your player, along either the x or z axis, may not void obstacles from view of your player.
The FocusPoint should be centered on your player. Make sure the FocusPoint is positioned above any colliders attached to your player, or
mark them as trigger, so they are not mistaken for obstacles or walls.

CAMERA COLLISION SCRIPT:
Implementing the CameraCollision script without use of the provided prefab...
Attach the CameraCollision script to your Main Camera. This script requires a focus point for the camera to pivot.
Create an empty gameObject, name it FocusPoint, then parent and position it according to the FocusPoint guidelines, above.
Parent the Main Camera to the focus point, and assign FocusPoint as the focusPoint variable on the script attached to the Main Camera.

If you hit play now, your camera will be able to zoom in and out, as well as avoid obstacles that come between it and your
focus point. Note that this script does not integrate camera or player movement(other than camera zooming). In the example prefab we used Unity's
Third Person Character for player movement, and MouseLook script was used on both the player and the focus point for turning and angling
the camera. View the Character_Example prefab for reference.

SCRIPT VARIABLE COMPONENTS:
Focus Point		 : used as the focal rotation point, and raycast point | must be centered on the player(x and z)
Detection Radius : radius detection | used to prevent the camera from peeking through nearby walls
Zoom Distance	 : the distance the camera will zoom in and out per scroll
maxZoomDistance	 : used to limit distance you can zoom out, away from your character (maxZoomIn will be limited based on the starting position of the camera)

Use of other camera zooming scripts may interfere with the CameraCollision script. Scripts, other than MouseLook, that enable camera angling
should work, so long as they angle the focusPoint and not solely the camera itself.

If you need any help, please contact:
Email - support@lylekgames.com

Thank you. =)

*******************************************************************************************

Website
http://www.lylekgames.com/

Email
support@lylekgames.com
*/
