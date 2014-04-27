#include "stdafx.h"
#include "OVR.h"
#include "Wrapper.h"

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