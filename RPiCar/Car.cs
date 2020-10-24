using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using Unosquare.WiringPi.Native;

namespace RPiCar
{
    class Car
    {
        //motor 1 + motor 4 = backward
        //motor 2 + motor 3 = Forward
        //motor 1 + motor 3 = Left Turn
        //motor 2 + motor 4 = Right Turn
        private IGpioPin enableA;
        private IGpioPin enableB;
        private IGpioPin motor1;
        private IGpioPin motor2;
        private IGpioPin motor3;
        private IGpioPin motor4;
        private int mSpeed = 100;
        private int ENA1Pwm;
        private int ENA2Pwm;
        private int turnDivider = 5;
        private int mTurnSpeed = 60;
        private int maxPwmVal = 100;
        private bool isServoSet = false;
        private Servo servo;
        public Car(int controlPin1, int controlPin2, int controlPin3, int controlPin4, int enablePinA, int enablePinB)
        {
            //setup(controlPin1, controlPin2, controlPin3, controlPin4, enablePinA, enablePinB);
            Pi.Init<BootstrapWiringPi>();
            enableA = Pi.Gpio[enablePinA];
            enableB = Pi.Gpio[enablePinB];
            motor1 = Pi.Gpio[controlPin1];
            motor2 = Pi.Gpio[controlPin2];
            motor3 = Pi.Gpio[controlPin3];
            motor4 = Pi.Gpio[controlPin4];
            enableA.PinMode = GpioPinDriveMode.Output;
            enableB.PinMode = GpioPinDriveMode.Output;
            motor1.PinMode = GpioPinDriveMode.Output;
            motor2.PinMode = GpioPinDriveMode.Output;
            motor3.PinMode = GpioPinDriveMode.Output;
            motor4.PinMode = GpioPinDriveMode.Output;
            WiringPi.SoftPwmCreate(enablePinA, 0, maxPwmVal);
            WiringPi.SoftPwmCreate(enablePinB, 0, maxPwmVal);
            ENA1Pwm = mSpeed;
            ENA2Pwm = mSpeed;
        }
        public Car(int controlPin1, int controlPin2, int controlPin3, int controlPin4, int enablePinA, int enablePinB, int servoPin):this(controlPin1,controlPin2,controlPin3,controlPin4,enablePinA,enablePinB)
        {
            //setup(controlPin1, controlPin2, controlPin3, controlPin4, enablePinA, enablePinB);
            servo = new Servo(servoPin);
            isServoSet = true;
        }
        public void Forward()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, ENA1Pwm);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, ENA2Pwm);
            motor1.Write(false);
            motor2.Write(true);
            motor3.Write(true);
            motor4.Write(false);

        }
        public void Backward()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, ENA1Pwm);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, ENA2Pwm);
            motor1.Write(true);
            motor2.Write(false);
            motor3.Write(false);
            motor4.Write(true);
        }
        public void Right()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, mTurnSpeed);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, mTurnSpeed);
            motor1.Write(true);
            motor2.Write(false);
            motor3.Write(true);
            motor4.Write(false);
        }
        public void Left()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, mTurnSpeed);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, mTurnSpeed);
            motor1.Write(false);
            motor2.Write(true);
            motor3.Write(false);
            motor4.Write(true);
        }
        public void ForwardLeft()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, Speed);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, Speed / turnDivider);
            motor1.Write(false);
            motor2.Write(true);
            motor3.Write(true);
            motor4.Write(false);
        }
        public void ForwardRight()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, Speed / turnDivider);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, Speed);
            motor1.Write(false);
            motor2.Write(true);
            motor3.Write(true);
            motor4.Write(false);
        }
        public void BackwardLeft()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, Speed);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, Speed / turnDivider);
            motor1.Write(true);
            motor2.Write(false);
            motor3.Write(false);
            motor4.Write(true);
        }
        public void BackwardRight()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, Speed / turnDivider);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, Speed);
            motor1.Write(true);
            motor2.Write(false);
            motor3.Write(false);
            motor4.Write(true);
        }
        public void Stop()
        {
            WiringPi.SoftPwmWrite(enableA.BcmPinNumber, 0);
            WiringPi.SoftPwmWrite(enableB.BcmPinNumber, 0);
            motor1.Write(false);
            motor2.Write(false);
            motor3.Write(false);
            motor4.Write(false);
        }
        public void setSpeed(int speed)
        {
            if (speed <= 100 && speed >= 0)
            {
                ENA1Pwm = speed;
                ENA2Pwm = speed;
                mSpeed = speed;            }
            else if(speed > 100)
            {
                ENA1Pwm = 100;
                ENA2Pwm = 100;
                mSpeed = 100;
            }
            else if(speed < 0)
            {
                ENA1Pwm = 0;
                ENA2Pwm = 0;
                mSpeed = 0;
            }
            else
            {
                Console.WriteLine("Invalid speed value!");
            }
        }
        public int Speed { get { return mSpeed; } }
        public void setTurnSpeed(int speed)
        {
            if (speed <= 100 && speed >= 0)
            {
                mTurnSpeed = speed;
            }
            else
            {
                MessageBox.Show("Invalid Value!", "Error");
            }
        }
        public void setENA1(int value)
        {
            if (value <= maxPwmVal && value >= 0)
            {
                ENA1Pwm = value;
                WiringPi.SoftPwmWrite(enableA.BcmPinNumber, value);
            }
        }
        public int ENA1PWM { get { return ENA1Pwm; } }
        public void setENA2(int value)
        {
            if (value <= maxPwmVal && value >= 0)
            {
                ENA2Pwm = value;
                WiringPi.SoftPwmWrite(enableB.BcmPinNumber, value);
            }
        }
        public int ENA2PWM { get { return ENA2Pwm; } }
        public int TurnSpeed { get { return mTurnSpeed; } }
        public void changePinState(int pin, bool state)
        {
            switch (pin)
            {
                case 1:
                    WiringPi.SoftPwmWrite(enableA.BcmPinNumber, mSpeed);
                    WiringPi.SoftPwmWrite(enableB.BcmPinNumber, mSpeed);
                    motor1.Write(state);
                    break;
                case 2:
                    WiringPi.SoftPwmWrite(enableA.BcmPinNumber, mSpeed);
                    WiringPi.SoftPwmWrite(enableB.BcmPinNumber, mSpeed);
                    motor2.Write(state);
                    break;
                case 3:
                    WiringPi.SoftPwmWrite(enableA.BcmPinNumber, mSpeed);
                    WiringPi.SoftPwmWrite(enableB.BcmPinNumber, mSpeed);
                    motor3.Write(state);
                    break;
                case 4:
                    WiringPi.SoftPwmWrite(enableA.BcmPinNumber, mSpeed);
                    WiringPi.SoftPwmWrite(enableB.BcmPinNumber, mSpeed);
                    motor4.Write(state);
                    break;
                default:
                    MessageBox.Show("Invalid pin!", "Error");
                    break;
            }
        }
        public bool IsServoSet { get { return isServoSet; } }
        public void servoTurnRight()
        {
            servo.Right();
        }
        public void servoTurnLeft()
        {
            servo.Left();
        }
        public void setServoPosition(int value)
        {
            servo.setServoPwm(value);
        }
        public int MaxServoPwm { get { return servo.MaxServoPwmVal; } }
        public int MinServoPwm { get { return servo.MinServoPwmVal; } }
    }
}
