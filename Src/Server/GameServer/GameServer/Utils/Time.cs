// RayMix Libs - RayMix's .Net Libs
// Copyright 2018 Ray@raymix.net.  All rights reserved.
// https://www.raymix.net
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of RayMix.net. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

class Time
{
    static Time()
    {
        _stopwatch = Stopwatch.StartNew();
        startupTicks = ticks;
    }

    private static long _frameCount = 0;
    private static Stopwatch _stopwatch;

    /// <summary>
    /// The total number of frames that have passed (Read Only).
    /// </summary>
    public static long frameCount { get { return _frameCount; } }

    static long startupTicks = 0;

    /// <summary>
    /// 原作者英语水平不行
    /// 这个 ticks 实际表示的是经过的毫秒数
    /// </summary>
    static public long ticks
    {
        get
        {
           _stopwatch.Stop();
            return _stopwatch.ElapsedMilliseconds;
        }
    }


    private static long lastTick = 0;
    private static float _deltaTime = 0;

    /// <summary>
    /// The time in seconds it took to complete the last frame (Read Only).
    /// </summary>
    public static float deltaTime
    {
        get
        {
            return _deltaTime;
        }
    }


    private static float _time = 0;
    /// <summary>
    ///  The time at the beginning of this frame (Read Only). This is the time in seconds
    ///  since the start of the game.
    /// </summary> 
    public static float time
    {
        get
        {
            return _time;
        }
    }


    /// <summary>
    /// The real time in seconds since the started (Read Only).
    /// </summary>
    public static float realtimeSinceStartup
    {
        get
        {
            long _ticks = ticks;
            return (_ticks - startupTicks) / 1000f;
        }
    }

    public static void Tick()
    {
        long _ticks = ticks;


        _frameCount++;
        if (_frameCount == long.MaxValue)
            _frameCount = 0;

        if (lastTick == 0) lastTick = _ticks;
        _deltaTime = (_ticks - lastTick) / 1000f;
        _time = (_ticks - startupTicks) / 1000f;
        lastTick = _ticks;
    }
}