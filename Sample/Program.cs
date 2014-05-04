using System;
using System.Runtime.InteropServices;

namespace Sample
{
    public class OVRManager
    {
        public enum ovrHmdType : uint
        {
            ovrHmd_None = 0,
            ovrHmd_DK1 = 3,
            ovrHmd_DKHD = 4,
            ovrHmd_CrystalCoveProto = 5,
            ovrHmd_DK2 = 6,
            ovrHmd_Other
        };

        public enum ovrEyeType : uint
        {
            ovrEye_Left = 0,
            ovrEye_Right = 1,
            ovrEye_Count = 2
        };

        public enum ovrHmdCapBits : uint
        {
            ovrHmdCap_Present = 0x0001,   //  This HMD exists (as opposed to being unplugged).
            ovrHmdCap_Available = 0x0002,   //  HMD and is sensor is available for use
            //  (if not owned by another app).    
            ovrHmdCap_Orientation = 0x0010,   //  Support orientation tracking (IMU).
            ovrHmdCap_YawCorrection = 0x0020,   //  Supports yaw correction through magnetometer or other means.
            ovrHmdCap_Position = 0x0040,   //  Supports positional tracking.
            ovrHmdCap_LowPersistence = 0x0080,   //  Supports low persistence mode.
            ovrHmdCap_LatencyTest = 0x0100,   //  Supports pixel reading for continous latency testing.
            ovrHmdCap_DynamicPrediction = 0x0200,   //  Adjust prediction dynamically based on DK2 Latency.

            // Support rendering without VSync for debugging
            ovrHmdCap_NoVSync = 0x1000
        };

        public enum ovrDistortionCaps : uint
        {        
            ovrDistortion_Chromatic = 0x01,
            ovrDistortion_TimeWarp = 0x02,
            ovrDistortion_Vignette = 0x08
        };

        public enum ovrRenderAPIType : uint
        {
            ovrRenderAPI_None,
            ovrRenderAPI_OpenGL,
            ovrRenderAPI_Android_GLES,  // May include extra native window pointers, etc.
            ovrRenderAPI_D3D9,
            ovrRenderAPI_D3D10,
            ovrRenderAPI_D3D11,
            ovrRenderAPI_Count
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrQuatf
        {
            public float x, y, z, w;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrVector3f
        {
            public float x, y, z;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrPosef
        {
            public ovrQuatf Orientation;
            public ovrVector3f Position;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrPoseStatef
        {
            public ovrPosef Pose;
            public ovrVector3f AngularVelocity;
            public ovrVector3f LinearVelocity;
            public ovrVector3f AngularAcceleration;
            public ovrVector3f LinearAcceleration;
            public float aligment_unused;
            public double TimeInSeconds;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrSensorState
        {
            public ovrPoseStatef Predicted;
            public ovrPoseStatef Recorded;
            public float Temperature;
            public UInt32 StatusFlags;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrSizei
        {
            public UInt32 w, h;

            public ovrSizei(UInt32 w, UInt32 h)
            {
                this.w = w;
                this.h = h;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrVector2i
        {
            public UInt32 x, y;

            public ovrVector2i(UInt32 x, UInt32 y)
            {
                this.x = x;
                this.y = y;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrVector2f
        {
            public float x, y;

            public ovrVector2f(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrFovPort
        {
            float UpTan;
            float DownTan;
            float LeftTan;
            float RightTan;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrHmdDesc
        {
            public IntPtr Handle;
            public ovrHmdType Type;

            IntPtr _ProductName;
            IntPtr _Manufacturer;

            public ovrHmdCapBits Caps;
            public ovrHmdCapBits DistortionCaps;

            public ovrSizei Resolution;
            public ovrVector2i WindowsPos;

            ovrFovPort _DefaultEyeFov;
            ovrFovPort _DefaultEyeFov2;
            ovrFovPort _MaxEyeFov;
            ovrFovPort _MaxEyeFov2;
            ovrEyeType _EyeRenderOrder;
            ovrEyeType _EyeRenderOrder2;

            IntPtr _DisplayDeviceName;
            public Int32 DisplayId;

            public ovrFovPort[] DefaultEyeFov()
            {
                return new ovrFovPort[(int)ovrEyeType.ovrEye_Count] { _DefaultEyeFov, _DefaultEyeFov2 };
            }

            public ovrFovPort[] MaxEyeFov()
            {
                return new ovrFovPort[(int)ovrEyeType.ovrEye_Count] { _MaxEyeFov, _MaxEyeFov2 };
            }

            public ovrEyeType[] EyeRenderOrder()
            {
                return new ovrEyeType[(int)ovrEyeType.ovrEye_Count] { _EyeRenderOrder, _EyeRenderOrder2 };
            }

            public string ProductName()
            {
                return Marshal.PtrToStringAnsi(_ProductName);
            }

            public string DisplayDeviceName()
            {
                return Marshal.PtrToStringAnsi(_DisplayDeviceName);
            }

            public string Manufacturer()
            {
                return Marshal.PtrToStringAnsi(_Manufacturer);
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrRecti
        {
            public ovrVector2i Pos;
            public ovrSizei Size;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrEyeDesc
        {
            public ovrEyeType Eye;
            public ovrSizei TextureSize;     // Absolute size of render texture.
            public ovrRecti RenderViewport;  // Viewport within texture where eye rendering takes place.
            // If specified as (0,0,0,0), it will be initialized to TextureSize.
            public ovrFovPort Fov;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrEyeRenderDesc
        {
            public ovrEyeDesc Desc;
            public ovrRecti DistortedViewport; 	        // Distortion viewport 
            public ovrVector2f PixelsPerTanAngleAtCenter;  // How many display pixels will fit in tan(angle) = 1.
            public ovrVector3f ViewAdjust;  		        // Translation to be applied to view matrix.
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrRenderAPIConfigHeader
        {
            public ovrRenderAPIType API;
            public ovrSizei RTSize;
            public int Multisample;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct ovrRenderAPIConfig
        {
            public ovrRenderAPIConfigHeader Header;
            UInt32 _PlatformData;
            UInt32 _PlatformData2;
            UInt32 _PlatformData3;
            UInt32 _PlatformData4;
            UInt32 _PlatformData5;
            UInt32 _PlatformData6;
            UInt32 _PlatformData7;
            UInt32 _PlatformData8;
        };

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
        public struct ovrD3D9ConfigData
        {
            [FieldOffset(0)]
            ovrRenderAPIConfig Generic;

            [FieldOffset(0)]
            public ovrRenderAPIConfigHeader Header;
            [FieldOffset(16)]
            public IntPtr Device;
        };

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern char Initialize();

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern void Shutdown();

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern IntPtr Create(int index);

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern void GetDesc(IntPtr hmd, ref ovrHmdDesc desc);

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern ovrSizei GetFovTextureSize(IntPtr hmd, ovrEyeType eye, ovrFovPort fov, float pixelsPerDisplayPixel);

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern bool ConfigureRendering(IntPtr hmd, ref ovrD3D9ConfigData apiConfig, ovrHmdCapBits hmdCaps, ovrDistortionCaps distortionCaps, ovrEyeDesc[] eyeDescIn, ref ovrEyeRenderDesc[] eyeRenderDescOut);

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern IntPtr StartSensor(IntPtr hmd, ovrHmdCapBits supportedCaps, ovrHmdCapBits requiredCaps);

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern IntPtr StopSensor(IntPtr hmd);

        [DllImport("..\\..\\..\\Debug\\Wrapper.dll")]
        public static extern ovrSensorState GetSensorState(IntPtr hmd, double absTime);
    }

    class Program : OVRManager
    {
        static void Main(string[] args)
        {
            Initialize();
            IntPtr hmd = Create(0);
            ovrHmdDesc desc = new ovrHmdDesc();
            GetDesc(hmd, ref desc);

            ovrSizei texture_size_left = GetFovTextureSize(hmd, ovrEyeType.ovrEye_Left, desc.DefaultEyeFov()[(int)ovrEyeType.ovrEye_Left], 1.0f);
            ovrSizei texture_size_right = GetFovTextureSize(hmd, ovrEyeType.ovrEye_Right, desc.DefaultEyeFov()[(int)ovrEyeType.ovrEye_Right], 1.0f);

            ovrSizei rt_size = new ovrSizei(texture_size_left.w + texture_size_right.w, (texture_size_left.h > texture_size_right.h) ? texture_size_left.h : texture_size_right.h);

            // Initialize eye rendering information for ovrHmd_Configure.
            // The viewport sizes are re-computed in case RenderTargetSize changed due to HW limitations.
            ovrEyeDesc[] eyes = new ovrEyeDesc[2];
            eyes[0].Eye = ovrEyeType.ovrEye_Left;
            eyes[1].Eye = ovrEyeType.ovrEye_Right;
            eyes[0].Fov = desc.DefaultEyeFov()[(int) ovrEyeType.ovrEye_Left];
            eyes[1].Fov = desc.DefaultEyeFov()[(int) ovrEyeType.ovrEye_Right];
            eyes[0].TextureSize = rt_size;
            eyes[1].TextureSize = rt_size;
            eyes[0].RenderViewport.Pos = new ovrVector2i(0, 0);
            eyes[0].RenderViewport.Size = new ovrSizei(rt_size.w / 2, rt_size.h);
            eyes[1].RenderViewport.Pos = new ovrVector2i((rt_size.w + 1) / 2, 0);
            eyes[1].RenderViewport.Size = eyes[0].RenderViewport.Size;

            ovrEyeRenderDesc[] renderDesc = new ovrEyeRenderDesc[2];

            ovrD3D9ConfigData renderConfigData = new ovrD3D9ConfigData();
            //real pointer (IDirect3DDevice9*) to device
            renderConfigData.Device = (IntPtr)0;

            renderConfigData.Header = new ovrRenderAPIConfigHeader
            {
                API = ovrRenderAPIType.ovrRenderAPI_D3D9,
                Multisample = 1,
                RTSize = new ovrSizei(desc.Resolution.w, desc.Resolution.h)
            };
            if (ConfigureRendering(hmd, ref renderConfigData, 0, ovrDistortionCaps.ovrDistortion_Chromatic | ovrDistortionCaps.ovrDistortion_TimeWarp, eyes, ref renderDesc))
            {
                StartSensor(hmd, ovrHmdCapBits.ovrHmdCap_Orientation | ovrHmdCapBits.ovrHmdCap_YawCorrection | ovrHmdCapBits.ovrHmdCap_LatencyTest, 0);
                ovrSensorState sensor_state = GetSensorState(hmd, 0.0);
                StopSensor(hmd);
            }
            Shutdown();
        }
    }
}