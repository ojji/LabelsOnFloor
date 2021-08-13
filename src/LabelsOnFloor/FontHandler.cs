using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace LabelsOnFloor
{
    public struct CharBoundsInTexture
    {
        public float Left, Right;
    }

    public class FontHandler
    {
        private float _charWidthAsTexturePortion = -1f;

        private Material _material;

        public bool IsFontLoaded()
        {
            if (Resources.Font == null)
                return false;

            if (_charWidthAsTexturePortion < 0f)
                _charWidthAsTexturePortion =  35f / Resources.Font.width;

            return true;
        }

        public Material GetMaterial()
        {
            if (_material == null)
            {
                var color = (Main.Instance.UseLightText()) ? Color.white : Color.black;
                color.a = Main.Instance.GetOpacity();
                _material = MaterialPool.MatFrom(Resources.Font, ShaderDatabase.Transparent, color);
            }

            return _material;
        }

        public void Reset()
        {
            _material = null;
        }

        public IEnumerable<CharBoundsInTexture> GetBoundsInTextureFor(string text)
        {
            foreach (char c in text)
            {
                yield return GetCharBoundsInTextureFor(c);
            }
        }

        private CharBoundsInTexture GetCharBoundsInTextureFor(char c)
        {
            var index = GetIndexInFontForChar(c);
            var left = index * _charWidthAsTexturePortion;
            return new CharBoundsInTexture()
            {
                Left = left,
                Right = left + _charWidthAsTexturePortion
            };
        }

        private int GetIndexInFontForChar(char c)
        {
            if (c < '!')
            {
                return 0;
            }
            if (c < 'a')
            {
                return (int)(c - ' ');
            }
            if (c < '\u007f')
            {
                return (int)(c - ':');
            }
            // Á 00C1
            if (c == '\u00C1')
            {
                return 69;
            }
            // É 00C9
            if (c == '\u00C9')
            {
                return 70;
            }
            // Í 00CD
            if (c == '\u00CD')
            {
                return 71;
            }
            // Ó 00D3
            if (c == '\u00D3')
            {
                return 72;
            }
            // Ö 00D6
            if (c == '\u00D6')
            {
                return 73;
            }
            // Ő 0150
            if (c == '\u0150')
            {
                return 74;
            }
            // Ú 00DA
            if (c == '\u00DA')
            {
                return 75;
            }
            // Ü 00DC
            if (c == '\u00DC')
            {
                return 76;
            }
            // Ű 0170
            if (c == '\u0170')
            {
                return 77;
            }
            return 0;
        }
    }
}