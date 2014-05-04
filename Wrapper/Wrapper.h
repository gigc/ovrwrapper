#pragma once
#define EXPORT_TYPE extern "C" __declspec(dllexport)

EXPORT_TYPE char __stdcall Initialize();
EXPORT_TYPE void __stdcall Shutdown();
EXPORT_TYPE ovrHmd __stdcall Create(int index);
EXPORT_TYPE ovrHmd __stdcall CreateDebug(ovrHmdType index);
EXPORT_TYPE void __stdcall GetDesc(ovrHmd hmd, ovrHmdDesc* desc);
EXPORT_TYPE ovrSizei __stdcall GetFovTextureSize(ovrHmd hmd, ovrEyeType eye, ovrFovPort fov, float pixelsPerDisplayPixel);
EXPORT_TYPE char __stdcall StartSensor(ovrHmd hmd, unsigned int supportedCaps, unsigned int requiredCaps);
EXPORT_TYPE void __stdcall StopSensor(ovrHmd hmd);
EXPORT_TYPE ovrSensorState __stdcall GetSensorState(ovrHmd hmd, double absTime);