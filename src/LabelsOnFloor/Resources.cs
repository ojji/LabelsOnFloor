using UnityEngine;
using Verse;

namespace LabelsOnFloor
{
    [StaticConstructorOnStartup]
    public class Resources
    {
        public static Texture2D Font = ContentFinder<Texture2D>.Get("Consolas_accented");

        public static Texture2D Rename = ContentFinder<Texture2D>.Get("Rename");
    }
}