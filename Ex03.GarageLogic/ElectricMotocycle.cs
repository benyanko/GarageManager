﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricMotocycle : Motocycle
    {
        private readonly float r_MaxBatterylife = 1.2f;

        public ElectricMotocycle(float i_RemainingTimeOfEngine, float i_CurrentAirPressure) : base(i_CurrentAirPressure)
        {
            Engine = new ElectricEngine(i_RemainingTimeOfEngine, this.r_MaxBatterylife);
            RemainingEnergyPercentage = (Engine.CurrentEnergyAmount / r_MaxBatterylife) * 100;
        }

        public void Charge(float i_TimeToCharge)
        {
            ((ElectricEngine)Engine).Charge(i_TimeToCharge);
            RemainingEnergyPercentage = (Engine.CurrentEnergyAmount / r_MaxBatterylife) * 100;
        }

        public override string ToString()
        {
            return string.Format("{0}", base.ToString());
        }
    }
}