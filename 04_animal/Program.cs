/*
4.
Визначити клас Animal(Dog, Cat ) чи ін.
У класі Animal визначити
    поле, що зберігає рівень життя тваринки(energy)
    подію Feed(погодувати)
    метод Run(), що приводить до певних витрат енергії; якщо енергія близька до мінімальної, то ініцювати подію Feed

Визначити клас Human.У класі визначити метод, що відповідає типу стандартного делегату EventHandler або EventHandler<MyArgs> і виконує "годування" тваринки.
 
 */

using System;

namespace _04_animal
{
    class Human// : EventArgs
    {
        int food;

        public Human(int food)
        {
            this.food = food;
        }

        public int Food
        {
            get { return food; }
        }
    }

    class Animal
    {
        public event EventHandler<Human> Feed;

        public Animal(uint energy = 0)
        {
            this.Energy = energy;
        }

        public uint Energy { get; set; }

        public void Run() 
        {
            --Energy;
            if (Energy < 10)
            {
                OnLowEnergy(new Human(20));
                Energy += 20;
            }
        }

        protected virtual void OnLowEnergy(Human eargs)
        {
            if (Feed != null)
                Feed(this, eargs);
        }
    }

    class MyEventArgs
    {
        static void Main(string[] args)
        {

            Animal animal = new Animal(30);
            animal.Feed += OnCatchLowEnergy;

            do
            {
                animal.Run();
                Console.WriteLine("Animal energy:\t{0}", animal.Energy);
                System.Threading.Thread.Sleep(200);

            } while (!Console.KeyAvailable);
        }

        static void OnCatchLowEnergy(object sender, Human eargs)
        {
            Console.WriteLine("\tAnimal eat " + eargs.Food);
        }
    }
}
