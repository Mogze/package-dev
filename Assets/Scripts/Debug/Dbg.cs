// Use this line to generate the .dll, you have to have mono compiler
// You have to use the .dll to trace the stack correctly
// Otherwise all debug lines will point this class
// You should change the UnityEngine.dll path and Dbg.cs path appropriately
// mcs -r:/Applications/Unity/Unity.app/Contents/Frameworks/Managed/UnityEngine.dll -target:library path/to/Dbg.cs
///*

using UnityEngine;

namespace GramGames.Framework.Log
{
    public static class Dbg
    {
        public const string TAG = "UNITY";

        public static string CurrentClass
        {
            get
            {
                var stackTrace = new System.Diagnostics.StackTrace();

                var index = Mathf.Min(stackTrace.FrameCount - 1, 2);

                if (index < 0)
                    return "[NoClass]";

                return "[" + stackTrace.GetFrame(index).GetMethod().DeclaringType.Name + "]";
            }
        }

        public static void Log(object message)
        {
            bool isDebug = false;
#if DEBUG
            isDebug = true;
#endif

            if (Debug.isDebugBuild || isDebug)
                Debug.Log(string.Format("{0} : {1} : {2}", TAG, CurrentClass, message));
        }

        public static void LogWarning(object message)
        {
            Debug.LogWarning(string.Format("{0} : {1} : {2}", TAG, CurrentClass, message));
        }

        public static void LogError(object message)
        {
            Debug.LogError(string.Format("{0} : {1} :{2}", TAG, CurrentClass, message));
        }
    }
}
//*/