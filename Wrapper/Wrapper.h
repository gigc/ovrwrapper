#pragma once
#define EXPORT_TYPE extern "C" __declspec(dllexport)

EXPORT_TYPE char __stdcall Initialize();
EXPORT_TYPE void __stdcall Shutdown();

EXPORT_TYPE ovrHmd __stdcall Create(int index);
EXPORT_TYPE void __stdcall GetDesc(ovrHmd hmd, ovrHmdDesc* desc);
EXPORT_TYPE ovrSizei __stdcall GetFovTextureSize(ovrHmd hmd, ovrEyeType eye, ovrFovPort fov, float pixelsPerDisplayPixel);
EXPORT_TYPE ovrBool __stdcall ConfigureRendering(ovrHmd hmd, const ovrRenderAPIConfig* apiConfig, unsigned int hmdCaps, unsigned int distortionCaps, const ovrEyeDesc eyeDescIn[2], ovrEyeRenderDesc eyeRenderDescOut[2]);

EXPORT_TYPE char __stdcall StartSensor(ovrHmd hmd, unsigned int supportedCaps, unsigned int requiredCaps);
EXPORT_TYPE void __stdcall StopSensor(ovrHmd hmd);
EXPORT_TYPE ovrSensorState __stdcall GetSensorState(ovrHmd hmd, double absTime);

EXPORT_TYPE ovrFrameTiming __stdcall BeginFrame(ovrHmd hmd, unsigned int frameIndex);
EXPORT_TYPE void __stdcall EndFrame(ovrHmd hmd);