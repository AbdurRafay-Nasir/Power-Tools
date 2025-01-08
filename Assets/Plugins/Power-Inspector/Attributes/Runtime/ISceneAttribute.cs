namespace PowerTools.Attributes
{
    public interface ISceneAttribute
    {
        public bool hideWhenInspectorIsClosed { get; set; }

        /// <summary>
        /// Implement this to tell Power Editor what to draw in Scene View.
        /// </summary>
        /// <param name="target">The Object Being Inspected.</param>
        /// <param name="property">Serialized Information about the Field on which this attribute is applied.</param>
        void Draw(UnityEngine.Object target, UnityEditor.SerializedProperty property, 
                  System.Reflection.FieldInfo field);
    }
}