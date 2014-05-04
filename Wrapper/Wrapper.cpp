#include "stdafx.h"
#include "OVR.h"
#include "Wrapper.h"
#pragma pack(1)

extern "C" __declspec(dllexport) char __stdcall Initialize()
{
	return ovr_Initialize();
}

extern "C" __declspec(dllexport) void __stdcall Shutdown()
{
	return ovr_Shutdown();
}

extern "C" __declspec(dllexport) ovrHmd __stdcall HmdCreate(int index)
{
	return ovrHmd_Create(index);
}

extern "C" __declspec(dllexport) ovrHmd __stdcall HmdCreateDebug(ovrHmdType type)
{
	return ovrHmd_CreateDebug(type);
}

extern "C" __declspec(dllexport) char __stdcall StartSensor(ovrHmd hmd, unsigned int supportedCaps, unsigned int requiredCaps)
{
	return ovrHmd_StartSensor(hmd, supportedCaps, requiredCaps);

}

extern "C" __declspec(dllexport) void __stdcall StopSensor(ovrHmd hmd)
{
	return ovrHmd_StopSensor(hmd);
}

extern "C" __declspec(dllexport) ovrSensorState __stdcall GetSensorState(ovrHmd hmd, double absTime)
{
	return ovrHmd_GetSensorState(hmd, absTime);
}