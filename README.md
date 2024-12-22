# Power-Editor
:heavy_check_mark: Added  
:x: Planned  
:yellow_circle: In-Progress  

## Attributes
### FoldoutGroup :x:
- Groups fields.
- Similar to Array's foldout.
- Provides custom styling, which can be modified.
- Supports user-defined USS.
- Requires UsePowerAttributes on class.

### BoxGroup :x:
- Provides a background box to grouped fields.
- Provides custom styling, which can be modified.
- Supports user-defined USS.
- Requires UsePowerAttributes on class.

### ToggleGroup :x:
- Provides Toggle buttons on top of inspector.
- Similar to Tween Kit.
- Allows customizing size of toggle buttons.
- Requires UsePowerAttributes on class.

### ShowIfGroup :x:
- Displays group of fields only when a given condition is true.
- Requires UsePowerAttributes on class.

### HideIfGroup :x:
- Hides a group of fields only when a given condition is true.
- Requires UsePowerAttributes on class.

### EndGroup :x:
- Closes an open group.
- Allows closing multiple open groups with one EndGroup attribute.
- Requires UsePowerAttributes on class.

### ShowIf :x:
- Displays a field only when a given condition is true.

### HideIf :x:
- Hides a field only when a given condition is true.

### Required
- Displays an error message (in a helpbox) if object fiels is null.
- Applicable on Object reference fields. 

### Button :x:
- Displays a button at bottom of inspector.
- Applicable only on Mehods.
- This button executes code of function.

### HelpBox :x:
- Displays a helpbox on top/bottom of a field.

### ChildOnly :x:
- Restricts reference to be of child game object only.
- Applicable on Component fields only

### SceneObjectOnly
- Only allow assignment of objects that are in scene view.
- Applicable on Component fields only

### PrefabOnly :x;
- Only allow prefab assignment.
- Applicable on GameObject fields only.

### PreviewAsset
- Creates a preview of an asset in inspector
- Applicable on Sprite, Texture, Audio, Mesh

### Title :x;
- Adds a title, sub-title on top of a field.

### Separator :x:
- Separates a given int/float field using a separator char.

### Max
- Clamps a value to a maximum value.
- Applicable on float and int.

### Spacer :x:
- Adds a space before/after a field.
- Can also add horizontal lines before/after fields.

### Input
- Displays a dropdown, having all Input keys (old input-system) of project.
- Applicable on strings. 

### Bar :x:
- Displays a Progress bar for int/float field.
- Useful for displaying health/stamina/mana.

### Tag :x:
- Displays a dropdown, having all Tags wihtin a Project.
- Applicable only on strings.

### SortingLayer :x:
- Displays a dropdown, having all Sorting Layers wihtin a project.
- Applicable only on strings.

### SceneName
- Displays a dropdown, having all Scene names wihtin a project.
- Applicable only on strings.

### AnimatorParam :x:
- Requires a reference to an Animator component
- Displays a dropdown, having all parameters of this animator.
- Applicable on strings.

### AnimatorParamHash :x:
- Requires a reference to an Animator component
- Displays a dropdown, having all parameters of this animator.
- Applicable on int.

### PositionHandle
- Displays a Position Handle in scene view.
- Applicable on Vector2 and Vector3. 
- Requires UsePowerSceneAttribute.

### DrawLine
- Displays a line from current position to given vector in scene view.
- Applicable on Vector2 and Vector3.
- Requires UsePowerSceneAttribute.

### DrawPath
- Displays a line starting from index[0] to index[length - 1].
- Applicable on Vector2[], Vector3[], List<Vector2> and List<Vector3> .
- Requires UsePowerSceneAttribute.

### DrawRadius
- Displays a solid/wire sphere whose center is currentPosition.
- Applicable on float and int.
- Requires UsePowerSceneAttribute.

### DrawLabel
- Displays info in Scene View.
- Applicable on <unknown>. 
