# Power-Editor
:heavy_check_mark: Added  
:x: Planned  
:yellow_circle: In-Progress  

## Attributes
### :x: FoldoutGroup
- Groups fields.
- Similar to Array's foldout.
- Provides custom styling, which can be modified.
- Supports user-defined USS.
- Requires UsePowerAttributes on class.

### :x: BoxGroup
- Provides a background box to grouped fields.
- Provides custom styling, which can be modified.
- Supports user-defined USS.
- Requires UsePowerAttributes on class.

### :x: ToggleGroup
- Provides Toggle buttons on top of inspector.
- Similar to Tween Kit.
- Allows customizing size of toggle buttons.
- Requires UsePowerAttributes on class.

### :x: ShowIfGroup
- Displays group of fields only when a given condition is true.
- Requires UsePowerAttributes on class.

### :x: HideIfGroup
- Hides a group of fields only when a given condition is true.
- Requires UsePowerAttributes on class.

### :x: EndGroup 
- Closes an open group.
- Allows closing multiple open groups with one EndGroup attribute.
- Requires UsePowerAttributes on class.

### :x: ShowIf
- Displays a field only when a given condition is true.

### :x: HideIf
- Hides a field only when a given condition is true.

### :heavy_check_mark: Required
- Displays an error message (in a helpbox) if object field is null.
- Applicable on Object reference fields. 

### :heavy_check_mark: Button
- Displays a button at bottom of inspector.
- Applicable only on Mehods.
- This button executes code of function.

### :heavy_check_mark: HelpBox
- Displays a helpbox on top/bottom of a field.

### :heavy_check_mark: GetFromSelf
- Automatically get component.

### :heavy_check_mark: GetFromParent
- Automatically gets component from parent gameObject.
- Can search all successors

### :heavy_check_mark: GetFromChild
- Automatically gets component from child gameObject.
- Can search all childs

### :heavy_check_mark: FolderPath <Fix Pending>
- Creates a button, that when clicked opens up file explorer
- Applicable on string fields only

### :heavy_check_mark: FilePath
- Creates a button, that when clicked opens up file explorer
- Applicable on string fields only

### :x: ParentOnly
- Restricts reference to be of parent game object only.
- Applicable on Component fields only.
 
### :x: ChildOnly
- Restricts reference to be of child game object only.
- Applicable on Component fields only.

### :x: SceneObjectOnly
- Only allow assignment of objects that are in scene view.
- Applicable on Component fields only

### :heavy_check_mark: PrefabOnly
- Only allow prefab assignment.
- Applicable on GameObject fields only.

### :x: PreviewSprite
- Creates a preview of an asset in inspector
- Applicable on Sprite.

### :x: PreviewTexture
- Creates a preview of an asset in inspector
- Applicable on Texture.

### :x: PreviewMesh
- Creates a preview of an asset in inspector
- Applicable on Mesh.

### :x: PreviewAudioClip
- Creates a preview of an asset in inspector
- Applicable on AudioClip.

### :x: Title
- Adds a title, sub-title on top of a field.

### :x: Separator
- Separates a given int/float field using a separator char.

### :x: PowerMax
- Clamps a value to a maximum value.
- Allows expression to dynamically set clamping value.
- Applicable on float and int.

### :x: PowerMin
- Clamps a value to a minimum value.
- Allows expression to dynamically set clamping value.
- Applicable on float and int.

### :x: PowerRange
- Clamps a value to a min and max value.
- Allows expression to dynamically set clamping value.
- Applicable on float and int.

### :x: Spacer
- Adds a space before/after a field.
- Can also add horizontal lines before/after fields.

### :x: Input
- Displays a dropdown, having all Input keys (old input-system) of project.
- Applicable on strings. 

### :x: Bar
- Displays a Progress bar for int/float field.
- Useful for displaying health/stamina/mana.

### :x: Tag
- Displays a dropdown, having all Tags wihtin a Project.
- Applicable only on strings.

### :x: SortingLayer
- Displays a dropdown, having all Sorting Layers wihtin a project.
- Applicable only on strings.

### :heavy_check_mark: SceneName
- Displays a dropdown, having all Scene names wihtin build settings.
- Applicable only on strings.

### :x: AnimatorParam
- Requires a reference to an Animator component
- Displays a dropdown, having all parameters of this animator.
- Applicable on strings.

### :x: AnimatorParamHash
- Requires a reference to an Animator component
- Displays a dropdown, having all parameters of this animator.
- Applicable on int.

### :x: FieldGUI
- Allows complete modification of a Property Field.
- Can also use userdefined USS.

### :heavy_check_mark: PositionHandle
- Displays a Position Handle in scene view.
- Applicable on Vector2 and Vector3. 
- Requires UsePowerSceneAttribute.

### :heavy_check_mark: DrawLine
- Displays a line from current position to given vector in scene view.
- Applicable on Transform, Vector2 and Vector3.
- Requires UsePowerSceneAttribute.

### :x: DrawPath
- Displays a line starting from index[0] to index[length - 1].
- Applicable on Transform[], Vector2[], Vector3[], List<Vector2> and List<Vector3> .
- Requires UsePowerSceneAttribute.

### :heavy_check_mark: DrawRadius
- Displays a solid/wire sphere whose center is currentPosition.
- Applicable on float and int.
- Requires UsePowerSceneAttribute.

### :x: DrawLabel
- Displays info in Scene View.
- Applicable on <unknown>. 
