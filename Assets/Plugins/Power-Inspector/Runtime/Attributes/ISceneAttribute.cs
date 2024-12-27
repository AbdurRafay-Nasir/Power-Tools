public interface ISceneAttribute
{
    /// <summary>
    /// Implement this to tell Power Editor what to draw in Scene View.
    /// </summary>
    /// <param name="target">The Object Being Inspected.</param>
    /// <param name="property">Serialized Information about the Field on which this attribute is applied.</param>
    void Draw(UnityEngine.Object target, UnityEditor.SerializedProperty property);

    /// <summary>
    /// There can be times when attribute is not valid on given Field. <br/>
    /// Implement this to tell Power Editor whether to draw in Scene view or not.
    /// </summary>
    /// <remarks>For example, DrawLine Attribute is valid on Transform type but not on SpriteRenderer.</remarks>
    /// <param name="property">Serialized Information about the Field on which this attribute is applied.</param>
    /// <returns>True if attribute is applied on valid Field, False otherwise.</returns>
    bool IsValid(UnityEditor.SerializedProperty property);
}
