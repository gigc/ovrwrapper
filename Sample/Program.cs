using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class OVRManager
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ovrQuatf
    {
        float x, y, z, w;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ovrVector3f
    {
        float x, y, z;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ovrPosef
    {
        ovrQuatf Orientation;
        ovrVector3f Position;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ovrPoseStatef
    {
        ovrPosef Pose;
        ovrVector3f AngularVelocity;
        ovrVector3f LinearVelocity;
        ovrVector3f AngularAcceleration;
        ovrVector3f LinearAcceleration;
        double TimeInSeconds;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ovrSensorState
    {
        ovrPoseStatef Predicted;
        ovrPoseStatef Recorded;
        float Temperature;
        UInt32 StatusFlags;
    };

    [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
    public static extern char Initialize();

    [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
    public static extern void Shutdown();

    [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
    public static extern IntPtr HmdCreate(int index);

    [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
    public static extern IntPtr StartSensor(IntPtr hmd, UInt32 supportedCaps, UInt32 requiredCaps);

    [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
    public static extern IntPtr StopSensor(IntPtr hmd);

    [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
    public static extern ovrSensorState GetSensorState(IntPtr hmd, double absTime);
}

namespace Sample
{

    class Program
    {
        static void Main(string[] args)
        {
            OVRManager.Initialize();
            IntPtr hmd = OVRManager.HmdCreate(0);
            OVRManager.StartSensor(hmd, 0x0010 | 0x0020 | 0x0100, 0);
            OVRManager.ovrSensorState sensor_state = OVRManager.GetSensorState(hmd, 0.0);
            OVRManager.StopSensor(hmd);
            OVRManager.Shutdown();
        }
    }
}