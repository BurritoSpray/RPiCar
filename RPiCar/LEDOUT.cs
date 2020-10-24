using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using Unosquare.WiringPi.Native;

namespace RPiCar
{
    class LEDOUT
    {
        private bool isOn = false;
        private bool isPWM = false;
        private int PWM = 0;
        private int pin = 4;
        private int maxPWM = 25;
        
        private IGpioPin ledPin;
        public LEDOUT()
        {
            Pi.Init<BootstrapWiringPi>();
            ledPin = Pi.Gpio[pin];
            ledPin.PinMode = GpioPinDriveMode.Output;
            ledPin.Write(false);
        }
        public LEDOUT(int pin)
        {
            Pi.Init<BootstrapWiringPi>();
            ledPin = Pi.Gpio[pin];
            ledPin.PinMode = GpioPinDriveMode.Output;
            ledPin.Write(false);
        }
        public LEDOUT(int pin, int pwm)
        {
            Pi.Init<BootstrapWiringPi>();
            ledPin = (GpioPin)Pi.Gpio[pin];
            ledPin.PinMode = GpioPinDriveMode.Output;
            WiringPi.SoftPwmCreate( pin, pwm, 10);
            
        }
        public void PWMON(int value)
        {
            isOn = true;
            isPWM = true;
            WiringPi.SoftPwmCreate(pin, value, maxPWM);
        }
        public void PWMOFF()
        {
            WiringPi.SoftPwmStop(pin);
            isPWM = false;
        }
        public void SETPWM(int value)
        {
            if (isPWM = true && isOn)
            {
                if (value >= 25)
                {
                    WiringPi.SoftPwmWrite(pin, 25);
                }
                else if(value <= 3)
                {
                    WiringPi.SoftPwmWrite(pin, 0);
                }
                else
                {
                    WiringPi.SoftPwmWrite(pin, value);
                }
            }
        }
        public void ON()
        {
            if(isPWM != true)
            {
                isOn = true;
                isPWM = true;
                WiringPi.SoftPwmCreate(pin, 10, 10);
            }


        }
        public void OFF()
        {
            isOn = false;
            
            if (isPWM = true)
            {
                isPWM = false;
                WiringPi.SoftPwmStop(pin);

            }
            else
            {
                ledPin.Write(false);
            }
        }
    }
}
