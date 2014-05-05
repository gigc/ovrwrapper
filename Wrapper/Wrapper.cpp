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

EXPORT_TYPE ovrHmd __stdcall Create(int index)
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

EXPORT_TYPE void __stdcall GetDesc(ovrHmd hmd, ovrHmdDesc* desc)
{
	ovrHmd_GetDesc(hmd, desc);
}

EXPORT_TYPE ovrSizei __stdcall GetFovTextureSize(ovrHmd hmd, ovrEyeType eye, ovrFovPort fov, float pixelsPerDisplayPixel)
{
	return ovrHmd_GetFovTextureSize(hmd, eye, fov, pixelsPerDisplayPixel);
}

EXPORT_TYPE ovrBool __stdcall ConfigureRendering(ovrHmd hmd, const ovrRenderAPIConfig* apiConfig, unsigned int hmdCaps, unsigned int distortionCaps, const ovrEyeDesc eyeDescIn[2], ovrEyeRenderDesc eyeRenderDescOut[2])
{
	return ovrHmd_ConfigureRendering(hmd, apiConfig, hmdCaps, distortionCaps, eyeDescIn, eyeRenderDescOut);
}

EXPORT_TYPE ovrFrameTiming __stdcall BeginFrame(ovrHmd hmd, unsigned int frameIndex)
{
	return ovrHmd_BeginFrame(hmd, frameIndex);
}

EXPORT_TYPE void __stdcall EndFrame(ovrHmd hmd)
{
	return ovrHmd_EndFrame(hmd);
}

EXPORT_TYPE ovrPosef __stdcall BeginEyeRender(ovrHmd hmd, ovrEyeType eye)
{
	return ovrHmd_BeginEyeRender(hmd, eye);
}

EXPORT_TYPE void __stdcall EndEyeRender(ovrHmd hmd, ovrEyeType eye, ovrPosef renderPose, ovrTexture* eyeTexture)
{
	return ovrHmd_EndEyeRender(hmd, eye, renderPose, eyeTexture);
}

EXPORT_TYPE ovrMatrix4f __stdcall Projection(ovrFovPort fov, float znear, float zfar, ovrBool rightHanded)
{
	return ovrMatrix4f_Projection(fov, znear, zfar, rightHanded);
}