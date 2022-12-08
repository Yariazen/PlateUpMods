using System;
using System.IO;
using UnityEngine;

namespace YariazenCore.Framework
{
    internal static class Util
    {
        public static string ModsPath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Mods");

        internal static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
