using Swan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.RaspberryIO.Peripherals;
using Unosquare.WiringPi;

namespace RPiCar
{
    class IRIN
    {
        private int mPin;
        private bool mSignalVal;
        private IGpioPin gpio;
        private List<InfraredSensor.InfraredPulse> IRPulse;
        private int pulseCount = 0;
        private InfraredSensor IRSensor;

        public IRIN(int pin)
        {
            Pi.Init<BootstrapWiringPi>();
            mPin = pin;
            gpio = Pi.Gpio[mPin];
            gpio.PinMode = GpioPinDriveMode.Input;
            mSignalVal = gpio.Read();
            IRSensor = new InfraredSensor(gpio, true);

        }
        public bool Signal{ get { return mSignalVal; } }
        public void updateSignal()
        {
            mSignalVal = gpio.Read();
        }
        public string decode()
        {
            return InfraredSensor.NecDecoder.DecodePulses(IRPulse.ToArray()).ToString();
        }
        public void addPulse(InfraredSensor.InfraredPulse pulse)
        {
            IRPulse.Add(pulse);
            pulseCount++;
            if (pulseCount >= 50)
            {
                IRPulse.Clear();
            }
        }
    }
    }
