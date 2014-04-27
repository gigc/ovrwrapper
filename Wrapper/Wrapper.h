#pragma once

extern "C" __declspec(dllexport) char __stdcall Initialize();
extern "C" __declspec(dllexport) void __stdcall Shutdown();
extern "C" __declspec(dllexport) ovrHmd __stdcall HmdCreate(int index);
