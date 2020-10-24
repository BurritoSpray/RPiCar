using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi.Native;

namespace RPiCar
{
    class Servo
    {
        private IGpioPin mServoPin;
        private int maxServoPwmVal = 25;
        private int minServoPwmVal = 4;
        private int servoPwmVal = 0;

        public Servo(int pin)
        {
            mServoPin = Pi.Gpio[pin];
            mServoPin.PinMode = GpioPinDriveMode.Output;
            WiringPi.SoftPwmCreate(mServoPin.BcmPinNumber, 0, maxServoPwmVal);
            WiringPi.SoftPwmWrite(mServoPin.BcmPinNumber, 16);
        }
        public int MaxServoPwmVal { get { return maxServoPwmVal; } }
        public int MinServoPwmVal { get { return minServoPwmVal; } }
        public int ServoPwmVal { get { return servoPwmVal; } }
        public void setServoPwm(int value)
        {
            if (value <= maxServoPwmVal && value >= minServoPwmVal)
            {
                servoPwmVal = value;
                WiringPi.SoftPwmWrite(mServoPin.BcmPinNumber, value);
            }
        }
        public void Right()
        {
            if (servoPwmVal > minServoPwmVal)
            {
                servoPwmVal -= 1;
                setServoPwm(servoPwmVal);
            }
        }
        public void Left()
        {
            if (servoPwmVal < maxServoPwmVal)
            {
                servoPwmVal += 1;
                setServoPwm(servoPwmVal);
            }
        }
    }
}
