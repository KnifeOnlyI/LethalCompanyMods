using System;
using UnityEngine;

namespace MyFirstMod.gui
{
    internal class Gui : MonoBehaviour
    {
        private static Rect _guiRect = new Rect(0, 0, 540, 240);
        private Texture2D _box;
        private GameObject _shipSpeakerAudio;

        private void Awake()
        {
            _box = CreateTexture(new Color32(40, 40, 40, 255));
            
            _shipSpeakerAudio = GameObject.Find("SpeakerAudio");

            if (_shipSpeakerAudio != null)
            {
                _shipSpeakerAudio.gameObject.SetActive(false);
            }
        }

        private void OnGUI()
        {
            // GUI.skin = GUI.skin ? GUI.skin : ScriptableObject.CreateInstance<GUISkin>();
            // GUI.skin.box = CreateBoxStyle(_box);
            // GUI.skin.window = CreateWindowStyle(_box);

            GUILayout.BeginArea(new Rect(10, 10, 640, 480));
            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.Label("");
            GUILayout.EndHorizontal();

            GUILayout.EndArea();

            // GUILayout.BeginHorizontal();
            // Data.InfiniteStamina = GUILayout.Toggle(Data.InfiniteStamina, "Infinite stamina");
            // GUILayout.EndHorizontal();
        }

        private static Texture2D CreateTexture(Color32 color)
        {
            var texture = new Texture2D(1, 1);

            texture.SetPixel(0, 0, color);
            texture.Apply();

            return texture;
        }

        public GUIStyle CreateWindowStyle(Texture2D background)
        {
            return new GUIStyle(GUI.skin.window)
            {
                normal =
                {
                    background = background,
                    textColor = Color.white
                },
                onNormal =
                {
                    background = background,
                    textColor = Color.white
                }
            };
        }

        private static GUIStyle CreateBoxStyle(Texture2D normal)
        {
            return new GUIStyle(GUI.skin.box)
            {
                normal =
                {
                    background = normal,
                    textColor = Color.white
                },
                hover =
                {
                    background = normal,
                    textColor = Color.white
                },
                active =
                {
                    background = normal,
                    textColor = Color.white
                }
            };
        }
    }
}