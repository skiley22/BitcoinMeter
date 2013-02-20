using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rainmeter;
using JSONreader;

// Overview: This is a blank canvas on which to build your plugin.

// Note: Measure.GetString, Plugin.GetString, Measure.ExecuteBang, and
// Plugin.ExecuteBang have been commented out. If you need GetString
// and/or ExecuteBang and you have read what they are used for from the
// SDK docs, uncomment the function(s). Otherwise leave them commented out
// (or get rid of them)!

namespace BitcoinPlugin
{
    internal class Measure
    {
        enum MeasureType
        {
            Username,
            Status,
            CurrentSpeed,
            Active,
            Estimated,
            Historical,
            Efficiency
        }

        MeasureType Type;

        internal Measure()
        {}

        internal void Reload(Rainmeter.API api, ref double maxValue)
        {
            string type = api.ReadString("Type", "");
            switch (type.ToLowerInvariant())
            {
                case "username":
                    Type = MeasureType.Username;
                    break;
                case "status":
                    Type = MeasureType.Status;
                    break;
                case "currentspeed":
                    Type = MeasureType.CurrentSpeed;
                    break;
                case "active":
                    Type = MeasureType.Active;
                    break;
                case "estimated":
                    Type = MeasureType.Estimated;
                    break;
                case "historical":
                    Type = MeasureType.Historical;
                    break;
                case "efficiency":
                    Type = MeasureType.Efficiency;
                    break;
                default:
                    API.Log(API.LogType.Error, "BitcoinPlugin.dll Type=" + type + " not valid");
                    break;
            }
        }

        internal double Update()
        {

            var ser = new Serializer();
            var user = new User();
            var pool = new Pool();

            user = ser.getUser();
            pool = ser.getPool();

            switch (Type)
            {

        }

            return 0.0;
        }

        internal string GetString()
        {
            var ser = new Serializer();
            var user = new User();
            var pool = new Pool();

            user = ser.getUser();
            pool = ser.getPool();

            switch (Type)
            {
                case MeasureType.Username:
                    return user.username;
                case MeasureType.Status:
                    return user.status;
                case MeasureType.CurrentSpeed:
                    return user.currSpeed;
                case MeasureType.Active:
                    return user.active;
                case MeasureType.Efficiency:
                    return user.efficiency;
                case MeasureType.Estimated:
                    return user.estimated.ToString();
                case MeasureType.Historical:
                    return user.historical.ToString();
            }
            return null;
        }

        //internal void ExecuteBang(string args)
        //{
        //}
    }

    public static class Plugin
    {
        internal static Dictionary<uint, Measure> Measures = new Dictionary<uint, Measure>();

        [DllExport]
        public unsafe static void Initialize(void** data, void* rm)
        {
            uint id = (uint)((void*)*data);
            Measures.Add(id, new Measure());
        }

        [DllExport]
        public unsafe static void Finalize(void* data)
        {
            uint id = (uint)data;
            Measures.Remove(id);
        }

        [DllExport]
        public unsafe static void Reload(void* data, void* rm, double* maxValue)
        {
            uint id = (uint)data;
            Measures[id].Reload(new Rainmeter.API((IntPtr)rm), ref *maxValue);
        }

        [DllExport]
        public unsafe static double Update(void* data)
        {
            uint id = (uint)data;
            return Measures[id].Update();
        }

        [DllExport]
        public unsafe static char* GetString(void* data)
        {
            uint id = (uint)data;
            fixed (char* s = Measures[id].GetString()) return s;
        }

        //[DllExport]
        //public unsafe static void ExecuteBang(void* data, char* args)
        //{
        //    uint id = (uint)data;
        //    Measures[id].ExecuteBang(new string(args));
        //}

    }
}
