#include "stdafx.h"
#include "OVR.h"
#include "Wrapper.h"

EXPORT_TYPE char __stdcall Initialize()
{
	return ovr_Initialize();
}

EXPORT_TYPE void __stdcall Shutdown()
{
	return ovr_Shutdown();
}

EXPORT_TYPE ovrHmd __stdcall HmdCreate(int index)
{
	return ovrHmd_Create(index);
}

EXPORT_TYPE char __stdcall StartSensor(ovrHmd hmd, unsigned int supportedCaps, unsigned int requiredCaps)
{
	return ovrHmd_StartSensor(hmd, supportedCaps, requiredCaps);

}

EXPORT_TYPE void __stdcall StopSensor(ovrHmd hmd)
{
	return ovrHmd_StopSensor(hmd);
}

EXPORT_TYPE ovrSensorState __stdcall GetSensorState(ovrHmd hmd, double absTime)
{
	return ovrHmd_GetSensorState(hmd, absTime);
}

EXPORT_TYPE void __stdcall HmdGetDesc(ovrHmd hmd, ovrHmdDesc* desc)
{
	ovrHmd_GetDesc(hmd, desc);
}