using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat
{
    class Cat
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Energy { get; set; } = 100;
        public int Price { get; set; }
        public int MealQuntity { get; set; }
        public void Eat()
        {
            Energy += 30;
            Price += 10;
        }
        public void Sleep()
        {
            Energy += 40;
        }
        public void Play()
        {
            if (Energy == 0)
            {
                Sleep();
            }
            else
            {
                Energy -= 40;
            }
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("=======CAT========");
            Console.WriteLine($"Nickname : {Nickname}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"Energy : {Energy}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Meal qunatity : {MealQuntity}");
        }
    }
    class CatHouse
    {
        public string Name { get; set; }
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; }
        public void AddCat(ref Cat cat)
        {
            Cat[] temp = new Cat[++CatCount];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;
        }
        public void RemoveByNickname(string Name)
        {
            Cat[] newCats = new Cat[--CatCount];
            for (int i = 0; i < CatCount; i++)
            {
                if (Name != Cats[i].Nickname)
                {
                    newCats[i] = Cats[i];
                }
                else
                {
                    for (int k = i, k2 = i + 1; k < CatCount; k++, k2++)
                    {
                        newCats[k] = Cats[k2];
                    }
                }
            }
            Cats = newCats;
        }
        public int CalculateCatHouseCatsPrices() {
            int sum = 0;
            foreach (var item in Cats)
            {
                sum+=item.Price;
            }
            return sum;
        }
        public int CalculateCatHouseCatsMealQuantity()
        {
            int sum1 = 0;
            foreach (var item in Cats)
            {
                sum1 += item.MealQuntity;
            }
            return sum1;
        }
        public void ShowCats()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("=======CATHOUSE========");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Cat count : {CatCount}");
            Console.WriteLine($"Cats prices : {CalculateCatHouseCatsPrices()}");
            Console.WriteLine($"Cats meal quntity : {CalculateCatHouseCatsMealQuantity()}");
            if (Cats != null)
            {
                foreach (var item in Cats)
                {
                    item.Show();
                }
            }
        }
    }
    class PetShop
    {
        public CatHouse[] catHouses { get; set; }
        public int CatHouseCount { get; set; }
        public void AddCatHouse(ref CatHouse cathouse)
        {
            CatHouse[] temp = new CatHouse[++CatHouseCount];
            if (catHouses != null)
            {
                catHouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cathouse;
            catHouses = temp;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========PETSHOP========");
            Console.WriteLine($"Cathouse count : {CatHouseCount}");
            Console.WriteLine($"Petshop cats prices : {CalculatePetshopCatsPrices()}");
            Console.WriteLine($"Petshop cats mealquantity : {CalculatePetshopMealQuantity()}");
            foreach (var item in catHouses)
            {
                item.ShowCats();
            }
        }
        public int CalculatePetshopCatsPrices() {
            int sum2 = 0;
            foreach (var item in catHouses)
            {
                sum2+=item.CalculateCatHouseCatsPrices();
            }
            return sum2;
        }
        public int CalculatePetshopMealQuantity()
        {
            int sum3 = 0;
            foreach (var item in catHouses)
            {
                sum3 += item.CalculateCatHouseCatsMealQuantity();
            }
            return sum3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat()
            {
                Nickname = "Tom",
                Age = 0,
                Gender = "Male",
                Price = 200,
                MealQuntity = 30
            };
            Cat cat2 = new Cat()
            {
                Nickname = "Bella",
                Age = 0,
                Gender = "Female",
                Price = 100,
                MealQuntity = 30
            };
            Cat cat3 = new Cat()
            {
                Nickname = "Kitty",
                Age = 0,
                Gender = "Female",
                Price = 100,
                MealQuntity = 30
            };
            Cat cat4 = new Cat()
            {
                Nickname = "Lucy",
                Age = 0,
                Gender = "Male",
                Price = 150,
                MealQuntity = 30
            };
            Cat cat5 = new Cat()
            {
                Nickname = "Jack",
                Age = 0,
                Gender = "Male",
                Price = 150,
                MealQuntity = 30
            };
            CatHouse catHouse = new CatHouse()
            {
                Name = "Whorehouse"
            };
            CatHouse catHouse1 = new CatHouse()
            {
                Name = "Bordello"
            };
            catHouse.AddCat(ref cat1);
            catHouse.AddCat(ref cat2);
            catHouse.AddCat(ref cat3);
            catHouse1.AddCat(ref cat4);
            catHouse1.AddCat(ref cat5);
            PetShop petShop = new PetShop();
            petShop.AddCatHouse(ref catHouse);
            petShop.AddCatHouse(ref catHouse1);
            petShop.Show();
            //catHouse.ShowCats();
            //catHouse.RemoveByNickname("Kitty");
            //catHouse.ShowCats();


            Console.ReadKey();
        }
    }
}


