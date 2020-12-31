using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private Engine m_Engine;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle()
        {
            this.m_ModelName = string.Empty;
            this.m_LicenseNumber = string.Empty;
            this.m_Engine = null;
            this.m_RemainingEnergyPercentage = 0;
            this.m_Wheels = new List<Wheel>();
            this.m_OwnerName = string.Empty;
            this.m_OwnerPhoneNumber = string.Empty;
            this.m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.m_Engine;
            }

            set
            {
                this.m_Engine = value;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return this.m_RemainingEnergyPercentage;
            }

            set
            {
                this.m_RemainingEnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.m_OwnerName;
            }

            set
            {
                this.m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.m_OwnerPhoneNumber;
            }

            set
            {
                this.m_OwnerPhoneNumber = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return this.m_VehicleStatus;
            }

            set
            {
                this.m_VehicleStatus = value;
            }
        }

        public void InflateActionToMaximum()
        {
            foreach (Wheel wheel in this.m_Wheels)
            {
                wheel.inflateActionToMaximum();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"License number: {0}
Model name: {1}
Owner name: {2}
Vehicle status: {3}
{4}
Current energy percentage: {5}%
{6}",
             this.m_LicenseNumber, this.m_ModelName, this.m_OwnerName, this.m_VehicleStatus, this.m_Wheels[0].ToString(),
             this.m_RemainingEnergyPercentage, this.m_Engine.ToString());
        }
    }
}