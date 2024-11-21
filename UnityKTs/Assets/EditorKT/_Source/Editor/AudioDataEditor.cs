using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorKT.Editor
{
    [CustomEditor(typeof(AudioDataSO))]
    public class AudioDataEditor : UnityEditor.Editor
    {
        private SerializedProperty _id;
        private SerializedProperty _message;
        private SerializedProperty _audioType;

        private FieldInfo _listDrawField;
        private FieldInfo _messageDrawField;
        private FieldInfo _listsField;


        private AudioDataSO _script;

        public override void OnInspectorGUI()
        {
            _script = (AudioDataSO)target;

            SetProperty();

            DrawButtons();
            DrawMessageField();
            DrawIdField();
            DrawAudioTypeField();
            DrawListsField();

            if (GUILayout.Button("debug"))
                _script.D();

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_script);
        }

        private void DrawListsField()
        {
            var saveAsset = false;
            
            var oldLists = (List<AudioDataList>)_listsField.GetValue(_script);

            var newLists = new List<AudioDataList>();

            for (var index = 0; index < Enum.GetNames(typeof(AudioType)).Length; index++)
            {
                var typeName = Enum.GetNames(typeof(AudioType))[index];

                var item = oldLists.FirstOrDefault(x => x.TypeName == typeName);
                if(item == null)
                    saveAsset = true;
                
                newLists.Add(item ?? new AudioDataList(typeName));
            }

            if (saveAsset)
            {
                AssetDatabase.SaveAssets();
                saveAsset = false;
            }

            _listsField.SetValue(_script, newLists);

            if ((bool)_listDrawField.GetValue(_script))
            {
                var clips = newLists.First(x => x.TypeName == _audioType.enumNames[_audioType.enumValueIndex]);
                for (var index = 0; index < clips.Data.Count; index++)
                {
                    EditorGUILayout.BeginHorizontal("Box");

                    var setClip =
                        EditorGUILayout.ObjectField(GUIContent.none, clips.Data[index].Clip, typeof(AudioDataList),
                                false,
                                GUILayout.MaxWidth(345f))
                            as AudioClip;
                    clips.Data[index].SetClip(setClip);
                    GUILayout.Space(5);
                    
                    var tempVolume = clips.Data[index].Volume;
                    
                    clips.Data[index]
                        .SetVolume(EditorGUILayout.FloatField(clips.Data[index].Volume, GUILayout.MaxWidth(25f)));
                    GUILayout.FlexibleSpace();
                    
                    if(!Mathf.Approximately(tempVolume, clips.Data[index].Volume))
                        saveAsset = true;

                    if (GUILayout.Button("X", GUILayout.Height(20)))
                    {
                        clips.Data.RemoveAt(index);
                        saveAsset = true;
                    }

                    EditorGUILayout.EndHorizontal();
                }
                
                if(saveAsset)
                    AssetDatabase.SaveAssets();

                var newClip = EditorGUILayout.ObjectField("New Clip", null, typeof(AudioClip), false) as AudioClip;

                if (newClip)
                {
                    clips.Data.Add(new AudioData(newClip, 1f));
                    AssetDatabase.SaveAssets();
                }
            }
        }

        private void DrawIdField()
        {
            if ((bool)_messageDrawField.GetValue(_script))
                EditorGUILayout.PropertyField(_id);
        }

        private void DrawMessageField()
        {
            if ((bool)_messageDrawField.GetValue(_script))
                EditorGUILayout.PropertyField(_message);
        }

        private void DrawAudioTypeField()
        {
            if (!(bool)_listDrawField.GetValue(_script))
                return;

            EditorGUILayout.PropertyField(_audioType);
        }

        private void DrawButtons()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Labels")) _messageDrawField.SetValue(_script, true);
            if (GUILayout.Button("List")) _listDrawField.SetValue(_script, true);
            if (GUILayout.Button("Hide"))
            {
                _messageDrawField.SetValue(_script, false);
                _listDrawField.SetValue(_script, false);
            }

            EditorGUILayout.EndHorizontal();
        }

        private void SetProperty()
        {
            _id = serializedObject.FindProperty("id");
            _message = serializedObject.FindProperty("message");
            _audioType = serializedObject.FindProperty("audioType");

            _listDrawField =
                _script.GetType().GetField("_showList", BindingFlags.NonPublic | BindingFlags.Instance);

            _messageDrawField =
                _script.GetType().GetField("_showLabel", BindingFlags.NonPublic | BindingFlags.Instance);

            _listsField =
                _script.GetType().GetField("audioData", BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}