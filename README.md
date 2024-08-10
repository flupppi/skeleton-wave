# Skeleton Wave


## Tasks

- [ ] Rigging Sprites with the 2D Animation Package
	- [ ] Import 2D Animation Package
	- [ ] Use Sample Character
		- [ ] Find correct settings for Bones Geometry and Weights
		- [ ] Select Skinning Editor in Sprite Editor
		- [ ] Select Edit Bone Tab in Skinning Editor
		- [ ] Remove the existing bones
		- [ ] Create new bones following the spine of the character
		- [ ] Add other bones for the Limbs
		- [ ] Use the Preview pose settings to visualize the effects of the skeleton.
		- [ ] Use the weight sliders to adjust the impact of the different weights.
		- [ ] create apply to save the rigged sprite.
		- [ ] Add the rigged sprite to the scene
		- [ ] Add a sprite skin component to the game object.
		- [ ] automaticcally create bones to show them in the hierarchy.
		- [ ] Now you can use keyframe animations to animate the rig. We dont really want to do that :) We will just IK solve the joints.
		

- [ ] Create a data structure to store the bones in.
	- [ ] Class Pose
		- poseName
		- List of BoneTransforms 

	- [ ] BoneTransform class
		- boneName string
		- position Vector3
		- rotation Quaternion
		- Constructor to assing the values
	- [ ] Pose Collection Class
		- Scriptable Object storing a list of different poses.
	- [ ] Capture Current Pose Method
		- Create new pose
		- iterate trhough all bones in the rig and store their transforms
	- [ ] Are Poses Similar Method
		- Compare Current pose to predefined pose
		- Position Threshold and Rotation Threshold
		- Iterate through bones in predefined pose
		- find bones by name
		- Calculate the Distance between bones
		- Calculate the Quaterion Rotation between bones
		- Check if both values are bigger than the threshold value
		- return true of false
	- [ ] Game Loop for iterating poses and checking if they are valid 
		
	

## Bugs

## Misc

## Notes
