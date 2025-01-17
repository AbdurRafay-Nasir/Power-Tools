## FoldoutGroup

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [FoldoutGroup("Ints")]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;
}
```
![image](https://github.com/user-attachments/assets/adfab1c8-1b97-41b2-8261-653bf443a6d2)
![image](https://github.com/user-attachments/assets/ad6498ce-4264-4cc2-b093-b5f8d55e95ed)

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [FoldoutGroup("Ints")]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;     
    [EndGroup]

    [FoldoutGroup("Floats", MarginTop = 10f)]
    public float float1 = 2.5f;

    [FoldoutGroup("Doubles")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
    // EndGroup not required as no Fields remain
}
```
![image](https://github.com/user-attachments/assets/f964662b-2f2b-405a-a250-f9459681c6de)

## BoxGroup

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [BoxGroup(MarginVertical = 7f)]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;     
    [EndGroup]

    [BoxGroup(BorderColorHex = "#4EC9B0")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
}
```
![image](https://github.com/user-attachments/assets/85dbb780-1737-4f5e-9bfb-9c10ce97d275)













