#pragma once

extern "C" __declspec(dllexport) char __stdcall Initialize();
extern "C" __declspec(dllexport) void __stdcall Shutdown();
extern "C" __declspec(dllexport) ovrHmd __stdcall HmdCreate(int index);
extern "C" __declspec(dllexport) ovrHmd __stdcall HmdCreateDebug(ovrHmdType index);
extern "C" __declspec(dllexport) char __stdcall StartSensor(ovrHmd hmd, unsigned int supportedCaps, unsigned int requiredCaps);
extern "C" __declspec(dllexport) void __stdcall StopSensor(ovrHmd hmd);
extern "C" __declspec(dllexport) ovrSensorState __stdcall GetSensorState(ovrHmd hmd, double absTime);