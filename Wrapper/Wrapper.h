#pragma once
#define EXPORT_TYPE extern "C" __declspec(dllexport)

EXPORT_TYPE char __stdcall Initialize();
EXPORT_TYPE void __stdcall Shutdown();
EXPORT_TYPE ovrHmd __stdcall HmdCreate(int index);
EXPORT_TYPE void __stdcall HmdGetDesc(ovrHmd hmd, ovrHmdDesc* desc);
EXPORT_TYPE char __stdcall StartSensor(ovrHmd hmd, unsigned int supportedCaps, unsigned int requiredCaps);
EXPORT_TYPE void __stdcall StopSensor(ovrHmd hmd);
EXPORT_TYPE ovrSensorState __stdcall GetSensorState(ovrHmd hmd, double absTime);