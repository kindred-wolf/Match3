using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer {
	Match3 game;

	public override void OnGUI(Rect position,SerializedProperty property,GUIContent label){
		EditorGUI.PrefixLabel(position,label);
		Rect newposition = position;
		newposition.y += 18f;
		
		SerializedProperty data = property.FindPropertyRelative("rows");

		int height = data.arraySize;


		if (data.arraySize != 9)
		    data.arraySize = 9;
		//data.rows[0][]
		for (int j = 0; j < data.arraySize; j++) 
		{
			SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
			int width = row.arraySize;
			newposition.height = 18f;
			if(row.arraySize != 9)
				row.arraySize = 9;
			newposition.width = position.width/9;
			for(int i=0;i < row.arraySize; i++){
				EditorGUI.PropertyField(newposition,row.GetArrayElementAtIndex(i),GUIContent.none);
				newposition.x += newposition.width;
			}

			newposition.x = position.x;
			newposition.y += 18f;
		}
	}

	public override float GetPropertyHeight(SerializedProperty property,GUIContent label){
		return 18f * 10;
	}
}
