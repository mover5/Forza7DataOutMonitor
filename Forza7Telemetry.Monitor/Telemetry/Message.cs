using System;
using Newtonsoft.Json;

namespace Forza7Telemetry.Monitor.Telemetry
{
    public class Message
    {
        #region Telemetry Property

        [JsonProperty]
        public int IsRaceOn { get; set; } // = 1 when race is on. = 0 when in menus/race stopped …


        [JsonProperty]
        public uint TimestampMS { get; set; } //Can overflow to 0 eventually


        [JsonProperty]
        public float EngineMaxRpm { get; set; }

        [JsonProperty]
        public float EngineIdleRpm { get; set; }

        [JsonProperty]
        public float CurrentEngineRpm { get; set; }


        [JsonProperty]
        public float AccelerationX { get; set; } //In the car's local space; X = right, Y = up, Z = forward

        [JsonProperty]
        public float AccelerationY { get; set; }

        [JsonProperty]
        public float AccelerationZ { get; set; }


        [JsonProperty]
        public float VelocityX { get; set; } //In the car's local space; X = right, Y = up, Z = forward

        [JsonProperty]
        public float VelocityY { get; set; }

        [JsonProperty]
        public float VelocityZ { get; set; }


        [JsonProperty]
        public float AngularVelocityX { get; set; } //In the car's local space; X = pitch, Y = yaw, Z = roll

        [JsonProperty]
        public float AngularVelocityY { get; set; }

        [JsonProperty]
        public float AngularVelocityZ { get; set; }


        [JsonProperty]
        public float Yaw { get; set; }

        [JsonProperty]
        public float Pitch { get; set; }

        [JsonProperty]
        public float Roll { get; set; }


        [JsonProperty]
        public float NormalizedSuspensionTravelFrontLeft { get; set; } // Suspension travel normalized: 0.0f = max stretch; 1.0 = max compression

        [JsonProperty]
        public float NormalizedSuspensionTravelFrontRight { get; set; }

        [JsonProperty]
        public float NormalizedSuspensionTravelRearLeft { get; set; }

        [JsonProperty]
        public float NormalizedSuspensionTravelRearRight { get; set; }


        [JsonProperty]
        public float TireSlipRatioFrontLeft { get; set; } // Tire normalized slip ratio, = 0 means 100% grip and |ratio| > 1.0 means loss of grip.

        [JsonProperty]
        public float TireSlipRatioFrontRight { get; set; }

        [JsonProperty]
        public float TireSlipRatioRearLeft { get; set; }

        [JsonProperty]
        public float TireSlipRatioRearRight { get; set; }


        [JsonProperty]
        public float WheelRotationSpeedFrontLeft { get; set; } // Wheel rotation speed radians/sec. 

        [JsonProperty]
        public float WheelRotationSpeedFrontRight { get; set; }

        [JsonProperty]
        public float WheelRotationSpeedRearLeft { get; set; }

        [JsonProperty]
        public float WheelRotationSpeedRearRight { get; set; }


        [JsonProperty]
        public int WheelOnRumbleStripFrontLeft { get; set; } // = 1 when wheel is on rumble strip, = 0 when off.

        [JsonProperty]
        public int WheelOnRumbleStripFrontRight { get; set; }

        [JsonProperty]
        public int WheelOnRumbleStripRearLeft { get; set; }

        [JsonProperty]
        public int WheelOnRumbleStripRearRight { get; set; }


        [JsonProperty]
        public float WheelInPuddleDepthFrontLeft { get; set; } // = from 0 to 1, where 1 is the deepest puddle

        [JsonProperty]
        public float WheelInPuddleDepthFrontRight { get; set; }

        [JsonProperty]
        public float WheelInPuddleDepthRearLeft { get; set; }

        [JsonProperty]
        public float WheelInPuddleDepthRearRight { get; set; }


        [JsonProperty]
        public float SurfaceRumbleFrontLeft { get; set; } // Non-dimensional surface rumble values passed to controller force feedback

        [JsonProperty]
        public float SurfaceRumbleFrontRight { get; set; }

        [JsonProperty]
        public float SurfaceRumbleRearLeft { get; set; }

        [JsonProperty]
        public float SurfaceRumbleRearRight { get; set; }


        [JsonProperty]
        public float TireSlipAngleFrontLeft { get; set; } // Tire normalized slip angle, = 0 means 100% grip and |angle| > 1.0 means loss of grip.

        [JsonProperty]
        public float TireSlipAngleFrontRight { get; set; }

        [JsonProperty]
        public float TireSlipAngleRearLeft { get; set; }

        [JsonProperty]
        public float TireSlipAngleRearRight { get; set; }


        [JsonProperty]
        public float TireCombinedSlipFrontLeft { get; set; } // Tire normalized combined slip, = 0 means 100% grip and |slip| > 1.0 means loss of grip.

        [JsonProperty]
        public float TireCombinedSlipFrontRight { get; set; }

        [JsonProperty]
        public float TireCombinedSlipRearLeft { get; set; }

        [JsonProperty]
        public float TireCombinedSlipRearRight { get; set; }


        [JsonProperty]
        public float SuspensionTravelMetersFrontLeft { get; set; } // Actual suspension travel in meters

        [JsonProperty]
        public float SuspensionTravelMetersFrontRight { get; set; }

        [JsonProperty]
        public float SuspensionTravelMetersRearLeft { get; set; }

        [JsonProperty]
        public float SuspensionTravelMetersRearRight { get; set; }


        [JsonProperty]
        public int CarOrdinal { get; set; } //Unique ID of the car make/model

        [JsonProperty]
        public int CarClass { get; set; } //Between 0 (D -- worst cars) and 7 (X class -- best cars) inclusive 

        [JsonProperty]
        public int CarPerformanceIndex { get; set; } //Between 100 (slowest car) and 999 (fastest car) inclusive

        [JsonProperty]
        public int DrivetrainType { get; set; } //Corresponds to EDrivetrainType; 0 = FWD, 1 = RWD, 2 = AWD

        [JsonProperty]
        public int NumCylinders { get; set; } //Number of cylinders in the engine

        #endregion

        public Message(byte[] rawTelemetryData)
        {
            this.IsRaceOn = BitConverter.ToInt32(rawTelemetryData, 0);
            this.TimestampMS = BitConverter.ToUInt32(rawTelemetryData, 4);
            this.EngineMaxRpm = BitConverter.ToSingle(rawTelemetryData, 8);
            this.EngineIdleRpm = BitConverter.ToSingle(rawTelemetryData, 12);
            this.CurrentEngineRpm = BitConverter.ToSingle(rawTelemetryData, 16);
            this.AccelerationX = BitConverter.ToSingle(rawTelemetryData, 20);
            this.AccelerationY = BitConverter.ToSingle(rawTelemetryData, 24);
            this.AccelerationZ = BitConverter.ToSingle(rawTelemetryData, 28);
            this.VelocityX = BitConverter.ToSingle(rawTelemetryData, 32);
            this.VelocityY = BitConverter.ToSingle(rawTelemetryData, 36);
            this.VelocityZ = BitConverter.ToSingle(rawTelemetryData, 40);
            this.AngularVelocityX = BitConverter.ToSingle(rawTelemetryData, 44);
            this.AngularVelocityY = BitConverter.ToSingle(rawTelemetryData, 48);
            this.AngularVelocityZ = BitConverter.ToSingle(rawTelemetryData, 52);
            this.Yaw = BitConverter.ToSingle(rawTelemetryData, 56);
            this.Pitch = BitConverter.ToSingle(rawTelemetryData, 60);
            this.Roll = BitConverter.ToSingle(rawTelemetryData, 64);
            this.NormalizedSuspensionTravelFrontLeft = BitConverter.ToSingle(rawTelemetryData, 68);
            this.NormalizedSuspensionTravelFrontRight = BitConverter.ToSingle(rawTelemetryData, 72);
            this.NormalizedSuspensionTravelRearLeft = BitConverter.ToSingle(rawTelemetryData, 76);
            this.NormalizedSuspensionTravelRearRight = BitConverter.ToSingle(rawTelemetryData, 80);
            this.TireSlipRatioFrontLeft = BitConverter.ToSingle(rawTelemetryData, 84);
            this.TireSlipRatioFrontRight = BitConverter.ToSingle(rawTelemetryData, 88);
            this.TireSlipRatioRearLeft = BitConverter.ToSingle(rawTelemetryData, 92);
            this.TireSlipRatioRearRight = BitConverter.ToSingle(rawTelemetryData, 96);
            this.WheelRotationSpeedFrontLeft = BitConverter.ToSingle(rawTelemetryData, 100);
            this.WheelRotationSpeedFrontRight = BitConverter.ToSingle(rawTelemetryData, 104);
            this.WheelRotationSpeedRearLeft = BitConverter.ToSingle(rawTelemetryData, 108);
            this.WheelRotationSpeedRearRight = BitConverter.ToSingle(rawTelemetryData, 112);
            this.WheelOnRumbleStripFrontLeft = BitConverter.ToInt32(rawTelemetryData, 116);
            this.WheelOnRumbleStripFrontRight = BitConverter.ToInt32(rawTelemetryData, 120);
            this.WheelOnRumbleStripRearLeft = BitConverter.ToInt32(rawTelemetryData, 124);
            this.WheelOnRumbleStripRearRight = BitConverter.ToInt32(rawTelemetryData, 128);
            this.WheelInPuddleDepthFrontLeft = BitConverter.ToSingle(rawTelemetryData, 132);
            this.WheelInPuddleDepthFrontRight = BitConverter.ToSingle(rawTelemetryData, 136);
            this.WheelInPuddleDepthRearLeft = BitConverter.ToSingle(rawTelemetryData, 140);
            this.WheelInPuddleDepthRearRight = BitConverter.ToSingle(rawTelemetryData, 144);
            this.SurfaceRumbleFrontLeft = BitConverter.ToSingle(rawTelemetryData, 148);
            this.SurfaceRumbleFrontRight = BitConverter.ToSingle(rawTelemetryData, 152);
            this.SurfaceRumbleRearLeft = BitConverter.ToSingle(rawTelemetryData, 156);
            this.SurfaceRumbleRearRight = BitConverter.ToSingle(rawTelemetryData, 160);
            this.TireSlipAngleFrontLeft = BitConverter.ToSingle(rawTelemetryData, 164);
            this.TireSlipAngleFrontRight = BitConverter.ToSingle(rawTelemetryData, 168);
            this.TireSlipAngleRearLeft = BitConverter.ToSingle(rawTelemetryData, 172);
            this.TireSlipAngleRearRight = BitConverter.ToSingle(rawTelemetryData, 176);
            this.TireCombinedSlipFrontLeft = BitConverter.ToSingle(rawTelemetryData, 180);
            this.TireCombinedSlipFrontRight = BitConverter.ToSingle(rawTelemetryData, 184);
            this.TireCombinedSlipRearLeft = BitConverter.ToSingle(rawTelemetryData, 188);
            this.TireCombinedSlipRearRight = BitConverter.ToSingle(rawTelemetryData, 192);
            this.SuspensionTravelMetersFrontLeft = BitConverter.ToSingle(rawTelemetryData, 196);
            this.SuspensionTravelMetersFrontRight = BitConverter.ToSingle(rawTelemetryData, 200);
            this.SuspensionTravelMetersRearLeft = BitConverter.ToSingle(rawTelemetryData, 204);
            this.SuspensionTravelMetersRearRight = BitConverter.ToSingle(rawTelemetryData, 208);
            this.CarOrdinal = BitConverter.ToInt32(rawTelemetryData, 212);
            this.CarClass = BitConverter.ToInt32(rawTelemetryData, 216);
            this.CarPerformanceIndex = BitConverter.ToInt32(rawTelemetryData, 220);
            this.DrivetrainType = BitConverter.ToInt32(rawTelemetryData, 224);
            this.NumCylinders = BitConverter.ToInt32(rawTelemetryData, 228);
        }
    }
}
