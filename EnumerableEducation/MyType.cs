using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableEducation
{
    public class Car
    {
        // Константа для представления максимальной скорости,
        public const int MaxSpeed = 100;
        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = " ";
        //He вышел ли автомобиль из строя?
        private bool carlsDead;
        //В автомобиле имеется радиоприемник,
        private Radio theMusicBox = new Radio();
        // Конструкторы,
        public Car() 
        {
            PetName = "None";
            CurrentSpeed = 0;
        }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes(bool state)
        {
            // Делегировать запрос внутреннему объекту.
            theMusicBox.TurnOn(state);
        }
        // Проверить, не перегрелся ли автомобиль,
        public void Accelerate(int delta)
        {
            if (carlsDead)
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
                CurrentSpeed += delta;
            if (CurrentSpeed > MaxSpeed)
            {
                Console.WriteLine("{0} has overheated!", PetName);
                CurrentSpeed = 0;
                carlsDead = true;
            }
            else
                Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
        }
        public class Garage : IEnumerable
        {
            private Car[] carArray = new Car[4];
            // При запуске заполнить несколькими объектами Саг.
            public Garage()
            {
                carArray[0] = new Car("Rusty", 30);
                carArray[1] = new Car("Clunker", 55);
                carArray[2] = new Car("Zippy", 30);
                carArray[3] = new Car("Fred", 30);
            }
            public IEnumerator GetEnumerator()
            {
               // throw new Exception("excaption");
                return actualImplementation();
                IEnumerator actualImplementation()
                {

                    foreach (Car c in carArray)
                    {
                        yield return c;
                    }
                }
            }
        }   
        class Radio
        {
            public void TurnOn(bool on)
            {
                Console.WriteLine(on ? "Jamming..." : "Quiet time...");
            }
        }
    }
}
