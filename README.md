# Skeleton Wave


## Tasks

- [x] Rigging Sprites with the 2D Animation Package
	- [x] Import 2D Animation Package
	- [x] Use Skeleton Character Sprites
		- [x] Find correct settings for Bones Geometry and Weights
		- [x] Select Skinning Editor in Sprite Editor
		- [x] Select Edit Bone Tab in Skinning Editor
		- [x] Create new bones following the spine of the character
		- [x] Add other bones for the Limbs
		- [x] Use the Preview pose settings to visualize the effects of the skeleton.
		- [x] Use the weight sliders to adjust the impact of the different weights.
		- [x] create apply to save the rigged sprite.
		- [x] Add the rigged sprite to the scene
		- [x] Add a sprite skin component to the game object.
		- [x] automaticcally create bones to show them in the hierarchy.		

- [x] Create a data structure to store the bones in.
	- [x] Class Pose
		- poseName
		- List of BoneTransforms 

	- [x] BoneTransform class
		- boneName string
		- position Vector3
		- rotation Quaternion
		- Constructor to assing the values
	- [x] Pose Collection Class
		- Scriptable Object storing a list of different poses.
	- [x] Capture Current Pose Method
		- Create new pose
		- iterate trhough all bones in the rig and store their transforms
	- [x] Are Poses Similar Method
		- Compare Current pose to predefined pose
		- Position Threshold and Rotation Threshold
		- Iterate through bones in predefined pose
		- find bones by name
		- Calculate the Distance between bones
		- Calculate the Quaterion Rotation between bones
		- Check if both values are bigger than the threshold value
		- return true of false
	- [x] Game Loop for iterating poses and checking if they are valid
	- [ ] Create In-Game Pose Editor
		- [x] Add colliders to interact with to each bone that should be able to interact with.
		- [ ] Create Method to select the bones (Raycasting the colliders)
		- [ ] Create Method to rotate the bone depending on the mouse movement after selection
		- [x] Identify each bone with a Tag
		- [ ] Find correct settings for the rotation sensitivity
		- [ ] Add Visual Feedback for the Selection
		- [ ] (Optional) Limit the rotation
		- [ ] (Optional) Make joint positions moveable, Use IK to make the rest of the skeleton follow this joint.
		
	

## Bugs

## Misc

## Notes
